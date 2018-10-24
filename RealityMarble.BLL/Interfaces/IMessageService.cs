using RealityMarble.BLL.DataTransferObjects;
using RealityMarble.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Interfaces
{
    public interface IMessageService
    {
        Task<OperationDetails> SendMessageAsync (MessageDTO messageDTO);
        Task<OperationDetails> UpdateMessageAsync(MessageDTO messageDTO);
        IEnumerable<MessageDTO> GetLastMessages(int receiverId);
        IEnumerable<MessageDTO> GetDialogue(int senderId, int receiverId);
    }
}
