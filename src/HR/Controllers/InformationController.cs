using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class InformationController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult comp() {

            companyModel cp = new companyModel();
            ViewData["company"] = cp.list_comp();

            return View();
        }
        public IActionResult status()
        {
            info_statusModel st = new info_statusModel();
            ViewData["status"] = st.select_status();

            return View();
        }
        [HttpPost]
        public IActionResult insert_status(string status)
        {
            info_statusModel st = new info_statusModel();
         
            st.status_name = status;
            st.insert_status();

            ViewData["type"] = st.select_status();

            return RedirectToAction("status","Information");
        }
        public IActionResult typeEmp()
        {
            emp_typeModel type = new emp_typeModel();
            ViewData["type"] = type.select_type();

            return View();
        }
        public string getType(string type) {

            emp_typeModel tp = new emp_typeModel();
            tp.selecTypebyId(type);


            return tp.type_name;
        }
        [HttpPost]
        public IActionResult editType(string type_id, string type_edit) {

            emp_typeModel tp = new emp_typeModel();
            tp.selecTypebyId(type_id);

            tp.insertTypeLOG();
            tp.type_name = type_edit;
            tp.event_status = "U";
            tp.update_type();

            return RedirectToAction("typeEmp","Information");
        }
        
        [HttpPost]
        public IActionResult insert_typeEmp(string type)
        {
            emp_typeModel typ = new emp_typeModel();
            typ.type_name = type;
            typ.insert_type();
            
            ViewData["type"] = typ.select_type();

            return RedirectToAction("typeEmp","Information");
        }
        public void del_typeEmp(string id) {

            emp_typeModel tp = new emp_typeModel();
            tp.selecTypebyId(id);

            tp.insertTypeLOG();
            tp.event_status = "D";
            tp.update_type();

        }
        public List<info_departmentModel> testDept() {

            info_departmentModel dt = new info_departmentModel();

            return dt.list_dept();
        }
        public IActionResult position()
        {
            info_positionModel post = new info_positionModel();
            ViewData["tab_position"] = post.tablePosition();
            
            return View();
        }
        public IActionResult depart()
        {
            info_departmentModel post = new info_departmentModel();
            ViewData["tab_department"] = post.list_dept();

            return View();
        }
        [HttpPost]
        public IActionResult insertPosition(string position) {

            info_positionModel post = new info_positionModel();
            post.post_name = position;
            post.insertPosition();

            return RedirectToAction("position");
        }
        public string getData(string pos) {

            info_positionModel post = new info_positionModel();
            post.selectBYpost_id(pos);
            return post.post_id + "^" + post.post_name+"^"+post.post_submit_date;
        }
        [HttpPost]
        public IActionResult editPosition(string position_id, string position_edit) {

            info_positionModel ps = new info_positionModel();
            ps.selectBYpost_id(position_id);

            ps.insertPositionLOG();
            ps.post_name = position_edit;
            ps.event_status = "U";
            ps.updatePosition();

            return RedirectToAction("position","Information");
        }
        public void del_position(string id) {

            info_positionModel ps = new info_positionModel();
            ps.selectBYpost_id(id);

            ps.insertPositionLOG();
            ps.event_status = "D";

            ps.updatePosition();

        }
        public IActionResult income()
        {
            info_incomeModel inc = new info_incomeModel();
            ViewData["income"] = inc.select_income();
            return View();
        }
        [HttpPost]
        public IActionResult income(string income)
        {
            info_incomeModel inc = new info_incomeModel();
            inc.income_name = income;
            inc.insert_income();
            ViewData["income"] = inc.select_income();
            return View();
        }
        public string getIncome(string income) {

            info_incomeModel ic = new info_incomeModel();
            ic.selectincome_id(income);

            return ic.income_name;
        }
        [HttpPost]
        public IActionResult editIncome(string income_id , string income_edit) {

            info_incomeModel ic = new info_incomeModel();
            ic.selectincome_id(income_id);
            ic.insertIncomeLOG();
            ic.income_name = income_edit;
            ic.event_status = "U";
            ic.updateIncome();

            return RedirectToAction("income","Information");
        }
        public void del_income(string id) {

            info_incomeModel ic = new info_incomeModel();
            ic.selectincome_id(id);
            ic.insertIncomeLOG();
            ic.event_status = "D";
            ic.updateIncome();

        }

        public IActionResult cut()
        {
            info_minusModel minus = new info_minusModel();
            ViewData["minus"] = minus.select_minus();
            return View();
        }
        [HttpPost]
        public IActionResult cut(string cut)
        {
            info_minusModel minus = new info_minusModel();
            minus.minus_name = cut;
            minus.insert_minus();

            ViewData["minus"] = minus.select_minus();

            return View();
        }
        public string getMinus(string minus) {

            info_minusModel ms = new info_minusModel();
            ms.selectMinusId(minus);

            return ms.minus_name;
        }
        [HttpPost]
        public IActionResult editMinus(string minus_id, string minus_edit) {

            info_minusModel ms = new info_minusModel();

            ms.selectMinusId(minus_id);

            ms.insertMinusLOG();
            ms.minus_name = minus_edit;
            ms.event_status = "U";
            ms.updateMinus();

            return RedirectToAction("cut","Information");
        }
        public void del_minus(string id) {

            info_minusModel mn = new info_minusModel();
            mn.selectMinusId(id);
            mn.insertMinusLOG();
            mn.event_status = "D";
            mn.updateMinus();
        }
        public IActionResult calendar()
        {
            return View();
        }
        public IActionResult group()
        {
            return View();
        }
        public IActionResult fund()
        {
            info_fundModel fd = new info_fundModel();
            ViewData["fund"] = fd.select_fund();
            return View();
        }
        [HttpPost]
        public IActionResult insert_fund(string fund, string fund_code)
        {
            info_fundModel fd = new info_fundModel();
            fd.fund_code = fund_code;
            fd.fund_name = fund;
            fd.insert_fund();
            

            return RedirectToAction("fund","Information");
        }
        public string getFund(string fund) {

            info_fundModel fd = new info_fundModel();
            fd.selectFund_id(fund);
            
            return fd.fund_name +"^"+ fd.fund_code;
        }
        [HttpPost]
        public IActionResult editFund(string fund_id, string fund_edit, string fund_code_edit) {

            info_fundModel fd = new info_fundModel();
            fd.selectFund_id(fund_id);
            fd.insertFundLOG();

            fd.fund_code = fund_code_edit;
            fd.fund_name = fund_edit;
            fd.event_status = "U";
            fd.updateFund();

            return RedirectToAction("fund","Information");
        }
        public string fundCode(string id) {

            info_fundModel fn = new info_fundModel();
            fn.fund_code = id;
            fn.check_code_fund();

            return fn.check;
        }
        public IActionResult department()
        {
            departmentModel dp = new departmentModel();

           // ViewData["dept_tb"] = dp.list_dept();

            return View();
        }
        public IActionResult dept()
        {
            info_departmentModel dp = new info_departmentModel();

          ViewData["dept_tb"] = dp.list_dept();

            return View();
        }
        public IActionResult sect() {

            sectionModel st = new sectionModel();

            ViewData["section_tb"] = st.sect();

            return View();
        }
        public IActionResult prefix()
        {
            info_prefixModels prefix = new info_prefixModels();
            ViewData["prefix"] = prefix.select_prefix();
            return View();
        }
        [HttpPost]
        public IActionResult insert_prefix(string prefix_th, string prefix_en) {

            info_prefixModels prefix = new info_prefixModels();
            ViewData["prefix"] = prefix.select_prefix();
            prefix.name_th = prefix_th;
            prefix.name_en = prefix_en;
            prefix.submit_date = DateTime.Now.ToString();
            prefix.admin_id = "1";
            prefix.insert_prefix();
            
            ViewBag.message = "บันทึกข้อมูลเรียบร้อยแล้ว!";

            return RedirectToAction("prefix","Information");
        }
    }
}
