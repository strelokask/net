using Microsoft.AspNetCore.SignalR;

namespace WebApp.Hubs
{
    public class UserHub : Hub
    {
        static int TotalViews { get; set; } = 0;
        static int TotalUsers { get; set; } = 0;

        public override Task OnConnectedAsync()
        {
            TotalUsers ++;
            Clients.All.SendAsync("updateTotalUsers", TotalUsers).GetAwaiter().GetResult();
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            TotalUsers --;
            Clients.All.SendAsync("updateTotalUsers", TotalUsers).GetAwaiter().GetResult();
            return base.OnDisconnectedAsync(exception);
        }

        public async Task NewWindowLoadedAsync()
        {
            TotalViews++;

            await Clients.All.SendAsync("updateTotalViews", TotalViews);
        }
    }
}
