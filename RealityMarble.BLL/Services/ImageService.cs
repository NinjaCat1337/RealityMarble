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
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Services
{
    /// <summary>
    /// Class ImageService.
    /// </summary>
    /// <seealso cref="RealityMarble.BLL.Interfaces.IImageService" />
    public class ImageService :IImageService
    {
        IUnitOfWork Database { get; set; }

        public ImageService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        /// <summary>
        /// Creates the image asynchronous.
        /// </summary>
        /// <param name="imageDTO">The image dto.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        public async Task<OperationDetails> CreateImageAsync(ImageDTO imageDTO)
        {
            Image image = BLLMappers.ToImage(imageDTO);
            Database.Images.Create(image);
            await Database.SaveAsync();
            return new OperationDetails(true, "Image has been added.", "");
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ImageDTO.</returns>
        /// <exception cref="RealityMarble.BLL.Infrastructure.ValidationException">Can't find a image</exception>
        public ImageDTO GetImage(int id)
        {
            var image = Database.Images.Get(id);
            if (image == null)
            {
                throw new ValidationException("Can't find a image", "");
            }
            return BLLMappers.ToImageDTO(image);
        }

        /// <summary>
        /// update image as an asynchronous operation.
        /// </summary>
        /// <param name="imageDTO">The image dto.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        public async Task<OperationDetails> UpdateImageAsync(ImageDTO imageDTO)
        {
            Image image = Database.Images.Get(imageDTO.Id);
            var item = BLLMappers.ToImageUpdateAbout(imageDTO);
            image.About = item.About;
            Database.Images.Update(image);
            await Database.SaveAsync();
            return new OperationDetails(true, "Image has been updated.", "");
        }

        /// <summary>
        /// delete image as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        public async Task<OperationDetails> DeleteImageAsync(int id)
        {          
            Image item = Database.Images.Get(id);
            if (item != null)
            {
                Database.Images.Delete(id);
            }
            await Database.SaveAsync();
            return new OperationDetails(true, "Rating has been deleted.", "");
        }

        /// <summary>
        /// Gets all images.
        /// </summary>
        /// <returns>IEnumerable&lt;ImageDTO&gt;.</returns>
        public IEnumerable<ImageDTO> GetAllImages()
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<Image, ImageDTO>(); });
            return Mapper.Map<IEnumerable<Image>, List<ImageDTO>>(Database.Images.GetAll());
        }


        /// <summary>
        /// Gets the top10 images.
        /// </summary>
        /// <returns>IEnumerable&lt;ImageDTO&gt;.</returns>
        public IEnumerable<ImageDTO> GetTop10Images()
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<Image, ImageDTO>(); });
            return Mapper.Map<IEnumerable<Image>, List<ImageDTO>>(Database.Images.GetAll(sortByDecimal: x => x.Rating, ascending: false, take: 10));
        }

        /// <summary>
        /// Gets the last10 images.
        /// </summary>
        /// <returns>IEnumerable&lt;ImageDTO&gt;.</returns>
        public IEnumerable<ImageDTO> GetLast10Images()
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<Image, ImageDTO>(); });
            return Mapper.Map<IEnumerable<Image>, List<ImageDTO>>(Database.Images.GetAll(sortByInt: x => x.Id, ascending: false, take: 10));
        }  
    }
}
