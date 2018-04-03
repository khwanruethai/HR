using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class EmpResignController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult insert_resign(string emp, string emp_resign_date, string type, string detail) {


            empModel em = new empModel();
            em.select_emp(emp);
            em.insertEmpLOG();
            //
            emp_resignModel rs = new emp_resignModel();
            rs.re_ref_emp_id = emp;
            rs.re_emp_code = em.empCode(emp);
            rs.re_resign_date = emp_resign_date;
            rs.re_type = type;
            rs.re_detail = detail;

            rs.insert_resign();

            //

            em.ep_end = emp_resign_date;
            em.ep_status = "N";
            em.event_status = "U";
            em.update_emp();

            

            return RedirectToAction("resign","Employee");
        }
        [HttpPost]
        public IActionResult update_resign(string emp, string emp_resign_date, string type, string detail, string re_id, string emp_id) {

            DateTime dt = new DateTime(3000,01,01);

            empModel em = new empModel();
            em.select_emp(emp);
            em.insertEmpLOG();


            emp_resignModel rs = new emp_resignModel();
            //


            if (emp != emp_id)
            {

                //select and insertLog for resignold
                rs.re_id = re_id;
                rs.select_resign();
                rs.insert_resignLOG();

                //update event status to delete
                rs.event_status = "D";
                rs.update_resign();


                //insert resign new
                rs.re_ref_emp_id = emp;
                rs.re_emp_code = em.empCode(emp);
                rs.re_resign_date = emp_resign_date;
                rs.re_type = type;
                rs.re_detail = detail;

                rs.insert_resign();

                // update status emp new
                em.ep_end = emp_resign_date;
                em.ep_status = "N";
                em.event_status = "U";
                em.update_emp();

                //select emp old and insert log
                em.select_emp(emp_id);
                em.insertEmpLOG();

                //update emp old to status Y 
                em.ep_end = Convert.ToDateTime(dt).ToString("yyyy-MM-dd");
                em.ep_status = "Y";
                em.event_status = "U";
                em.update_emp();
                

            }
            else {

                rs.re_id = re_id;
                rs.select_resign();
                rs.insert_resignLOG();

                rs.re_type = type;
                rs.re_resign_date = emp_resign_date;
                rs.re_detail = detail;
                rs.event_status = "U";
                rs.update_resign();

                // update event status
                em.ep_end = emp_resign_date;
                em.event_status = "U";
                em.update_emp();

            }



            return RedirectToAction("resign", "Employee");
        }
        public void del_resign(string id) {

            DateTime dt = new DateTime(3000, 01, 01);

            // select & insert LOG resign
            emp_resignModel rs = new emp_resignModel();
            rs.re_id = id;
            rs.select_resign();
            rs.insert_resignLOG();
           
            ///
            //select and insert LOG emp
            empModel em = new empModel();
            em.select_emp(rs.re_ref_emp_id);
            em.insertEmpLOG();

            ///update event status to DELETE
            
            rs.event_status = "D";
            rs.update_resign();

            // update event status emp to Y 
            em.ep_end = Convert.ToDateTime(dt).ToString("yyyy-MM-dd");
            em.ep_status = "Y";
            em.event_status = "U";
            em.update_emp();


        }
    }
}
