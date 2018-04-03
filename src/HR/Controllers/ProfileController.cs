using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class ProfileController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult InsertProfile(string gender, string age, string nationality, string race, string religion, string blood, string birthday, string identification, string date_issue, string expired_date, string weigth, string height, string marital, string child, string emp_id) {

            emp_profileModel profile = new emp_profileModel();
            profile.profile_gender = gender;
            profile.profile_age = age;
            profile.profile_nationality = nationality;
            profile.profile_race = race;
            profile.profile_religion = religion;
            profile.profile_blood = blood;
            profile.profile_birthday = birthday;
            profile.profile_identification = identification;
            profile.profile_date_issue = date_issue;
            profile.profile_expired_date = expired_date;
            profile.profile_weight = weigth;
            profile.profile_height = height;
            profile.profile_marital_status = marital;
            profile.profile_child_num = child;
            profile.profile_emp_id = emp_id;

            profile.insert_profile();


            return RedirectToAction("employee","Employee",new { code=emp_id});
        }
        public string selectProfile(string emp) {

            emp_profileModel profile = new emp_profileModel();

            return profile.select_profile(emp);
        }
    }
}
