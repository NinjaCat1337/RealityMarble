using RealityMarble.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Interfaces
{
    /// <summary>
    /// Interface IUserManageService
    /// </summary>
    public interface IUserManageService
    {
        /// <summary>
        /// Changes the password asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        Task<OperationDetails> ChangePasswordAsync(int userId, string oldPassword, string newPassword);
        /// <summary>
        /// Changes the email asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="newEmail">The new email.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        Task<OperationDetails> ChangeEmailAsync(int userId, string newEmail);
    }
}
