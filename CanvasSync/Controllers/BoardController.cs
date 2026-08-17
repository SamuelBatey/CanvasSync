using CanvasSync.Data;
using CanvasSync.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CanvasSync.Controllers {
    public class BoardController : Controller {
        private readonly BoardContext _context;

        public BoardController(BoardContext context) {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> GetBoard(string ID) {
            return RedirectToAction("Board", new { ID = ID });
        }

        [Route("Board/Board/{id?}")]
        public async Task<IActionResult> Board(string? id) {
            if(id == null) {
                return NotFound();
            }
            var board = await _context.Boards.FirstOrDefaultAsync(m => m.ID == id);
            if(board == null) {
                return NotFound();
            }
            return View(board);
        }

        public async Task<IActionResult> Create() {
            Board board = new Board();
            board.ID = Guid.NewGuid().ToString().Substring(0,5);
            board.DateCreated = DateTime.Now;
            board.LastModified = DateTime.Now;
            board.CanvasDataURL = "temp";

            _context.Add(board);
            await _context.SaveChangesAsync();
            return RedirectToAction("Board", new { ID = board.ID });
        }
    }
}
