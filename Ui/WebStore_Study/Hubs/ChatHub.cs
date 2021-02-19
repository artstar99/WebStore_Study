using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace WebStore_Study.Hubs
{
    public class ChatHub: Hub
    {
        public async Task SendMessage(string message) => await Clients.All.SendAsync("MessageFromClient", message);
    }
}
