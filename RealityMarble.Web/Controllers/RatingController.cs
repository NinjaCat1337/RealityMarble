using Microsoft.AspNet.Identity;
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
    public class RatingController : Controller
    {
        IKernel ninjectKernel = new StandardKernel(new ServiceModule("RealityMarbleDB"));
        private IRatingService ratingService;
        private IRatingHelper ratingHelper;

        public RatingController()
        {
            ratingService = ninjectKernel.Get<IRatingService>();
            ratingHelper = ninjectKernel.Get<IRatingHelper>();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(int ratedImageId, RatingModel model)
        {
            if (ModelState.IsValid)
            {
                RatingDTO rating = new RatingDTO
                {
                    Value = model.Value,
                    UserId = User.Identity.GetUserId<int>(),
                    ImageId = ratedImageId
                };
                if (ratingHelper.UserAlreadyRated(ratedImageId, User.Identity.GetUserId<int>()) == false)
                {
                    OperationDetails operationDetails = await ratingService.CreateRatingAsync(rating);
                    if (operationDetails.Succedeed)
                    {
                        await ratingHelper.UpdateImageRatingAsync(ratedImageId);
                    }
                }
                else
                {
                    return View("AccessDenied");
                }
            }
            return RedirectToAction("Details", "Image", new { imageId = ratedImageId });
        }
        [Authorize]
        public async Task<ActionResult> Delete(int ratedImageId)
        {
            OperationDetails operationDetails = await ratingHelper.DeleteRatingAsync(User.Identity.GetUserId<int>(), ratedImageId);
            if (operationDetails.Succedeed)
            {
                await ratingHelper.UpdateImageRatingAsync(ratedImageId);
            }
            return RedirectToAction("Details", "Image", new { imageId = ratedImageId });
        }

        [Authorize]
        public ActionResult RateButton(int imageId)
        {
            ViewData["ImageId"] = imageId;
            if (ratingHelper.UserAlreadyRated(imageId, User.Identity.GetUserId<int>()) == false)
            {               
                return PartialView("RateButtonCreate");
            }
            else
            {
                return PartialView("RateButtonDelete");
            }
        }
    }
}