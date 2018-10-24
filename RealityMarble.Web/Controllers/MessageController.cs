using AutoMapper;
using Microsoft.AspNet.Identity;
using Ninject;
using RealityMarble.BLL.DataTransferObjects;
using RealityMarble.BLL.Infrastructure;
using RealityMarble.BLL.Interfaces;
using RealityMarble.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealityMarble.Web.Controllers
{
    public class MessageController : Controller
    {
        IKernel ninjectKernel = new StandardKernel(new ServiceModule("RealityMarbleDB"));
        private IMessageService messageService;
        private IUserService userService;

        public MessageController()
        {
            messageService = ninjectKernel.Get<IMessageService>();
            userService = ninjectKernel.Get<IUserService>();
        }

        [Authorize]
        public ActionResult Send()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Send(SendMessageModel model)
        {
            if (ModelState.IsValid)
            {
                MessageDTO message = new MessageDTO
                {
                    Text = model.Text,
                    SenderUserId = User.Identity.GetUserId<int>(),
                    Date = DateTime.Now,
                    ReceiverUserId = model.ReceiverId,
                };
                messageService.SendMessageAsync(message);
                return RedirectToAction("Dialogue", new { senderId = User.Identity.GetUserId<int>(), receiverId = model.ReceiverId });
            }
            else
            {
                ViewData["ErrorMessage"] = "Model state is not valid.";
                return PartialView(model);
            }
        }
        [Authorize]
        public ActionResult Conversations()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Conversations(int receiverId)
        {
            var senders = messageService.GetLastMessages(receiverId);
            Mapper.Initialize(cfg => { cfg.CreateMap<MessageDTO, ShowSendersModel>(); });
            var sendersModel = Mapper.Map<IEnumerable<MessageDTO>, List<ShowSendersModel>>(senders);
            return View("Conversations", sendersModel);
        }
        [HttpGet]
        [Authorize]
        public ActionResult Dialogue (int receiverId, int senderId)
        {         
            var dialogue = messageService.GetDialogue(senderId, receiverId);
            Mapper.Initialize(cfg => { cfg.CreateMap<MessageDTO, ShowMessageModel>(); });
            var dialogueModel = Mapper.Map<IEnumerable<MessageDTO>, List<ShowMessageModel>>(dialogue);
            return View("Dialogue", dialogueModel);
        }

        [HttpGet]
        public ActionResult GetUserNameById (int userId)
        {
            ShowUserNameModel model = new ShowUserNameModel();
            model.UserName = userService.GetUserNameById(userId);
            return View(model);
        }
    }
}