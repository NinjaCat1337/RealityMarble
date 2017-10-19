using Ninject;
using RealityMarble.BLL.DataTransferObjects;
using RealityMarble.BLL.Infrastructure;
using RealityMarble.BLL.Interfaces;
using RealityMarble.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RealityMarble.Web.Controllers
{
    public class UserManagerController : Controller
    {
        IKernel ninjectKernel = new StandardKernel(new ServiceModule("RealityMarbleDB"));
        private IUserService userService;
        private IUserPageService userPageService;

        public UserManagerController()
        {
            userService = ninjectKernel.Get<IUserService>();
            userPageService = ninjectKernel.Get<IUserPageService>();
        }
        public ActionResult Users()
        {
            var allUsers = userService.GetAllUsers();
            return View(allUsers);
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditUserModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO userDTO = new UserDTO
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password,
                    Role = model.Role
                };

                OperationDetails operationDetails = await userService.Create(userDTO);
                if (operationDetails.Succedeed)
                {
                    UserPageDTO userPageDTO = new UserPageDTO
                    {
                        Name = model.UserName,                       
                    };
                    await userPageService.UpdateUserPageAsync(userPageDTO);
                    return View("Users");
                }
                else
                {
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
                }
            }
            return View(model);
        }
    }
}