using Microsoft.AspNetCore.Mvc;
using Project_Core.Models;

namespace Project_Core.Controllers
{
    public class InsertController : Controller
    {
        DBClass dbobj = new DBClass();
        public IActionResult Insert_Load()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert_Click(Registeration objcls)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = dbobj.InsertDB(objcls);
                    TempData["msg"] = resp;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View("Insert_Load",objcls);
        }
    }
}
