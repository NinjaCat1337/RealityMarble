using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.DataTransferObjects
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public string About { get; set; }
        public string Path { get; set; }
        public decimal Rating { get; set; }
        public int UserId { get; set; }
        public string Author { get; set; }
    }
}
