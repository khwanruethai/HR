using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class PrefixController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public string getPrefix(string prefix) {

            info_prefixModels px = new info_prefixModels();
            px.selectPerfixbyId(prefix);


            return px.name_th + "^" + px.name_en;
        }
        [HttpPost]
        public IActionResult editPrefix(string prefix_id, string prefix_th_edit, string prefix_en_edit) {

            info_prefixModels px = new info_prefixModels();

            px.selectPerfixbyId(prefix_id);
            px.insertPrefixLOG();

            px.event_status = "U";
            px.name_th = prefix_th_edit;
            px.name_en = prefix_en_edit;
            px.prefix_id = prefix_id;

            px.update_prefix();

            return RedirectToAction("prefix","Information");
        }
        public void del_prefix(string id) {

            info_prefixModels px = new info_prefixModels();

            px.selectPerfixbyId(id);
            px.insertPrefixLOG();

            px.event_status = "D";
            px.prefix_id = id;

            px.update_prefix();

        }
    }
}
