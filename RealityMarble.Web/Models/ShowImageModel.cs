using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealityMarble.Web.Models
{
    public class ShowImageModel
    {
        public int Id { get; set; }
        public string About { get; set; }
        public string Path { get; set; }
        public string Author { get; set; }
        public int UserId { get; set; }
        public decimal Rating { get; set; }
    }
}