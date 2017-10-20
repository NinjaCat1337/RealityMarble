﻿using AutoMapper;
using Microsoft.AspNet.Identity;
using RealityMarble.BLL.DataTransferObjects;
using RealityMarble.BLL.Helpers;
using RealityMarble.BLL.Infrastructure;
using RealityMarble.BLL.Interfaces;
using RealityMarble.DAL.Entities;
using RealityMarble.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static RealityMarble.DAL.Entities.ApplicationUser;

namespace RealityMarble.BLL.Services
{
    public class UserService :IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
            Mapper.Initialize(cfg => {cfg.CreateMap<ApplicationUser, UserDTO>();});
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            ApplicationUser userByMail = await Database.UserManager.FindByEmailAsync(userDto.Email);
            ApplicationUser user = await Database.UserManager.FindByNameAsync(userDto.UserName);
            if (userByMail == null)
            {
                if (user == null)
                {
                    user = new ApplicationUser { Email = userDto.Email, UserName = userDto.UserName };
                    var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                    if (result.Errors.Count() > 0)
                    {
                        return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                    }
                    await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                    await Database.SaveAsync();
                }
                else
                {
                    return new OperationDetails(false, "This username has been taken.", "UserName");
                }
                return new OperationDetails(true, "Registred.", "");
            }
            else
            {
                return new OperationDetails(false, "This e-mail adress has been taken.", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            ApplicationUser user = await Database.UserManager.FindAsync(userDto.UserName, userDto.Password);
            if (user != null)
                claim = await Database.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public async Task<OperationDetails> ChangePassword (int userId, string oldPassword, string newPassword)
        {
            var user = await Database.UserManager.FindByIdAsync(userId);
            if (user != null)
            {
                await Database.UserManager.ChangePasswordAsync(userId, oldPassword, newPassword);
            }
            else
            {
                return new OperationDetails(false, "This users is not exist.", "");
            }
            return new OperationDetails(true, "Password changed.", "");
        }

        public int GetUserIdByName(string userName)
        {
            var user = Database.UserManager.FindByName(userName);
            return user.Id;
        }

        public string GetUserNameById(int userId)
        {
            var user = Database.UserManager.FindById(userId);
            return user.UserName;
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            return Mapper.Map<IEnumerable<ApplicationUser>, List<UserDTO>>(Database.UserManager.Users.ToList());
        }

        public async Task SetInitialData(List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new Role { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }
        }
    }
}