using Microsoft.AspNetCore.Mvc;

namespace MyName.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Project()
        {
            return View();
        }

        public IActionResult MyName()
        {
            return View();
        }
    }
}
