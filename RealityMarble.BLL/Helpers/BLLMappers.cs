using RealityMarble.BLL.DataTransferObjects;
using RealityMarble.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Helpers
{
    public static class BLLMappers
    {
        #region Image
        public static Image ToImage(ImageDTO imageDTO)
        {
            return new Image
            {
                Id = imageDTO.Id,
                About = imageDTO.About,
                Author = imageDTO.Author,
                Path = imageDTO.Path,
                Rating = imageDTO.Rating,
                UserId = imageDTO.UserId
            };
        }
        public static ImageDTO ToImageDTO (Image image)
        {
            return new ImageDTO
            {
                Id = image.Id,
                About = image.About,
                Author = image.Author,
                Path = image.Path,
                Rating = image.Rating,
                UserId = image.UserId
            };
        }
        public static Image ToImageUpdateAbout(ImageDTO imageDTO)
        {
            return new Image
            {
                Id = imageDTO.Id,
                About = imageDTO.About
            };
        }
        #endregion

        #region Rating
        public static Rating ToRating(RatingDTO ratingDTO)
        {
            return new Rating
            {
                Id = ratingDTO.Id,
                ImageId = ratingDTO.ImageId,
                UserId = ratingDTO.UserId,
                Value = ratingDTO.Value
            };
        }
        public static RatingDTO ToRatingDTO(Rating rating)
        {
            return new RatingDTO
            {
                Id = rating.Id,
                ImageId = rating.ImageId,
                UserId = rating.UserId,
                Value = rating.Value
            };
        }
        #endregion

        #region UserPage
        public static UserPage ToUserPage(UserPageDTO userPageDTO)
        {
            return new UserPage
            {
                Id = userPageDTO.Id,
                Name = userPageDTO.Name,
                UserId = userPageDTO.UserId
            };
        }

        public static UserPageDTO ToUserPageDTO(UserPage userPage)
        {
            return new UserPageDTO
            {
                Id = userPage.Id,
                Name = userPage.Name,
                UserId = userPage.UserId
            };
        }
        #endregion
    }
}
