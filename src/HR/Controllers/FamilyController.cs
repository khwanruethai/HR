using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class FamilyController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult editFamily(string person_id, string dad_name, string dad_lastname, string dad_age, string dad_num, string dad_moo, string dad_province, string dad_amphur, string dad_district, string dad_postcode, string dad_tel, string dad_mobile, string mom_name, string mom_lastname, string mom_age, string mom_num, string mom_moo, string mom_province, string mom_amphur, string mom_district, string mom_postcode, string mom_tel, string mom_mobile, string mar_name, string mar_lastname, string mar_age, string mar_num, string mar_moo, string mar_province, string mar_amphur, string mar_district, string mar_postcode, string mar_tel, string mar_mobile) {

            personal_familyModel fm = new personal_familyModel();

            fm.selectFamilyPerson(person_id);
            fm.insertFamilyLOG();

            fm.fam_name_dad = dad_name;
            fm.fam_lastname_dad = dad_lastname;
            fm.fam_age_dad = dad_age;
            fm.fam_num_dad = dad_num;
            fm.fam_moo_dad = dad_moo;
            fm.fam_province_dad = dad_province;
            fm.fam_amphur_dad = dad_amphur;
            fm.fam_district_dad = dad_district;
            fm.fam_postcode_dad = dad_postcode;
            fm.fam_tel_dad = dad_tel;
            fm.fam_mobile_dad = dad_mobile;

            fm.fam_name_mom = mom_name;
            fm.fam_lastname_mom = mom_lastname;
            fm.fam_age_mom = mom_age;
            fm.fam_num_mom = mom_num;
            fm.fam_moo_mom = mom_moo;
            fm.fam_province_mom = mom_province;
            fm.fam_amphur_mom = mom_amphur;
            fm.fam_district_mom = mom_district;
            fm.fam_postcode_mom = mom_postcode;
            fm.fam_tel_mom = mom_tel;
            fm.fam_mobile_mom = mom_mobile;

            fm.fam_name_marry = mar_name;
            fm.fam_lastname_marry = mar_lastname;
            fm.fam_age_marry = mar_age;
            fm.fam_num_marry = mar_num;
            fm.fam_moo_marry = mar_moo;
            fm.fam_province_marry = mar_province;
            fm.fam_amphur_marry = mar_amphur;
            fm.fam_district_marry = mar_district;
            fm.fam_postcode_marry = mar_postcode;
            fm.fam_tel_marry = mar_tel;
            fm.fam_mobile_marry = mar_mobile;

            fm.updateFamily();

            return RedirectToAction("editPersonal","Personal",new { person = person_id });
        }
    }
}
