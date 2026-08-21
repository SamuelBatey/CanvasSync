using Microsoft.AspNetCore.SignalR;

namespace CanvasSync.Hubs {
    public class BoardHub : Hub {

        public async Task SendStroke(int startX, int startY, int endX, int endY, int thickness, bool eraser, string group) {
            await Clients.OthersInGroup(group).SendAsync("ReceiveStroke", startX, startY, endX, endY, thickness, eraser);
        }

        public async Task AddToGroup(string boardID) {
            await Groups.AddToGroupAsync(Context.ConnectionId, boardID);
        }
    }
}
