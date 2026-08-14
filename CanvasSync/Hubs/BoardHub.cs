using Microsoft.AspNetCore.SignalR;

namespace CanvasSync.Hubs {
    public class BoardHub : Hub {
        public async Task SendBoard(int startX, int startY, int endX, int endY, int thickness, bool eraser) {
            await Clients.All.SendAsync("ReceiveBoard", startX, startY, endX, endY, thickness, eraser);
        }
    }
}
