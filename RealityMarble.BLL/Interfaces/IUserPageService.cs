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
    /// Interface IUserPageService
    /// </summary>
    public interface IUserPageService
    {
        /// <summary>
        /// Creates the user page asynchronous.
        /// </summary>
        /// <param name="userPageDTO">The user page dto.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        Task<OperationDetails> CreateUserPageAsync(UserPageDTO userPageDTO);
        /// <summary>
        /// Updates the user page asynchronous.
        /// </summary>
        /// <param name="userPageDTO">The user page dto.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        Task<OperationDetails> UpdateUserPageAsync(UserPageDTO userPageDTO);
        /// <summary>
        /// Gets the user page.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>UserPageDTO.</returns>
        UserPageDTO GetUserPage(int id);
        /// <summary>
        /// Deletes the user page asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        Task<OperationDetails> DeleteUserPageAsync(int id);
        /// <summary>
        /// Gets all user pages.
        /// </summary>
        /// <returns>IEnumerable&lt;UserPageDTO&gt;.</returns>
        IEnumerable<UserPageDTO> GetAllUserPages();

        /// <summary>
        /// Gets the last authors.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns>IEnumerable&lt;UserPageDTO&gt;.</returns>
        IEnumerable<UserPageDTO> GetLastAuthors(int count);
    }
}
