using RealityMarble.BLL.DataTransferObjects;
using RealityMarble.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Interfaces
{
    public interface IImageService
    {
        Task<OperationDetails> CreateImageAsync(ImageDTO imageDTO);
        ImageDTO GetImage(int id);
        Task<OperationDetails> UpdateImageAsync(ImageDTO imageDTO);
        Task<OperationDetails> DeleteImageAsync(int id);
        IEnumerable<ImageDTO> GetAllImages();
        IEnumerable<ImageDTO> GetLast10Images();
    }
}
