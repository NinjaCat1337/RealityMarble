using RealityMarble.BLL.DataTransferObjects;
using RealityMarble.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Interfaces
{
    /// <summary>
    /// Interface IUserService
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Creates the specified user dto.
        /// </summary>
        /// <param name="userDto">The user dto.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        Task<OperationDetails> Create(UserDTO userDto);
        /// <summary>
        /// Authenticates the specified user dto.
        /// </summary>
        /// <param name="userDto">The user dto.</param>
        /// <returns>Task&lt;ClaimsIdentity&gt;.</returns>
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        Task<OperationDetails> ChangePassword(int userId, string oldPassword, string newPassword);
        /// <summary>
        /// Sets the initial data.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <returns>Task.</returns>
        Task SetInitialData(List<string> roles);
        /// <summary>
        /// Gets the name of the user identifier by.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>System.Int32.</returns>
        int GetUserIdByName(string userName);
        /// <summary>
        /// Gets the user name by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>System.String.</returns>
        string GetUserNameById(int userId);
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>IEnumerable&lt;UserDTO&gt;.</returns>
        IEnumerable<UserDTO> GetAllUsers();
    }
}
