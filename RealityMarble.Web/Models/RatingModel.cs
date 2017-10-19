using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealityMarble.Web.Models
{
    public class RatingModel
    {
        [Required]
        [Range(1, 10, ErrorMessage = "Value must be from 1 to 10.")]
        public int Value { get; set; }
    }
}