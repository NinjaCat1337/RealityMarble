using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.DataTransferObjects
{
    public class RatingDTO
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int ImageId { get; set; }
        public int UserId { get; set; }
    }
}
