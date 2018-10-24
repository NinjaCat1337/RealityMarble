using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealityMarble.Web.Models
{
    public class SendMessageModel
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public int ReceiverId { get; set; }
    }
}