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

    }
}