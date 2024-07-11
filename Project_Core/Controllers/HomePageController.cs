using Microsoft.AspNetCore.Mvc;

namespace Project_Core.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult HIndex()
        {
            return View();
        }
    }
}
