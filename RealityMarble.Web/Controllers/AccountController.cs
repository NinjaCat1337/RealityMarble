using Microsoft.Owin.Security;
using Ninject;
using RealityMarble.BLL.DataTransferObjects;
using RealityMarble.BLL.Infrastructure;
using RealityMarble.BLL.Interfaces;
using RealityMarble.BLL.Services;
using RealityMarble.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace RealityMarble.Web.Controllers
{
    public class AccountController : Controller
    {
        IKernel ninjectKernel = new StandardKernel(new ServiceModule("RealityMarbleDB"));
        private IUserPageService userPageService;
        private IUserService userService;

        public AccountController()
        {
            userPageService = ninjectKernel.Get<IUserPageService>();
            userService = ninjectKernel.Get<IUserService>();
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDTO = new UserDTO { UserName = model.UserName, Password = model.Password };
                ClaimsIdentity claim = await userService.Authenticate(userDTO);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Wrong login or password.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDTO = new UserDTO
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password,
                    Role = "User"
                };

                OperationDetails operationDetails = await userService.Create(userDTO);
                if (operationDetails.Succedeed)
                {
                    UserPageDTO userPageDTO = new UserPageDTO
                    {                      
                        Name = model.UserName,
                        UserId = userService.GetUserIdByName(model.UserName)
                    };
                    await userPageService.CreateUserPageAsync(userPageDTO);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                await userService.ChangePassword(model.Id, model.OldPassword, model.NewPassword);
            }
            return View(model);
        }

        private async Task SetInitialDataAsync()
        {
            await userService.SetInitialData(new List<string> { "User", "Moderator", "Administrator" });
        }
    }
}