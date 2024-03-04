using Microsoft.AspNetCore.Mvc;

namespace MVCWebApp.Controllers
{
    public class NumbersController : Controller
    {
        private readonly ILogger<NumbersController> logger;

        public NumbersController(ILogger<NumbersController> _logger)
        {
            logger = _logger;
        }
        
        
        public IActionResult Index()
        {

            return View(50);
        }

        [HttpGet]
        public IActionResult Limit(int num)
        {

            return View("Index", num);
        }
    }
}
