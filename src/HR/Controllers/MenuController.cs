using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class MenuController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public void menu(string id) {
            HttpContext.Session.SetString("menuClick", "menu"+id);
        }
        public void empTab(string tab) {

            HttpContext.Session.SetString("empTab",tab);
        }
        public void liAction(string id) {

            HttpContext.Session.SetString("liClick", "li" + id);

        }
    }
}
