using RealityMarble.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealityMarble.BLL.DataTransferObjects;
using RealityMarble.BLL.Infrastructure;
using RealityMarble.DAL.Interfaces;
using RealityMarble.BLL.Helpers;
using RealityMarble.DAL.Entities;
using AutoMapper;

namespace RealityMarble.BLL.Services
{
    public class MessageService : IMessageService
    {
        IUnitOfWork Database { get; set; }

        public MessageService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public IEnumerable<MessageDTO> GetLastMessages(int receiverId)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<Message, MessageDTO>(); });
            return Mapper.Map<IEnumerable<Message>, List<MessageDTO>>(Database.Messages
                .GetAll(where: x => x.ReceiverUserId == receiverId,  ascending: false, sortByInt: x => x.Id)
                .Union(Database.Messages.GetAll(where: x => x.SenderUserId == receiverId, ascending: false, sortByInt: x => x.Id))
                .GroupBy(x => x.ReceiverUserId | x.SenderUserId)
                .Select(x => x.First()))
                .OrderByDescending(x => x.Date);
        }

        public IEnumerable<MessageDTO> GetDialogue(int senderId, int receiverId)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<Message, MessageDTO>(); });
            return Mapper.Map<IEnumerable<Message>, List<MessageDTO>>(Database.Messages
                .GetAll(where: x => x.SenderUserId == senderId & x.ReceiverUserId == receiverId)
                .Union(Database.Messages.GetAll(where: x => x.SenderUserId == receiverId & x.ReceiverUserId == senderId))
                .OrderBy(x => x.Date));
        }

        public async Task<OperationDetails> SendMessageAsync(MessageDTO messageDTO)
        {
            Message message = BLLMappers.ToMessage(messageDTO);
            Database.Messages.Create(message);
            await Database.SaveAsync();
            return new OperationDetails(true, "Message was sent.", "");
        }

        public async Task<OperationDetails> UpdateMessageAsync(MessageDTO messageDTO)
        {
            Message message = Database.Messages.Get(messageDTO.Id);
            var item = BLLMappers.ToMessageEditMessageText(messageDTO);
            message.Text = item.Text;
            Database.Messages.Update(message);
            await Database.SaveAsync();
            return new OperationDetails(true, "Image has been updated.", "");
        }
    }
}
