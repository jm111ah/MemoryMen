using Dapper;
using Microsoft.AspNetCore.Mvc;
using MyName.Interface;
using System.Data;

namespace MyName.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, IDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Project()
        {
            using (IDbConnection db = _dbContext.GetConnection())
            {
                
            }

            return View();
        }

        public IActionResult MyName()
        {
            return View();
        }
    }
}
