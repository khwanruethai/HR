using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;
using System.Data.SqlClient;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class MinusController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult insertMS(string emp_id, IEnumerable<string> txtms_amount, IEnumerable<string> minus_id, string minus_start, string minus_end) {
            
            var minusAndamount = minus_id.Zip(txtms_amount, (n, a) => new { minus = n, amount = a });

            emp_minusSalaryModel ms = new emp_minusSalaryModel();
            string str = "";
            foreach (var na in minusAndamount) {

                ms.ms_ref_minus_id = na.minus;
                ms.ms_amount = na.amount;
                ms.ms_ref_emp_id = emp_id;
                ms.ms_start_date = minus_start;
                ms.ms_end_date = minus_end;
                str += na.minus;
                ms.insertMinusSqlary();

            }

            return RedirectToAction("emp","Employee",new { code=emp_id });
        }
        public string data_update(string minus) {

            emp_minusSalaryModel ms = new emp_minusSalaryModel();
            
            return ms.dataForUpdate(minus);
        }
        public string getdata(string start, string end, string emp)
        {

            emp_minusSalaryModel pay = new emp_minusSalaryModel();

            return pay.getMinus(start, end, emp);
        }
        [HttpPost]
        public IActionResult edit_minus(string emp_id, string minusId, string minus_edit, string amountMinus) {

            emp_minusSalaryModel emp = new emp_minusSalaryModel();

            emp.dataForUpdate(minusId);
            emp.insertMinusSqlaryLOG();

            emp.ms_ref_emp_id = emp_id;
            emp.ms_ref_minus_id = minus_edit;
            emp.ms_id = minusId;
            emp.ms_amount = amountMinus;


            emp.insertMinusSqlary_edit();

            return RedirectToAction("emp","Employee",new { code = emp_id});
        }
        public void del_Minus(string id)
        {

            emp_minusSalaryModel ms = new emp_minusSalaryModel();

            ms.dataForUpdate(id);
            ms.insertMinusSqlaryLOG();

            ms.ms_id = id;
            ms.ms_end_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ms.ms_status = "N";
            ms.event_status = "D";
            ms.insertMinusSqlary_edit();
            
        }
    }
}
