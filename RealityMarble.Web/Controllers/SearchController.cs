using AutoMapper;
using Ninject;
using RealityMarble.BLL.DataTransferObjects;
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
        private IUserService userService;

        public SearchController()
        {
            userPageService = ninjectKernel.Get<IUserPageService>();
            imageService = ninjectKernel.Get<IImageService>();
            userService = ninjectKernel.Get<IUserService>();
        }
        public ActionResult Search()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult FindUser(string searchRequest)
        {
            var allUsers = userService.GetAllUsers();
            var findedUsers = allUsers.Where(u => u.UserName.ToLower().Contains(searchRequest.ToLower())).ToList();
            if (findedUsers.Count <= 0)
            {
                return HttpNotFound();
            }
            Mapper.Initialize(cfg => { cfg.CreateMap<UserDTO, ShowUserModel>(); });
            var usersModel = Mapper.Map<IEnumerable<UserDTO>, List<ShowUserModel>>(findedUsers);
            return PartialView(usersModel);
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
            Mapper.Initialize(cfg => { cfg.CreateMap<ImageDTO, ShowImageModel>(); });
            var imagesModel = Mapper.Map<IEnumerable<ImageDTO>, List<ShowImageModel>>(findedImages);
            return PartialView(imagesModel);
        }
    }
}