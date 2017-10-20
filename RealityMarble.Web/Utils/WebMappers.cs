using RealityMarble.BLL.DataTransferObjects;
using RealityMarble.Web.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealityMarble.Web.Utils
{
    public static class WebMappers
    {
        public static ShowImageModel FromImageDTOToShowImageModel(ImageDTO imageDTO)
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

        public static ChangePasswordByAdminModel FromUserDTOToChangePasswordByAdminModel(UserDTO model)
        {
            return new ChangePasswordByAdminModel
            {
                Id = model.Id,
                Password = model.Password          
            };
        }

        public static ChangeUserNameByAdminModel FromUserDTOToChangeUserNameByAdminModel(UserDTO model)
        {
            return new ChangeUserNameByAdminModel
            {
                Id = model.Id,
                UserName = model.UserName
            };
        }

        public static ChangeEmailByAdminModel FromUserDTOToChangeEmailByAdminModel(UserDTO model)
        {
            return new ChangeEmailByAdminModel
            {
                Id = model.Id,
                Email = model.Email
            };
        }

        public static ShowUserModel FromUserDTOToShowUserModel(UserDTO user)
        {
            return new ShowUserModel
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.UserName
            };
        }
    }
}