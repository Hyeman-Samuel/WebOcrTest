using Microsoft.AspNetCore.SignalR;
using System;
using System.Text;
using System.Threading.Tasks;

namespace WebOcrTest.Models
{
    public class ChatHub  :Hub
    { private readonly string ApiId;
        private readonly string ApiKey;
        public ChatHub()
        {
            ApiId = "";
            ApiKey = ""; 
        }
        public async Task SendMessage(string message)
        {

            await Clients.All.SendAsync("ReceiveMessge",message,ApiKey,ApiId);
        }
    }
}
