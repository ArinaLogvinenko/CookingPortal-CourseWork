using Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CookingPortal.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
