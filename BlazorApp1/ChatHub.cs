using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorChatSample.Server.Hubs
{
    public class ChatHub : Hub
    {
        ILogger<ChatHub> _logger;
        public ChatHub(ILogger<ChatHub> logger)
        {
            _logger = logger;
        }

        public async Task SendMessage(string username, string message, string connectionId)
        {
            await Clients.AllExcept(username).SendAsync("NotifyUser", username, message);
            _logger.LogInformation($"{username} said {message}");
        }

    }
}
