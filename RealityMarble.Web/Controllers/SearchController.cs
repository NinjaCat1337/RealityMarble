using Ninject;
using RealityMarble.BLL.Infrastructure;
using RealityMarble.BLL.Interfaces;
using RealityMarble.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace RealityMarble.Web.Controllers
{
    public class SearchController : Controller
    {
        IKernel ninjectKernel = new StandardKernel(new ServiceModule("RealityMarbleDB"));
        private IUserPageService userPageService;
        private IImageService imageService;

        public SearchController()
        {
            userPageService = ninjectKernel.Get<IUserPageService>();
            imageService = ninjectKernel.Get<IImageService>();
        }
        public ActionResult Search()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult FindUser(string searchRequest)
        {
            var allUsers = userPageService.GetAllUserPages();
            var findedUsers = allUsers.Where(u => u.Name.ToLower().Contains(searchRequest.ToLower())).ToList();
            if (findedUsers.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(findedUsers);
        }   
        [HttpPost]
        public ActionResult FindImage(string searchRequest)
        {
            var allImages = imageService.GetAllImages();
            var findedImages = allImages.Where(i => i.About.ToLower().Contains(searchRequest.ToLower())).ToList();
            if (findedImages.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(findedImages);
        }

        public ActionResult AutocompleteSearch()
        {
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}