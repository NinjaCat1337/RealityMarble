using RealityMarble.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Ninject;
using RealityMarble.BLL.Infrastructure;
using RealityMarble.BLL.DataTransferObjects;
using Microsoft.AspNet.Identity;
using RealityMarble.Web.Models;

namespace RealityMarble.Web.Controllers
{
    public class UserPageController : Controller
    {
        IKernel ninjectKernel = new StandardKernel(new ServiceModule("RealityMarbleDB"));
        private IUserPageService userPageService;

        public UserPageController()
        {
            userPageService = ninjectKernel.Get<IUserPageService>();
        }

        public ActionResult UserPages()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LastAuthors()
        {
            return PartialView(userPageService.GetLastAuthors(30));
        }
    }
}