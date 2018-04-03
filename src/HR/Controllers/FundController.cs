using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class FundController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult insertFundRegis(string emp_id, IEnumerable<string> fundId, IEnumerable<string> dateFundStart) {

            emp_fundRegisModel fr = new emp_fundRegisModel();

            var fundAndDate = fundId.Zip(dateFundStart, (f, d) => new { fund = f, date = d });

            foreach (var fd in fundAndDate)
            {
                fr.fr_ref_emp_id = emp_id;
                fr.fr_ref_fund_id = fd.fund;
                fr.fr_date_start = fd.date;
                fr.insertFundRegis();
            }

            return RedirectToAction("emp", "Employee", new { code=emp_id});
        }
        public string dataFund(string id) {

            emp_fundRegisModel f = new emp_fundRegisModel();

            return f.select_dataFund(id);
        }
        [HttpPost]
        public IActionResult editFund(string emp_id, string fund_id, string fund_name, string fund_date) {

            emp_fundRegisModel fn = new emp_fundRegisModel();

            fn.select_dataFund(fund_id);
            fn.insertFundLOG();

            fn.fr_id = fund_id;
            fn.fr_ref_fund_id = fund_name;
            fn.fr_date_start = fund_date;

            fn.updateFund();

            return RedirectToAction("emp", "Employee", new { code = emp_id });
        }
        public void del_fund(string id) {

            info_fundModel fd = new info_fundModel();
            fd.selectFund_id(id);
            fd.insertFundLOG();

            fd.event_status = "D";
            fd.fund_id = id;
            fd.updateFund();
        }
        public IActionResult resignFund() {

            empFundResign fn = new empFundResign();
            ViewData["fundResign"] = fn.list_fundResign();
            
            return View();
        }
        public IActionResult addResignFund()
        {
            empModel emp = new empModel();
            ViewData["emp"] = emp.drop_emp_Fund();

            info_fundModel fn = new info_fundModel();
            ViewData["fund"] = fn.dropdownFund();

            return View();
        }
        public string optionFund(string id) {

            info_fundModel fn = new info_fundModel();

            return fn.fundRefEmp(id,""); ;
        }
        public string detailFund(string id) {

            emp_fundRegisModel fn = new emp_fundRegisModel();
            fn.select_dataFund(id);

            int day = Convert.ToInt32(( DateTime.Now - Convert.ToDateTime(fn.fr_date_start)).TotalDays);
            int year = (DateTime.Now.Year - Convert.ToDateTime(fn.fr_date_start).Year);

            info_fundModel f = new info_fundModel();
            

            return fn.fr_date_start + "^" +year+"^"+day+"^"+f.fundForChange(fn.fr_ref_fund_id, fn.fr_ref_emp_id);
        }
        [HttpPost]
        public IActionResult insert_fundResign(string emp, string fund,string fund_resign_date, string type, string fund_datail) {

            emp_fundRegisModel fn = new emp_fundRegisModel();
            fn.select_dataFund(fund);
            fn.insertFundLOG();
            
            empFundResign fnr = new empFundResign();
            fnr.fnr_ref_fundRegis_id = fund;
            fnr.fnr_ref_fund_id = fn.fr_ref_fund_id;
            fnr.fnr_ref_emp_id = emp;
            fnr.fnr_start_date = fn.fr_date_start;
            fnr.fnr_resign_date = fund_resign_date;
            fnr.fnr_type_resign = type;
            fnr.fnr_detail_resign = fund_datail;
            fnr.insert_fund_resign();

            //
            fn.fr_id = fund;
            fn.event_status = "U";
            fn.fr_status = "N";
            fn.fr_date_end = fund_resign_date;
            fn.updateFund();


            return RedirectToAction("resignFund","Fund",new { fr =  fnr.fnr_ref_fundRegis_id, fn = fnr.fnr_ref_fund_id,emp = fnr.fnr_ref_emp_id, st= fnr.fnr_start_date, rs = fnr.fnr_resign_date, tp= fnr.fnr_type_resign, dt = fnr.fnr_detail_resign });
        }
        ///change
        ///
        public IActionResult changeFund() {

            empFundChange fn = new empFundChange();
            ViewData["changeFund"] = fn.list_fundChange();

            return View();
        }
        public IActionResult addResignChange() {


            empModel emp = new empModel();
            ViewData["emp"] = emp.drop_emp_Fund();

            info_fundModel fn = new info_fundModel();
            ViewData["fund"] = fn.dropdownFund();

            
            return View();
        }
        [HttpPost]
        public IActionResult insert_fundChange(string emp, string fund, string fund_age_day, string fund_new, string fund_change_date, string type) {

            emp_fundRegisModel fn = new emp_fundRegisModel();
            fn.select_dataFund(fund);
            fn.insertFundLOG();
            
            empFundChange cf = new empFundChange();
            cf.cf_fund_regis_id = fund;
            cf.cf_fund_id_old = fn.fr_ref_fund_id;
            cf.cf_fund_start_old = fn.fr_date_start;
            cf.cf_fund_id_new = fund_new;
            cf.cf_fund_start_new = fund_change_date;
            cf.cf_fund_age_old = fund_age_day;
            cf.cf_ref_emp_id = emp;
            cf.cf_change_type = type;


            cf.insert_fund_Change();

            fn.fr_ref_fund_id = fund_new;
            fn.fr_date_start = fund_change_date;
            fn.event_status = "U";
            fn.updateFund();


            return RedirectToAction("changeFund", "Fund");
        }
        public string data_fund_new(string id) {


            info_fundModel fn = new info_fundModel();
            fn.selectFund_id(id);

            return fn.fund_code + "^" + fn.fund_name;
        }
    }
}
