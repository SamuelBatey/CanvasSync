using Microsoft.AspNetCore.Mvc;

namespace CanvasSync.Controllers {
    public class BoardController : Controller {
        public IActionResult Board() {
            return View();
        }
    }
}
