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
    public class PayController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult InsertPay(string emp_id, IEnumerable<string> test, IEnumerable<string> pay, IEnumerable<string> income_id, string money_start, string money_end) {

            emp_payModel income = new emp_payModel();
            info_incomeModel check = new info_incomeModel();
            emp_actionModel act = new emp_actionModel();
            empModel emp = new empModel();

            string str = "";
            var idAndpay = income_id.Zip(pay, (n, w) => new { id_income = n, pay_money = w });
            
            foreach (var nw in idAndpay)
            {
                income.pay_ref_income_id = nw.id_income;
                income.pay_amount = nw.pay_money;
                income.pay_ref_emp_id = emp_id;
                income.pay_start_date = money_start;
                income.pay_end_date = money_end;
                income.insert_pay();

                if (check.check_income(nw.id_income) == "เงินเดือน")
                {
                    act.emp_salary = nw.pay_money;
                    act.emp_code = emp.empCode(emp_id);
                    act.update_salary();

                }
                else if (check.check_income(nw.id_income) == "ค่าครองชีพ")
                {

                    act.emp_stipend = nw.pay_money;
                    act.emp_code = emp.empCode(emp_id);
                    act.update_stipend();

                }
                else {

                }
               // str += income.pay_ref_income_id +income.pay_amount;
            }
            
            return RedirectToAction("emp","Employee", new { code=emp_id});
        }
      
        public string data_update(string pay) {

            emp_payModel pay_income = new emp_payModel();
            
            return pay_income.dataForUpdate(pay);
        }
        public string getdata(string start, string end, string emp) {

            emp_payModel pay = new emp_payModel();

            return pay.getPay(start, end, emp);
        }

        [HttpPost]
        public IActionResult editPay(string emp_id, string pay_id, string income_edit, string amount_update) {

            emp_payModel p = new emp_payModel();

            p.dataForUpdate(pay_id);
            p.insert_payLOG();

            p.pay_id = pay_id;
            p.pay_ref_income_id = income_edit;
            p.pay_amount = amount_update;
            p.update_pay();

            return RedirectToAction("emp","Employee",new { code=emp_id});
        }
        public void del_Pay(string id) {

            emp_payModel ep = new emp_payModel();

            ep.dataForUpdate(id);

            ep.insert_payLOG();

            ep.pay_id = id;
            ep.pay_end_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ep.pay_status = "N";
            ep.event_status = "D";
            ep.update_pay();


        }
        
    }
}
