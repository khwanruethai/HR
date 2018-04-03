using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class KidController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addKid(string kid_num, string person_id, IEnumerable<string> kid_name, IEnumerable<string> kid_lastname, IEnumerable<string> kid_age, IEnumerable<string> kid_status, IEnumerable<string> kid_level, IEnumerable<string> kid_school) {

            personal_kidModel kid = new personal_kidModel();

            List<string> name = new List<string>();
            List<string> lastname = new List<string>();
            List<string> age = new List<string>();
            List<string> status = new List<string>();
            List<string> level = new List<string>();
            List<string> school = new List<string>();
            string txt_s = "";

            foreach (var txt in kid_name) {

                name.Add(txt);
            }

            foreach (var txt in kid_lastname) {

                lastname.Add(txt);
            }

            foreach (var txt in kid_age) {

                age.Add(txt);
            }

            for (int i = 0; i < Convert.ToInt32(kid_num); i++) {
                
                status.Add(Request.Form["kid_status"+i]);

            }

            foreach (var txt in kid_level) {

                level.Add(txt);
            }

            foreach (var txt in kid_school){

                school.Add(txt);
            }


            for (int i = 0; i < Convert.ToInt32(kid_num); i++) {

                kid.kid_name = name[i];
                kid.kid_lastname = lastname[i];
                kid.kid_age = age[i];
                kid.kid_study_status = status[i];
                kid.kid_study_level = level[i];
                kid.kid_study_school = school[i];
                kid.kid_ref_personal_id = person_id;

                kid.insertKid();

            }
            

            return RedirectToAction("editPersonal","Personal",new { person = person_id});
        }
        [HttpPost]
        public IActionResult editKid(string person_id, string k_id, string k_name, string k_lastname, string k_age, string num_i, string k_level, string k_school) {

            string status = Request.Form["study_" + num_i];

            personal_kidModel kid = new personal_kidModel();

            kid.kid_ref_personal_id = person_id;

            kid.select_from_kidId(k_id);
            kid.insertKidLOG();

            kid.kid_name = k_name;
            kid.kid_lastname = k_lastname;
            kid.kid_age = k_age;
            kid.kid_study_status = status;
            kid.kid_study_level = k_level;
            kid.kid_study_school = k_school;

            kid.updateKid();
            
            return RedirectToAction("editPersonal","Personal",new { person = person_id });

            }
    }
}
