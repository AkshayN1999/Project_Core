using Microsoft.AspNetCore.Mvc;
using Project_Core.Models;

namespace Project_Core.Controllers
{
    public class MainController : Controller
    {
        DBClass dbobj = new DBClass();
        public IActionResult Main_Load(BookTabs objcls)
        {
            List<BookTabs> getlist = dbobj.BookDB(objcls);
            return View(getlist);
        }
    }
}
