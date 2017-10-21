using RealityMarble.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Interfaces
{
    /// <summary>
    /// Interface IRatingHelper
    /// </summary>
    public interface IRatingHelper
    {
        /// <summary>
        /// Updates the image rating asynchronous.
        /// </summary>
        /// <param name="imageId">The image identifier.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        Task<OperationDetails> UpdateImageRatingAsync(int imageId);
        /// <summary>
        /// Users the already rated.
        /// </summary>
        /// <param name="imageId">The image identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool UserAlreadyRated(int imageId, int userId);
        /// <summary>
        /// Deletes the rating asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="imageId">The image identifier.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        Task<OperationDetails> DeleteRatingAsync(int userId, int imageId);
    }
}
