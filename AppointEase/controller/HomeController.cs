using Microsoft.AspNetCore.Mvc;

namespace AppointEase.controller
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
