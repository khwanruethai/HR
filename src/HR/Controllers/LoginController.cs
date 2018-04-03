using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class LoginController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            LoginModel lg = new LoginModel();

           
            return View();
        }
        [HttpPost]
        public IActionResult login(string username, string password) {

            LoginModel lg = new LoginModel();

            lg.username = username;
            lg.password = password;

            lg.loginAccount();

          

            return RedirectToAction(lg.action,lg.controll);
        }
        public IActionResult logout() {

            HttpContext.Session.Clear();
            return RedirectToAction("Index","Login");
        }
    }
}
