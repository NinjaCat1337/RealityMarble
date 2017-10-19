using RealityMarble.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Interfaces
{
    public interface IRatingHelper
    {
        Task<OperationDetails> UpdateImageRatingAsync(int imageId);
        bool UserAlreadyRated(int imageId, int userId);
        Task <OperationDetails> DeleteRatingAsync(int userId, int imageId);
    }
}
