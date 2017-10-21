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
    /// Interface IRatingService
    /// </summary>
    public interface IRatingService
    {
        /// <summary>
        /// Creates the rating asynchronous.
        /// </summary>
        /// <param name="ratingDTO">The rating dto.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        Task<OperationDetails> CreateRatingAsync(RatingDTO ratingDTO);
        /// <summary>
        /// Updates the rating asynchronous.
        /// </summary>
        /// <param name="ratingDTO">The rating dto.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        Task<OperationDetails> UpdateRatingAsync(RatingDTO ratingDTO);
        /// <summary>
        /// Gets the rating.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>RatingDTO.</returns>
        RatingDTO GetRating(int id);
        /// <summary>
        /// Deletes the rating asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        Task<OperationDetails> DeleteRatingAsync(int id);
        /// <summary>
        /// Gets all ratings.
        /// </summary>
        /// <returns>IEnumerable&lt;RatingDTO&gt;.</returns>
        IEnumerable<RatingDTO> GetAllRatings();
    }
}
