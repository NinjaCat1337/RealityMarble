using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace RealityMarble.Web.Hubs
{
    public class MessagesHub : Hub
    {
        public void MessageSent(int receivedId, int senderId)
        {
            
        }
    }
}