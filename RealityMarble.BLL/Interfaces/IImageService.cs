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
    /// Interface IImageService
    /// </summary>
    public interface IImageService
    {
        /// <summary>
        /// Creates the image asynchronous.
        /// </summary>
        /// <param name="imageDTO">The image dto.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        Task<OperationDetails> CreateImageAsync(ImageDTO imageDTO);
        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ImageDTO.</returns>
        ImageDTO GetImage(int id);
        /// <summary>
        /// Updates the image asynchronous.
        /// </summary>
        /// <param name="imageDTO">The image dto.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        Task<OperationDetails> UpdateImageAsync(ImageDTO imageDTO);
        /// <summary>
        /// Deletes the image asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;OperationDetails&gt;.</returns>
        Task<OperationDetails> DeleteImageAsync(int id);
        /// <summary>
        /// Gets all images.
        /// </summary>
        /// <returns>IEnumerable&lt;ImageDTO&gt;.</returns>
        IEnumerable<ImageDTO> GetAllImages();
        /// <summary>
        /// Gets the last10 images.
        /// </summary>
        /// <returns>IEnumerable&lt;ImageDTO&gt;.</returns>
        IEnumerable<ImageDTO> GetLast10Images();
    }
}
