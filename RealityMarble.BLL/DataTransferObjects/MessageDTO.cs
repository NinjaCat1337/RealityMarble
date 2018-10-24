using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.DataTransferObjects
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int SenderUserId { get; set; }
        public int ReceiverUserId { get; set; }
    }
}
