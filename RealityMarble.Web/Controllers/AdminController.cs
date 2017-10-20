using Ninject;
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
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        IKernel ninjectKernel = new StandardKernel(new ServiceModule("RealityMarbleDB"));
        private IAdminService adminService;

        public AdminController()
        {
            adminService = ninjectKernel.Get<IAdminService>();
        }

        [HttpGet]
        public async Task<ActionResult> ChangePassword(int userId)
        {
            var user = await adminService.GetUserByIdAsync(userId);
            var model = WebMappers.FromUserDTOToChangePasswordByAdminModel(user);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordByAdminModel model)
        {
            if (ModelState.IsValid)
            {
                await adminService.ChangePasswordByAdminAsync(model.Id, model.Password);
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> ChangeUserName(int userId)
        {
            var user = await adminService.GetUserByIdAsync(userId);
            var model = WebMappers.FromUserDTOToChangeUserNameByAdminModel(user);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ChangeUserName(ChangeUserNameByAdminModel model)
        {
            if (ModelState.IsValid)
            {
                await adminService.ChangeUserNameByAdminAsync(model.Id, model.UserName);
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> ChangeEmail(int userId)
        {
            var user = await adminService.GetUserByIdAsync(userId);
            var model = WebMappers.FromUserDTOToChangeEmailByAdminModel(user);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ChangeEmail(ChangeEmailByAdminModel model)
        {
            if (ModelState.IsValid)
            {
                await adminService.ChangeEmailByAdminAsync(model.Id, model.Email);
            }
            return View();
        }

        public async Task<ActionResult> DeleteUser(int userId)
        {
            await adminService.DeleteUserAsync(userId);
            return View();
        }
    }
}