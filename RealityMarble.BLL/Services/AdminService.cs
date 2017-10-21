using AutoMapper;
using RealityMarble.BLL.DataTransferObjects;
using RealityMarble.BLL.Helpers;
using RealityMarble.BLL.Infrastructure;
using RealityMarble.BLL.Interfaces;
using RealityMarble.DAL.Entities;
using RealityMarble.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Services
{
    /// <summary>
    /// Class AdminService.
    /// </summary>
    /// <seealso cref="RealityMarble.BLL.Interfaces.IAdminService" />
    public class AdminService :IAdminService
    {
        IUnitOfWork Database { get; set; }

        public AdminService(IUnitOfWork uow)
        {
            Database = uow;
        }

        /// <summary>
        /// change password by admin as an asynchronous operation.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        public async Task<OperationDetails> ChangePasswordByAdminAsync(int userId, string newPassword)
        {
            var user = await Database.UserManager.FindByIdAsync(userId);
            if (user != null)
            {
                await Database.UserManager.ChangePasswordByAdminAsync(user, newPassword);
            }
            else
            {
                return new OperationDetails(false, "This users is not exist.", "");
            }
            return new OperationDetails(true, "Password changed.", "");
        }

        /// <summary>
        /// change email by admin as an asynchronous operation.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="newEmail">The new email.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        public async Task<OperationDetails> ChangeEmailByAdminAsync(int userId, string newEmail)
        {
            var user = await Database.UserManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.Email = newEmail;
                await Database.UserManager.UpdateAsync(user);
            }
            else
            {
                return new OperationDetails(false, "This users is not exist.", "");
            }
            return new OperationDetails(true, "Email changed.", "");
        }

        /// <summary>
        /// change user name by admin as an asynchronous operation.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="newUserName">New name of the user.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        public async Task<OperationDetails> ChangeUserNameByAdminAsync(int userId, string newUserName)
        {
            var user = await Database.UserManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.UserName = newUserName;
                await Database.UserManager.UpdateAsync(user);
                var userPage = Database.UserPages.GetByUserId(userId);
                userPage.Name = newUserName;
                Database.UserPages.Update(userPage);
                await Database.SaveAsync();
            }
            else
            {
                return new OperationDetails(false, "This users is not exist.", "");
            }
            return new OperationDetails(true, "Username changed.", "");
        }

        /// <summary>
        /// get user by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Task&lt;UserDTO&gt;.</returns>
        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            var user = await Database.UserManager.GetUserByIdAsync(userId);
            return BLLMappers.ToUserDTO(user);
        }

        /// <summary>
        /// delete user as an asynchronous operation.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        public async Task<OperationDetails> DeleteUserAsync(int userId)
        {
            var user = await Database.UserManager.FindByIdAsync(userId);
            if (user != null)
            {
                await Database.UserManager.DeleteAsync(user);
            }
            else
            {
                return new OperationDetails(false, "This users is not exist.", "");
            }
            return new OperationDetails(true, "User deleted..", "");
        }
    }
}
