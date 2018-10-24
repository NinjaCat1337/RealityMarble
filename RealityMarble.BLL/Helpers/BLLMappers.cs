using RealityMarble.BLL.DataTransferObjects;
using RealityMarble.DAL.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Helpers
{
    /// <summary>
    /// Class BLLMappers.
    /// </summary>
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

        #region User

        public static UserDTO ToUserDTO (ApplicationUser user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName, 
                Password ="",
                Role = user.Roles.ToString()
            };
        }

        #endregion

        #region Message

        public static Message ToMessage(MessageDTO messageDTO)
        {
            return new Message
            {
                Id = messageDTO.Id,
                Date = messageDTO.Date,
                Text = messageDTO.Text,
                ReceiverUserId = messageDTO.ReceiverUserId,
                SenderUserId = messageDTO.SenderUserId
            };
        }
        public static MessageDTO ToMessageDTO(Message message)
        {
            return new MessageDTO
            {
                Id = message.Id,
                Date = message.Date,
                Text = message.Text,
                ReceiverUserId = message.ReceiverUserId,
                SenderUserId = message.SenderUserId,
            };
        }

        public static Message ToMessageEditMessageText(MessageDTO messageDTO)
        {
            return new Message
            {
                Id = messageDTO.Id,
                Text = messageDTO.Text
            };
        }

        #endregion
    }
}
