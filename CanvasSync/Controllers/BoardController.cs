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

        public IActionResult Index() {
            return View();
        }

        // Redirects to the Board view with the specified ID
        [Route("Board/FindBoard")]
        [HttpPost]
        public async Task<IActionResult> FindBoard(IndexViewModel model) {
            // Check if a board with the given ID matches one in the database
            var board = await _context.Boards.FirstOrDefaultAsync(b => b.ID == model.ID);
            if (board == null) ModelState.AddModelError("ID", "Board does not exist");

            // If it doesnt, kick em back to the index page with a model state error
            if (!ModelState.IsValid) {
                ViewBag.ID = model.ID;
                return View("Index",model);
            }

            // If a board was found, then go to that board's page
            return RedirectToAction("Board", new { ID = model.ID });
        }

        // Saves a line in the database
        [Route("Board/SaveLine")]
        [HttpPost]
        public async Task<IActionResult> SaveLine([FromBody] Line line) {
            // Check data isn't null
            if(line == null || string.IsNullOrEmpty(line.BoardID)) return BadRequest();

            // Try to get the board from the database
            var boardToUpdate = await _context.Boards.Include(b => b.Lines).FirstOrDefaultAsync(b => b.ID == line.BoardID);

            // Make sure a board was found
            if (boardToUpdate == null) return NotFound();

            // Initialise the list that stores the strokes that make up the line, just to be 100% sure we don't get a null reference error
            line.Strokes ??= new List<Stroke>();

            // Add the line to the board and update the last modified attribute
            boardToUpdate.Lines.Add(line);
            boardToUpdate.LastModified = DateTime.Now;

            // Save changes to database
            _context.Update(boardToUpdate);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [Route("Board/{id?}")]
        public async Task<IActionResult> Board(string? id) {
            // Check for a null id, just in case the value wasn't bound properly
            if(id == null) return NotFound();

            // Get the board from the database
            var board = await _context.Boards.Include(b => b.Lines).ThenInclude(l => l.Strokes).FirstOrDefaultAsync(m => m.ID == id);
            
            // Make sure a board was found
            if(board == null) return NotFound();

            return View(board);
        }

        // Create new board
        [Route("Board/Create")]
        public async Task<IActionResult> Create() {
            // Create board and set initial values
            Board board = new Board();
            board.ID = Guid.NewGuid().ToString().Substring(0,5);
            board.DateCreated = DateTime.Now;
            board.LastModified = DateTime.Now;
            board.Lines = new List<Line>();

            // Add board and save it to the database
            _context.Add(board);
            await _context.SaveChangesAsync();

            // Redirect to the newly created board
            return RedirectToAction("Board", new { ID = board.ID });
        }
    }
}
