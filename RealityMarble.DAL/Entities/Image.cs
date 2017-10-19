using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.DAL.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string About { get; set; }
        public string Path { get; set; }
        public decimal Rating { get; set; }
        public string Author { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
        public Image()
        {
            Ratings = new List<Rating>();
        }

        public int UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
