using Microsoft.AspNetCore.Mvc;

namespace MovieStoreMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
