using CanvasSync.Data;
using CanvasSync.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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

        [HttpPost]
        public async Task<IActionResult> SaveLine([FromBody] Line line) {
            if(string.IsNullOrEmpty(line.BoardID)) {
                return BadRequest();
            }
            var boardToUpdate = await _context.Boards.FirstOrDefaultAsync(b => b.ID == line.BoardID);
            if(boardToUpdate == null) {
                return NotFound();
            }
            boardToUpdate.Lines.Add(line);
            _context.Update(boardToUpdate);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [Route("Board/Board/{id?}")]
        public async Task<IActionResult> Board(string? id) {
            if(id == null) {
                return NotFound();
            }
            var board = await _context.Boards.Include(b => b.Lines).ThenInclude(l => l.Strokes).FirstOrDefaultAsync(m => m.ID == id);
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
            board.Lines = new List<Line>();

            _context.Add(board);
            await _context.SaveChangesAsync();
            return RedirectToAction("Board", new { ID = board.ID });
        }
    }
}
