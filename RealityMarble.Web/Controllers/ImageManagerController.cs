using Ninject;
using RealityMarble.BLL.Infrastructure;
using RealityMarble.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealityMarble.Web.Controllers
{
    public class ImageManagerController : Controller
    {
        IKernel ninjectKernel = new StandardKernel(new ServiceModule("RealityMarbleDB"));
        private IImageService imageService;
        private IUserService userService;

        public ImageManagerController()
        {
            imageService = ninjectKernel.Get<IImageService>();
            userService = ninjectKernel.Get<IUserService>();
        }

        [HttpGet]
        public ActionResult Images()
        {          
            return View();
        }
    }
}