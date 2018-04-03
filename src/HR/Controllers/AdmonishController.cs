using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class AdmonishController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult insertAdmonish(string admonish_date, string title, string etc, string emp_id)
        {

            emp_admonishModel adm = new emp_admonishModel();
            adm.adm_date = admonish_date;
            adm.adm_title = title;
            adm.adm_detail = etc;
            adm.adm_ref_emp_id = emp_id;
            adm.insertAdmonish();

            return RedirectToAction("emp", "Employee", new { code = emp_id });
        }
        public string dataForEdit(string adm)
        {

            emp_admonishModel admn = new emp_admonishModel();

            return admn.selectByadmId(adm);

        }
        [HttpPost]
        public IActionResult editAdm(string emp_id, string adm_id_edit, string adm_date_edit, string adm_title_edit, string adm_detail_edit) {

            emp_admonishModel ad = new emp_admonishModel();

            ad.selectByadmId(adm_id_edit);
            ad.insertAdmLOG();

            ad.adm_id = adm_id_edit;
            ad.adm_date = adm_date_edit;
            ad.adm_title = adm_title_edit;
            ad.adm_detail = adm_detail_edit;

            ad.updateAdm();

            return RedirectToAction("emp", "Employee", new { code = emp_id });
        }
    }
}
