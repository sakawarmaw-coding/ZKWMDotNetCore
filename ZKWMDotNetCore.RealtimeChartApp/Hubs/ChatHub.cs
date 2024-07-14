using Microsoft.AspNetCore.SignalR;

namespace ZKWMDotNetCore.RealtimeChartApp.Hubs
{
    public class ChatHub : Hub
    {
        //Send Message
        public async Task ServerReceiveMessage(string user, string message)
        {
            await Clients.All.SendAsync("ClientReceiveMessage", user, message);
        }
    }
}
