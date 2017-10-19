using RealityMarble.BLL.DataTransferObjects;
using RealityMarble.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealityMarble.Web.Utils
{
    public static class WebMappers
    {
        public static ShowImageModel ToShowImageModel(ImageDTO imageDTO)
        {
            return new ShowImageModel
            {
                Id = imageDTO.Id,
                About = imageDTO.About,
                Path = imageDTO.Path,
                Rating = imageDTO.Rating,
                UserId = imageDTO.UserId
            };
        }
        public static ImageDTO FromShowImageModelToImageDTO(ShowImageModel model)
        {
            return new ImageDTO
            {
                Id = model.Id,
                About = model.About,
                Path = model.Path,
                Rating = model.Rating,
                UserId = model.UserId
            };
        }
    }
}