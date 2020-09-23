using Domain.DTOs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.Hubs
{
    public class MessageHub : Hub
    {
        public async Task ReceiveMessage(MessageReceivedDTO message)
        {
            await Clients.All.SendAsync("ReceiveMessage",message);
        }
    }
}
