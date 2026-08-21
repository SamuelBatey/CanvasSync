using Microsoft.AspNetCore.SignalR;

namespace CanvasSync.Hubs {
    public class BoardHub : Hub {

        // Sends the stroke to all other clients in the board group
        public async Task SendStroke(int startX, int startY, int endX, int endY, int thickness, bool eraser, string group) {
            await Clients.OthersInGroup(group).SendAsync("ReceiveStroke", startX, startY, endX, endY, thickness, eraser);
        }

        // Adds the client to the given board group
        public async Task AddToGroup(string boardID) {
            await Groups.AddToGroupAsync(Context.ConnectionId, boardID);
        }
    }
}
