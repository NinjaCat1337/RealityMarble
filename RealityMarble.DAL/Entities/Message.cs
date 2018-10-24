using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.DAL.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public int SenderUserId { get; set; }
        public int ReceiverUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
