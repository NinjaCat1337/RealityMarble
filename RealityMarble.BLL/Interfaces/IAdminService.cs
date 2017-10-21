using RealityMarble.BLL.DataTransferObjects;
using RealityMarble.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Interfaces
{
    /// <summary>
    /// Interface IAdminService
    /// </summary>
    public interface IAdminService
    {
        /// <summary>
        /// Changes the password by admin asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        Task<OperationDetails> ChangePasswordByAdminAsync(int userId, string newPassword);
        /// <summary>
        /// Changes the email by admin asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="newEmail">The new email.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        Task<OperationDetails> ChangeEmailByAdminAsync(int userId, string newEmail);
        /// <summary>
        /// Changes the user name by admin asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="newUserName">New name of the user.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        Task<OperationDetails> ChangeUserNameByAdminAsync(int userId, string newUserName);
        /// <summary>
        /// Deletes the user asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        Task<OperationDetails> DeleteUserAsync(int userId);
        /// <summary>
        /// Gets the user by identifier asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Task&lt;UserDTO&gt;.</returns>
        Task<UserDTO> GetUserByIdAsync(int userId);
    }
}
