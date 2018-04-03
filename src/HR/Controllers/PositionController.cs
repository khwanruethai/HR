using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class PositionController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult insertPosition(string emp_id, string position_id, string position_type, string position_comp, string position_sect, string position_dept) {

            emp_positionModel pos = new emp_positionModel();
            pos.pos_emp_id = emp_id;
            pos.pos_position_id = position_id;
            pos.pos_type = position_type;
            pos.pos_comp_id = position_comp;
            pos.pos_sect_id = position_sect;
            pos.pos_dept_id = position_dept;
            pos.insert_position();

            return RedirectToAction("emp","Employee",new { code = emp_id});
        }
        public string getdataForEdit(string id) {

            emp_positionModel post = new emp_positionModel();
            post.selectPositionById(id);
            
            return post.pos_position_id + "^" + post.pos_comp_id + "^" + post.pos_sect_id + "^" + post.pos_dept_id + "^" + post.pos_type + "^" + post.pos_start_date + "^" + post.pos_resign_date+"^"+post.pos_id;
        }
        [HttpPost]
        public IActionResult editPosition(string emp_id, string position_id, string position_edit, string section_edit, string type_edit, string start_edit, string company_edit, string end_edit, string deptEdit) {
            
            emp_positionModel pos = new emp_positionModel();
            pos.pos_emp_id = emp_id;
            pos.pos_id = position_id;
            
            pos.selectPositionById(position_id);
            pos.insert_positionLOG();


            pos.pos_position_id = position_edit;
            pos.pos_type = type_edit;
            pos.pos_comp_id = company_edit;
            pos.pos_sect_id = section_edit;
            pos.pos_dept_id = deptEdit;
           
            pos.pos_resign_date = end_edit;
            pos.pos_start_date = start_edit;
            pos.event_status = "U";

            pos.update_position();


            return RedirectToAction("emp","Employee",new { code=emp_id});
        }
        public void del_position(string id, string emp_id) {

            emp_positionModel pos = new emp_positionModel();
            pos.pos_emp_id = emp_id;
            pos.pos_id = id;

            pos.selectPositionById(id);
            pos.insert_positionLOG();

            
            pos.event_status = "D";

            pos.update_position();

        }
        public string change_main(string emp, string position) {

            emp_positionModel ps = new emp_positionModel();

        
            //old id
            ps.pos_emp_id = emp;
            ps.check_position_main();
            ps.selectPositionById(ps.pos_id);
            ps.insert_positionLOG();

            //update old to N
            ps.pos_active = "N";
            ps.update_position();

            //new id
            ps.pos_id = position;
            ps.selectPositionById(position);
            ps.insert_positionLOG();

            //update new to Y
            ps.pos_active = "Y";
            ps.update_position();



            return ps.pos_id;
        }
    }
}
