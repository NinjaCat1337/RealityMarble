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
    public class RatingService :IRatingService
    {
        IUnitOfWork Database { get; set; }     

        public RatingService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }
        public async Task<OperationDetails> CreateRatingAsync(RatingDTO ratingDTO)
        {
            Rating rating = BLLMappers.ToRating(ratingDTO);
            Database.Ratings.Create(rating);           
            await Database.SaveAsync();
            return new OperationDetails(true, "Rating has been added.", "");
        }

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

        public RatingDTO GetRating(int id)
        {
            var rating = Database.Ratings.Get(id);
            if (rating == null)
            {
                throw new ValidationException("Can't find a rating value", "");
            }
            return BLLMappers.ToRatingDTO(rating);
        }

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

        public IEnumerable<RatingDTO> GetAllRatings()
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<Rating, RatingDTO>(); });
            return Mapper.Map<IEnumerable<Rating>, List<RatingDTO>>(Database.Ratings.GetAll());
        }
    }
}
