using AutoMapper;
using RealityMarble.BLL.DataTransferObjects;
using RealityMarble.BLL.Helpers;
using RealityMarble.BLL.Infrastructure;
using RealityMarble.BLL.Interfaces;
using RealityMarble.DAL.Entities;
using RealityMarble.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Services
{
    /// <summary>
    /// Class RatingService.
    /// </summary>
    /// <seealso cref="RealityMarble.BLL.Interfaces.IRatingService" />
    public class RatingService :IRatingService
    {
        IUnitOfWork Database { get; set; }     

        public RatingService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }
        /// <summary>
        /// create rating as an asynchronous operation.
        /// </summary>
        /// <param name="ratingDTO">The rating dto.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        public async Task<OperationDetails> CreateRatingAsync(RatingDTO ratingDTO)
        {
            Rating rating = BLLMappers.ToRating(ratingDTO);
            Database.Ratings.Create(rating);           
            await Database.SaveAsync();
            return new OperationDetails(true, "Rating has been added.", "");
        }

        /// <summary>
        /// update rating as an asynchronous operation.
        /// </summary>
        /// <param name="ratingDTO">The rating dto.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        public async Task<OperationDetails> UpdateRatingAsync(RatingDTO ratingDTO)
        {
            Rating rating = BLLMappers.ToRating(ratingDTO);
            Rating item = Database.Ratings.Get(rating.Id);
            if (item != null)
            {
                Database.Ratings.Update(item);
            }
            await Database.SaveAsync();
            return new OperationDetails(true, "Rating has been added.", "");
        }

        /// <summary>
        /// Gets the rating.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>RatingDTO.</returns>
        /// <exception cref="RealityMarble.BLL.Infrastructure.ValidationException">Can't find a rating value</exception>
        public RatingDTO GetRating(int id)
        {
            var rating = Database.Ratings.Get(id);
            if (rating == null)
            {
                throw new ValidationException("Can't find a rating value", "");
            }
            return BLLMappers.ToRatingDTO(rating);
        }

        /// <summary>
        /// delete rating as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        public async Task<OperationDetails> DeleteRatingAsync(int id)
        {
            Rating item = Database.Ratings.Get(id);
            if (item != null)
            {
                Database.Ratings.Delete(item.Id);
            }
            await Database.SaveAsync();
            return new OperationDetails(true, "Rating has been added.", "");
        }

        /// <summary>
        /// Gets all ratings.
        /// </summary>
        /// <returns>IEnumerable&lt;RatingDTO&gt;.</returns>
        public IEnumerable<RatingDTO> GetAllRatings()
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<Rating, RatingDTO>(); });
            return Mapper.Map<IEnumerable<Rating>, List<RatingDTO>>(Database.Ratings.GetAll());
        }
    }
}
