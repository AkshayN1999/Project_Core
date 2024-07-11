using Microsoft.AspNetCore.Mvc;
using Project_Core.Models;

namespace Project_Core.Controllers
{
    public class LoginController : Controller
    {
        DBClass db = new DBClass();
        public IActionResult Login_Load()
        {
            return View();
        }
        public IActionResult Login_Click(Registeration objcls)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = db.LoginDB(objcls);
                    TempData["msg"] = resp;
                    if (resp == "Success")
                    {
 
                        return RedirectToAction("Main_Load", "Main");
                    }
                    else
                    {
                        TempData["msg2"] = resp;
                        return View("Login_Load");
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View("Login_Load");
        }
    }
}
