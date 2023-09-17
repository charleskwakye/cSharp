using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        
        public string Welcome()
        {
            return"This is the welcome action method...";
        }

        public string WelcomeUser(string name,int id=1)
        {
            return $"Hello {name},Numtimes is:{id}";
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
