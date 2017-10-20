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
    public class ImageController : Controller
    {
        IKernel ninjectKernel = new StandardKernel(new ServiceModule("RealityMarbleDB"));
        private IImageService imageService;

        public ImageController()
        {
            imageService = ninjectKernel.Get<IImageService>();
        }

        [HttpGet]
        public ActionResult Gallery(int userId)
        {
            var images = imageService.GetAllImages();
            var imagesByUser = from img in images
                               where img.UserId == userId
                               orderby img.Id descending
                               select img;
            if (imagesByUser.Count() >= 1)
            {
                ViewData["AuthorName"] = imagesByUser.Select(x => x.Author).FirstOrDefault().ToString() + " - Gallery";
            }
            else
            {
                ViewData["AuthorName"] = "Emty Gallery";
            }
            return View("Gallery", imagesByUser);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(CreateImageModel model, HttpPostedFileBase imageFile = null)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && HttpPostedFileBaseExtensions.IsImage(imageFile))
                {
                    string pictureName = Guid.NewGuid().ToString() + imageFile.FileName;
                    string path = System.IO.Path.Combine(Server.MapPath("~/Content/Images"), pictureName);
                    imageFile.SaveAs(path);

                    ImageDTO image = new ImageDTO
                    {
                        About = model.About,
                        Path = System.IO.Path.Combine("/Content/Images", pictureName),
                        Author = User.Identity.Name,
                        UserId = User.Identity.GetUserId<int>()
                    };
                    imageService.CreateImageAsync(image);
                    return RedirectToAction("Gallery", new { userId = User.Identity.GetUserId<int>() });
                }
                else
                {
                    ViewData["ErrorMessage"] = "This file is not a image.";
                    return View("Create");
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "Model state is not valid.";
                return View(model);
            }
        }
        public ActionResult Details(int imageId)
        {
            var image = imageService.GetImage(imageId);
            ShowImageModel model = WebMappers.FromImageDTOToShowImageModel(image);
            return View(model);
        }

        [Authorize]
        public ActionResult Delete(int imageId)
        {
            imageService.DeleteImageAsync(imageId);
            return RedirectToAction("Gallery", new { userId = User.Identity.GetUserId<int>() });
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int imageId)
        {
            var image = imageService.GetImage(imageId);
            return View(image);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Edit(EditImageModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ImageDTO image = new ImageDTO
            {
                Id = model.Id,
                About = model.About
            };
            await imageService.UpdateImageAsync(image);
            return RedirectToAction("Gallery", new { userId = User.Identity.GetUserId<int>() });
        }

        [HttpGet]
        public ActionResult TopRatedImages()
        {
            var AllImages = imageService.GetAllImages();
            var topImages = AllImages.OrderByDescending(im => im.Rating).Take(10);
            return PartialView(topImages);
        }
        [HttpGet]
        public ActionResult LastImages()
        {
            return PartialView(imageService.GetAllImages().OrderByDescending(x => x.Id).Take(10));
        }
    }
}