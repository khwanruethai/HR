using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class CommendController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult insertCommend(string commend_date, string title, string etc, string emp_id) {

            emp_commendModel comm = new emp_commendModel();
            comm.comm_date = commend_date;
            comm.comm_title = title;
            comm.comm_detail = etc;
            comm.comm_ref_emp_id = emp_id;
            comm.insertCommend();

            return RedirectToAction("emp","Employee",new { code = emp_id});
        }
        public string dataForEdit(string comm) {

            emp_commendModel commd = new emp_commendModel();

            return commd.selectBycommId(comm);

        }
        [HttpPost]
        public IActionResult editCommend(string emp_id, string comm_id_edit, string comm_date_edit, string comm_title_edit, string comm_detail_edit) {

            emp_commendModel com = new emp_commendModel();

            com.selectBycommId(comm_id_edit);
            com.insertCommendLOG();

            com.comm_date = comm_date_edit;
            com.comm_title = comm_title_edit;
            com.comm_detail = comm_detail_edit;
            com.comm_id = comm_id_edit;

            com.updateCommend();


            return RedirectToAction("emp","Employee",new { code = emp_id});
        }
    }
}
