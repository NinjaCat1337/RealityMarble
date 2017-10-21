using RealityMarble.BLL.Infrastructure;
using RealityMarble.BLL.Interfaces;
using RealityMarble.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Services
{
    /// <summary>
    /// Class UserManageService.
    /// </summary>
    /// <seealso cref="RealityMarble.BLL.Interfaces.IUserManageService" />
    public class UserManageService :IUserManageService
    {
        IUnitOfWork Database { get; set; }

        public UserManageService(IUnitOfWork uow)
        {
            Database = uow;
        }

        /// <summary>
        /// change password as an asynchronous operation.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        public async Task<OperationDetails> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
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

        /// <summary>
        /// change email as an asynchronous operation.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="newEmail">The new email.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        public async Task<OperationDetails> ChangeEmailAsync(int userId, string newEmail)
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
    }
}