using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealityMarble.Web.Models
{
    public class EditImageModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string About { get; set; }
    }
}