using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.DAL.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public int ImageId { get; set; }
        public virtual Image Image { get; set; }

        public int UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
