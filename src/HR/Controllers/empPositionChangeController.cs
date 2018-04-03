using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class empPositionChangeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult insert_position_change(string position_ch, string company_ch, string section_ch, string dept_ch, string type_ch, string start_ch, string position_id_ch, string emp_id) {

            DateTime dt = new DateTime(3000,01,01);

            emp_positionModel pos = new emp_positionModel();
            pos.pos_emp_id = emp_id;
            pos.pos_id = position_id_ch;

            pos.selectPositionById(position_id_ch);
            pos.insert_positionLOG();

        
            pos.event_status = "U";
            pos.pos_resign_date = Convert.ToDateTime(start_ch).ToString("yyyy-MM-dd");
            pos.pos_start_date = start_ch;

            pos.update_position();
            
            ///

            pos.pos_emp_id = emp_id;
            pos.pos_position_id = position_ch;
            pos.pos_type = type_ch;
            pos.pos_comp_id = company_ch;
            pos.pos_sect_id = section_ch;
            pos.pos_dept_id = dept_ch;
            pos.pos_start_date = start_ch;
            pos.pos_resign_date = Convert.ToDateTime(dt).ToString("yyyy-MM-dd");
            pos.insert_position();


            empPositionChangeModel pc = new empPositionChangeModel();

            pc.pc_emp_id = emp_id;
            pc.pc_comp_id = company_ch;
            pc.pc_sect_id = section_ch;
            pc.pc_dept_id = dept_ch;
            
            pc.pc_position_id = position_ch;
            pc.pc_type = type_ch;
            pc.pc_start_date = start_ch;
            pc.pc_admin_id = "1";
            pc.pc_status = "Y";
            pc.pc_active ="Y";
            pc.event_status = "S";
            pc.pc_position_id_old = pos.pos_position_id;
            pc.pc_company_old = pos.pos_comp_id;
            pc.pc_section_old = pos.pos_sect_id;
            pc.pc_dept_old = pos.pos_dept_id;
            pc.pc_type_old = pos.pos_type;
            pc.pc_start_old = pos.pos_start_date;
            pc.pc_end_old = pos.pos_resign_date;
            pc.pc_ref_emp_position_id = position_id_ch;
        
            pc.insert_position_chane();



         



            return RedirectToAction("emp", "Employee", new { code = emp_id  });
        }
       
    }
}
