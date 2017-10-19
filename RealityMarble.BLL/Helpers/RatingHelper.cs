using RealityMarble.BLL.Infrastructure;
using RealityMarble.BLL.Interfaces;
using RealityMarble.DAL.Entities;
using RealityMarble.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Helpers
{
    public class RatingHelper :IRatingHelper
    {
        IUnitOfWork Database { get; set; }

        public RatingHelper(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        /// <summary>
        /// This method updates image rating
        /// </summary>
        /// /// <param name="imageId">Set a image ID</param>
        public async Task<OperationDetails> UpdateImageRatingAsync(int imageId)
        {
            Image image = Database.Images.Get(imageId);
            var ratingsSum = 0;
            var AllRatings = Database.Ratings.GetAll();
            var ratings = from r in AllRatings
                          where r.ImageId == imageId
                          select r;
            foreach (var r in ratings)
            {
                ratingsSum += r.Value;
            }
            if (ratings.Count() != 0)
            {
                image.Rating = ratingsSum / ratings.Count();
            }
            else
            {
                image.Rating = 0;
            }
            Database.Images.Update(image);
            await Database.SaveAsync();
            return new OperationDetails(true, "Rating has been updated.", "");
        }
        public bool UserAlreadyRated(int imageId, int userId)
        {
            var AllRatings = Database.Ratings.GetAll();
            var votedUsers = from r in AllRatings
                                       where r.ImageId == imageId
                                       select r.UserId;
            votedUsers.ToList();
            if (votedUsers.Any(x => x == userId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This method deletes image rating
        /// </summary>
        /// /// <param name="imageId">Set a image ID</param>
        /// /// <param name="userId">Set a user ID</param>
        public async Task<OperationDetails> DeleteRatingAsync(int userId, int imageId)
        {
            int vote = 0;
            var AllRatings = Database.Ratings.GetAll();
            var userVote = from v in AllRatings
                           where v.ImageId == imageId && v.UserId == userId
                           select v;
            foreach (var x in userVote)
            {
                vote = x.Id;
            }
            Database.Ratings.Delete(vote);
            await Database.SaveAsync();
            return new OperationDetails(true, "Rating has been deleted.", "");
        }
    }
}
