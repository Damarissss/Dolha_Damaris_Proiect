using Microsoft.AspNetCore.SignalR;

namespace Dolha_Damaris_Proiect.Hubs
{
    public class ChatHub : Hub
    {
        // The method that the client calls
        public async Task SendMessage(string user, string message)
        {
            // All clients will receive the same message
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

    }
}
