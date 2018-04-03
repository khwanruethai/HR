using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class EmpPositionResignController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult insert_position_resign(string emp_id, string prs_type, string prs_detail, string prs_date_resign, string prs_ref_emp_position_id) {


            emp_positionModel ps = new emp_positionModel();
            ps.selectPositionById(prs_ref_emp_position_id);
            ps.insert_positionLOG();


            EmpPositionResignModel prs = new EmpPositionResignModel();
            prs.prs_ref_emp_posit_id = prs_ref_emp_position_id;
            prs.prs_ref_emp_id = emp_id;
            prs.prs_position_id = ps.pos_position_id;
            prs.prs_comp_id = ps.pos_comp_id;
            prs.prs_section_id = ps.pos_sect_id;
            prs.prs_dept_id = ps.pos_dept_id;
            prs.prs_type = ps.pos_type;
            prs.prs_start_date = ps.pos_start_date;
            prs.prs_resign_date = prs_date_resign;
            prs.prs_resign_type = prs_type;
            prs.prs_resign_detail = prs_detail;
            prs.insert_resign_position();

            ps.pos_id = prs_ref_emp_position_id;
            ps.pos_resign_date = prs_date_resign;
            ps.event_status = "U";
            ps.pos_status = "N";
            ps.update_position();
           

            return RedirectToAction("emp","Employee",new { code = emp_id});
        }
    }
}
