using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class WorkController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addWork(string person_id, IEnumerable<string> w_company, IEnumerable<string> w_position, IEnumerable<string> w_address, IEnumerable<string> w_start, IEnumerable<string> w_end) {

            personal_workModel w = new personal_workModel();

            int len = w_company.Count();
            List<string> comp = new List<string>();
            List<string> posit = new List<string>();
            List<string> adds = new List<string>();
            List<string> start = new List<string>();
            List<string> end = new List<string>();

            foreach (var txt in w_company) {

                comp.Add(txt);
            }

            foreach (var txt in w_position) {

                posit.Add(txt);
            }

            foreach (var txt in w_address) {

                adds.Add(txt);
            }

            foreach (var txt in w_start) {

                start.Add(txt);
            }

            foreach (var txt in w_end) {

                end.Add(txt);
            }


            for (int i = 0; i < len; i++) {

                w.work_ref_personal_id = person_id;
                w.work_company = comp[i];
                w.work_position = posit[i];
                w.work_address = adds[i];
                w.work_start = start[i];
                w.work_end = end[i];

                w.insertWork();

            }


            return RedirectToAction("editPersonal","Personal",new { person = person_id});
        }
        [HttpPost]
        public IActionResult editWork(string person_id, string wk_id, string wk_company, string wk_position,string wk_address, string wk_start, string wk_end) {

            personal_workModel w = new personal_workModel();

            w.select_form_workId(wk_id);
            w.insertWorkLOG();

            w.work_company = wk_company;
            w.work_position = wk_position;
            w.work_address = wk_address;
            w.work_start = wk_start;
            w.work_end = wk_end;

            w.updateWork();

            return RedirectToAction("editPersonal", "Personal", new { person = person_id });
        }
    }
}
