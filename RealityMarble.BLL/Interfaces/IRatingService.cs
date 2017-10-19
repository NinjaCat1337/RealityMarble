using RealityMarble.BLL.DataTransferObjects;
using RealityMarble.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Interfaces
{
    public interface IRatingService
    {
        Task<OperationDetails> CreateRatingAsync(RatingDTO ratingDTO);
        Task<OperationDetails> UpdateRatingAsync(RatingDTO ratingDTO);
        RatingDTO GetRating(int id);
        Task<OperationDetails> DeleteRatingAsync(int id);
        IEnumerable<RatingDTO> GetAllRatings();
    }
}
