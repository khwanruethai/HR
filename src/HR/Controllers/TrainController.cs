using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class TrainController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addTrain(string person_id, IEnumerable<string> t_title, IEnumerable<string> t_location, IEnumerable<string> t_start, IEnumerable<string> t_end) {

            personal_trainModel tr = new personal_trainModel();

            int len = t_title.Count();
            List<string> title = new List<string>();
            List<string> location = new List<string>();
            List<string> start = new List<string>();
            List<string> end = new List<string>();

            foreach (var txt in t_title) {

                title.Add(txt);
            }

            foreach (var txt in t_location) {

                location.Add(txt);
            }

            foreach (var txt in t_start) {

                start.Add(txt);
            }

            foreach (var txt in t_end) {

                end.Add(txt);
            }

            for (int i = 0; i < len; i++)
            {

                tr.train_ref_personal_id = person_id;
                tr.train_title = title[i];
                tr.train_location = location[i];
                tr.train_start = start[i];
                tr.train_end = end[i];

                tr.insertTrain();

            }

           

            return RedirectToAction("editPersonal","Personal",new { person = person_id});
        }
        [HttpPost]
        public IActionResult editTrain(string person_id, string tr_id, string tr_title, string tr_location, string tr_start, string tr_end) {

            personal_trainModel t = new personal_trainModel();

            t.select_form_train(tr_id);
            t.insertTrainLOG();

            t.train_id = tr_id;
            t.train_title = tr_title;
            t.train_location = tr_location;
            t.train_start = tr_start;
            t.train_end = tr_end;

            t.updateTrain();
            
            return RedirectToAction("editPersonal", "Personal", new { person = person_id });
        }
    }
}
