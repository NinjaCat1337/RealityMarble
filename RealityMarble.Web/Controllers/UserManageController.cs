using Microsoft.AspNet.Identity;
using Ninject;
using RealityMarble.BLL.DataTransferObjects;
using RealityMarble.BLL.Infrastructure;
using RealityMarble.BLL.Interfaces;
using RealityMarble.Web.Models;
using RealityMarble.Web.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RealityMarble.Web.Controllers
{
    public class UserManageController : Controller
    {
        IKernel ninjectKernel = new StandardKernel(new ServiceModule("RealityMarbleDB"));
        private IUserManageService userManageService;

        public UserManageController()
        {
            userManageService = ninjectKernel.Get<IUserManageService>();
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                await userManageService.ChangePasswordAsync(User.Identity.GetUserId<int>(), model.OldPassword, model.NewPassword);
            }
            return RedirectToAction("Gallery", new { userId = User.Identity.GetUserId<int>() });
        }

        [HttpGet]
        public ActionResult ChangeEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ChangeEmail(ChangeEmailModel model)
        {
            if (ModelState.IsValid)
            {
                await userManageService.ChangeEmailAsync(User.Identity.GetUserId<int>(), model.Email);
            }
            return RedirectToAction("Gallery", new { userId = User.Identity.GetUserId<int>() });
        }
    }
}