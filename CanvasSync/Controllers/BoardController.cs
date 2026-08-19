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

        [Route("Board/GetBoard")]
        [HttpPost]
        public async Task<IActionResult> GetBoard(string ID) {
            return RedirectToAction("Board", new { ID = ID });
        }

        [Route("Board/SaveLine")]
        [HttpPost]
        public async Task<IActionResult> SaveLine([FromBody] Line line) {
            if(string.IsNullOrEmpty(line.BoardID) || line == null) {
                return BadRequest();
            }
            var boardToUpdate = await _context.Boards.Include(b => b.Lines).FirstOrDefaultAsync(b => b.ID == line.BoardID);

            if(boardToUpdate == null) {
                return NotFound();
            }

            line.Strokes ??= new List<Stroke>();

            boardToUpdate.Lines.Add(line);
            _context.Update(boardToUpdate);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [Route("Board/{id?}")]
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

        [Route("Board/Create")]
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
