using Microsoft.AspNetCore.SignalR;

namespace CanvasSync.Hubs {
    public class BoardHub : Hub {

        public async Task SendBoard(int startX, int startY, int endX, int endY, int thickness, bool eraser, string group) {
            await Clients.OthersInGroup(group).SendAsync("ReceiveBoard", startX, startY, endX, endY, thickness, eraser);
        }

        public async Task AddToGroup(string boardID) {
            await Groups.AddToGroupAsync(Context.ConnectionId, boardID);
        }
    }
}
