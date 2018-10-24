using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealityMarble.Web.Models
{
    public class ShowMessageModel
    {
        public int SenderUserId { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
    }
}