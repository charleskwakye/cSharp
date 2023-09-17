using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models;
using System.Diagnostics;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly StoreContext _context;

        private readonly ILogger<HomeController> _logger;
        public HomeController(StoreContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }



        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            var covers = _context.Albums.OrderBy(a => Guid.NewGuid()).Take(6);
            return View(covers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}