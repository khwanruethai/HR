using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class EmployeeController : Controller
    {
        public string code_test { get; set; }
     
        // GET: /<controller>/
        public IActionResult Index()
        {
            info_prefixModels prefix = new info_prefixModels();
            info_statusModel status = new info_statusModel();
            emp_typeModel type = new emp_typeModel();
            personalModel ps = new personalModel();
            info_positionModel posi = new info_positionModel();
            companyModel comp = new companyModel();
            sectionModel sect = new sectionModel();
            departmentModel dep = new departmentModel();
            view_employeeModel emp = new view_employeeModel();
            

            ViewData["prefix_th"] = prefix.select_prefixTH();
            ViewData["prefix_en"] = prefix.select_prefixEN();
            ViewData["type"] = type.dropdown_type();
            ViewData["status"] = status.dropdown_status();
            ViewData["national_id"] = ps.national();
            ViewData["personal_name"] = ps.personal();
            ViewData["position"] = posi.dropDownPosition();
            ViewData["company"] = comp.drop_company();
            ViewData["section"] = sect.drop_section();
            ViewData["department"] = dep.drop_dep();
            ViewData["emp_data"] = emp.emp_data();
            ViewData["option_position"] = posi.positionList();
            ViewData["option_department"] = dep.deptList();
            ViewData["option_section"] = sect.sectList();
            ViewData["option_company"] = comp.compList();
            ViewData["option_status"] = status.statusList();
            ViewData["option_type"] = type.typeList();

            HttpContext.Session.SetString("empTab", "");

            return View();
        }
        public IActionResult emp(string code, string txt) {

            code_test = code;
            personalModel ps = new personalModel();

            ViewData["person_edit"] =  ps.personal_for_edit();

            info_positionModel posi = new info_positionModel();
            companyModel comp = new companyModel();
            sectionModel sect = new sectionModel();
            departmentModel dep = new departmentModel();
            emp_typeModel type = new emp_typeModel();
            ViewData["position_dropdown"] = posi.dropDownPosition();
            ViewData["company"] = comp.drop_company();
            ViewData["section"] = sect.drop_section();
            ViewData["department"] = dep.drop_dep();
            ViewData["type"] = type.dropdown_type();


            info_prefixModels prefix = new info_prefixModels();
            info_statusModel status = new info_statusModel();
            personal_studyModel study = new personal_studyModel();
            
            ViewData["prefix_th"] = prefix.select_prefixTH();
            ViewData["prefix_en"] = prefix.select_prefixEN();
            ViewData["type_emp"] = type.dropdown_type();
            ViewData["status"] = status.dropdown_status();


            //view employee//
            view_employeeModel emp = new view_employeeModel();

            emp.selectData(code);

            ViewData["emp_id"] = code;
            ViewData["emp_code"] = emp.ep_code;
            ViewData["emp_name_th"] = emp.prefix_name_en + " " + emp.ps_name_th + " " + emp.ps_lastname_th;
            ViewData["emp_name_en"] = emp.prefix_name_en + " " + emp.ps_name_en + " " + emp.ps_lastname_en;
            ViewData["emp_type"] = emp.type_name;
            ViewData["emp_status"] = emp.ep_status;
            ViewData["emp_start_date"] = emp.ep_start;
            ViewData["emp_end_date"] = emp.ep_end;
            ViewData["emp_email"] = emp.contact_email;
            ViewData["emp_table"] = emp.contact_table;
            ViewData["emp_phone"] = emp.contact_phone;
            ViewData["emp_mobile1"] = emp.contact_mobile1;
            ViewData["emp_mobile2"] = emp.contact_mobile2;
            ViewData["position_name"] = emp.post_name;
            ViewData["position_type"] = emp.type_name;
            ViewData["position_dept"] = emp.dept_name;
            ViewData["position_sect"] = emp.Section_name;
            ViewData["position_comp"] = emp.T_Company;
            ViewData["gender"] = emp.ps_gender;
            ViewData["age"] = Convert.ToInt32((DateTime.Now.Year))- Convert.ToInt32((Convert.ToDateTime(emp.ps_birthday).Year));
            ViewData["nationality"] = emp.ps_nationality;
            ViewData["race"] = emp.ps_race;
            ViewData["religion"] = emp.ps_religion;
            ViewData["blood"] = emp.ps_blood;
            ViewData["birthday"] = Convert.ToDateTime(emp.ps_birthday).ToString("dd MMMM yyyy");
            ViewData["birthday_format"] = Convert.ToDateTime(emp.ps_birthday).ToString("dd/MM/yyyy");
            ViewData["identification"] =  emp.ps_national_id;
            ViewData["date_issue"] = emp.ps_national_date_start;
            ViewData["expired_date"] = emp.ps_national_date_end;
            ViewData["marital"] = emp.ps_status_marital;
            ViewData["emp_person_id"] = emp.ep_ref_personal_id;

            ViewData["type_"] = type.dropdown_type_id(emp.ep_ref_type_id);

            emp_positionModel posit = new emp_positionModel();
            ViewData["position"] = posit.emp_position_list(code);

            //

            /// address
            dataAddress(code);
            /// 
            // study
            ViewData["data_study"] = study.tb_study(code);
            //

            // work
            personal_workModel work = new personal_workModel();
            ViewData["data_work"] = work.tb_work(code);
            //

            // train
            personal_trainModel train = new personal_trainModel();
            ViewData["data_train"] = train.tb_train(code);
            //

            // family
            personal_familyModel fam = new personal_familyModel();
            fam.get_family(code);
            ViewData["dad_name"] = fam.fam_name_dad+" "+fam.fam_lastname_dad;
            ViewData["dad_age"] = fam.fam_age_dad;
            ViewData["dad_tel"] = fam.fam_tel_dad;
            ViewData["dad_mobile"] = fam.fam_mobile_dad;
            ViewData["dad_address"] = fam.fam_num_dad + " หมู่ " + fam.fam_moo_dad + " " + fam.fam_district_dad + ", " + fam.fam_amphur_dad + ", " + fam.fam_province_dad + " " + fam.fam_postcode_dad;

            ViewData["mom_name"] = fam.fam_name_mom + " " + fam.fam_lastname_mom;
            ViewData["mom_age"] = fam.fam_age_mom;
            ViewData["mom_tel"] = fam.fam_tel_mom;
            ViewData["mom_mobile"] = fam.fam_mobile_mom;
            ViewData["mom_address"] = fam.fam_num_mom + " หมู่ " + fam.fam_moo_mom + " " + fam.fam_district_mom + ", " + fam.fam_amphur_mom + ", " + fam.fam_province_mom + " " + fam.fam_postcode_mom;

            ViewData["marry_name"] = fam.fam_name_marry + " " + fam.fam_lastname_marry;
            ViewData["marry_age"] = fam.fam_age_marry;
            ViewData["marry_tel"] = fam.fam_tel_marry;
            ViewData["marry_mobile"] = fam.fam_mobile_marry;
            ViewData["marry_address"] = fam.fam_num_marry + " หมู่ " + fam.fam_moo_marry + " " + fam.fam_district_marry + ", " + fam.fam_amphur_marry + ", " + fam.fam_province_marry + " " + fam.fam_postcode_marry;

            //

            // child
            personal_kidModel child = new personal_kidModel();
            ViewData["data_child"] = child.tb_kid(code);
            //
            
            /// income
            checkPay(code);
            select_income();
            /// 
            /// minus
            minus();
            minusSalary(code);
            /// 
            /// fund
            fund(code);
            empFundResign fn = new empFundResign();
            empFundChange fc = new empFundChange();
            ViewData["fundResign"] = fn.list_fundResignEmp(code);
            ViewData["fundChange"] = fc.list_fundChange_emp(code);
            /// 

            /// commend
            commend(code);
            /// 

            /// admonish
            admonish(code);
            /// 

            ////
            provinceModel province = new provinceModel();
            ViewData["province"] = province.selectProvince();

            amphurModel amphur = new amphurModel();
            ViewData["amphur"] = amphur.select_amphur();

            districtModel district = new districtModel();
            ViewData["district"] = district.select_district();
            
            //profile img
            empModel em = new empModel();
            em.check_img(code);

            if (string.IsNullOrEmpty(em.img_name) == true)
            {

                ViewData["profile_img"] = "../../profile/face-2.jpg";

            }
            else {

                ViewData["profile_img"] = "../../profile/" + em.img_name;

            }

            empPositionChangeModel pc = new empPositionChangeModel();
            pc.pc_emp_id = code;
            ViewData["data_change_position"] = pc.list_posiotnChane_emp_id();


            EmpPositionResignModel rs = new EmpPositionResignModel();
            ViewData["data_resign_position"] = rs.list_position_resign_emp(code);

            
            return View();

        }
        public IActionResult viewEmp(string code, string txt)
        {

            code_test = code;

            personalModel ps = new personalModel();

            ViewData["person_edit"] = ps.personal_for_edit();

            info_positionModel posi = new info_positionModel();
            companyModel comp = new companyModel();
            sectionModel sect = new sectionModel();
            departmentModel dep = new departmentModel();
            emp_typeModel type = new emp_typeModel();
            ViewData["position_dropdown"] = posi.dropDownPosition();
            ViewData["company"] = comp.drop_company();
            ViewData["section"] = sect.drop_section();
            ViewData["department"] = dep.drop_dep();
            ViewData["type"] = type.dropdown_type();


            info_prefixModels prefix = new info_prefixModels();
            info_statusModel status = new info_statusModel();
            personal_studyModel study = new personal_studyModel();

            ViewData["prefix_th"] = prefix.select_prefixTH();
            ViewData["prefix_en"] = prefix.select_prefixEN();
            ViewData["type_emp"] = type.dropdown_type();
            ViewData["status"] = status.dropdown_status();


            //view employee//
            view_employeeModel emp = new view_employeeModel();

            emp.selectData(code);

            ViewData["emp_id"] = code;
            ViewData["emp_code"] = emp.ep_code;
            ViewData["emp_name_th"] = emp.prefix_name_en + " " + emp.ps_name_th + " " + emp.ps_lastname_th;
            ViewData["emp_name_en"] = emp.prefix_name_en + " " + emp.ps_name_en + " " + emp.ps_lastname_en;
            ViewData["emp_status"] = emp.ep_status;
            ViewData["emp_start_date"] = emp.ep_start;
            ViewData["emp_end_date"] = emp.ep_end;
            ViewData["emp_email"] = emp.contact_email;
            ViewData["emp_table"] = emp.contact_table;
            ViewData["emp_phone"] = emp.contact_phone;
            ViewData["emp_mobile1"] = emp.contact_mobile1;
            ViewData["emp_mobile2"] = emp.contact_mobile2;
            ViewData["position_name"] = emp.post_name;
            ViewData["position_type"] = emp.type_name;
            ViewData["position_dept"] = emp.dept_name;
            ViewData["position_sect"] = emp.Section_name;
            ViewData["position_comp"] = emp.T_Company;
            ViewData["gender"] = emp.ps_gender;
            ViewData["age"] = Convert.ToInt32((DateTime.Now.Year)) - Convert.ToInt32((Convert.ToDateTime(emp.ps_birthday).Year));
            ViewData["nationality"] = emp.ps_nationality;
            ViewData["race"] = emp.ps_race;
            ViewData["religion"] = emp.ps_religion;
            ViewData["blood"] = emp.ps_blood;
            ViewData["birthday"] = Convert.ToDateTime(emp.ps_birthday).ToString("dd MMMM yyyy");
            ViewData["birthday_format"] = Convert.ToDateTime(emp.ps_birthday).ToString("dd/MM/yyyy");
            ViewData["identification"] = emp.ps_national_id;
            ViewData["date_issue"] = emp.ps_national_date_start;
            ViewData["expired_date"] = emp.ps_national_date_end;
            ViewData["marital"] = emp.ps_status_marital;
            ViewData["emp_person_id"] = emp.ep_ref_personal_id;

            emp_positionModel posit = new emp_positionModel();
            ViewData["position"] = posit.emp_position_list(code);

            //

            /// address
            dataAddress(code);
            /// 
            // study
            ViewData["data_study"] = study.tb_study(code);
            //

            // work
            personal_workModel work = new personal_workModel();
            ViewData["data_work"] = work.tb_work(code);
            //

            // train
            personal_trainModel train = new personal_trainModel();
            ViewData["data_train"] = train.tb_train(code);
            //

            // family
            personal_familyModel fam = new personal_familyModel();
            fam.get_family(code);
            ViewData["dad_name"] = fam.fam_name_dad + " " + fam.fam_lastname_dad;
            ViewData["dad_age"] = fam.fam_age_dad;
            ViewData["dad_tel"] = fam.fam_tel_dad;
            ViewData["dad_mobile"] = fam.fam_mobile_dad;
            ViewData["dad_address"] = fam.fam_num_dad + " หมู่ " + fam.fam_moo_dad + " " + fam.fam_district_dad + ", " + fam.fam_amphur_dad + ", " + fam.fam_province_dad + " " + fam.fam_postcode_dad;

            ViewData["mom_name"] = fam.fam_name_mom + " " + fam.fam_lastname_mom;
            ViewData["mom_age"] = fam.fam_age_mom;
            ViewData["mom_tel"] = fam.fam_tel_mom;
            ViewData["mom_mobile"] = fam.fam_mobile_mom;
            ViewData["mom_address"] = fam.fam_num_mom + " หมู่ " + fam.fam_moo_mom + " " + fam.fam_district_mom + ", " + fam.fam_amphur_mom + ", " + fam.fam_province_mom + " " + fam.fam_postcode_mom;

            ViewData["marry_name"] = fam.fam_name_marry + " " + fam.fam_lastname_marry;
            ViewData["marry_age"] = fam.fam_age_marry;
            ViewData["marry_tel"] = fam.fam_tel_marry;
            ViewData["marry_mobile"] = fam.fam_mobile_marry;
            ViewData["marry_address"] = fam.fam_num_marry + " หมู่ " + fam.fam_moo_marry + " " + fam.fam_district_marry + ", " + fam.fam_amphur_marry + ", " + fam.fam_province_marry + " " + fam.fam_postcode_marry;

            //

            // child
            personal_kidModel child = new personal_kidModel();
            ViewData["data_child"] = child.tb_kid(code);
            //

            /// income
            checkPay(code);
            select_income();
            /// 
            /// minus
            minus();
            minusSalary(code);
            /// 
            /// fund
            fund(code);
            /// 

            /// commend
            commend(code);
            /// 

            /// admonish
            admonish(code);
            /// 

            ////
            provinceModel province = new provinceModel();
            ViewData["province"] = province.selectProvince();

            amphurModel amphur = new amphurModel();
            ViewData["amphur"] = amphur.select_amphur();

            districtModel district = new districtModel();
            ViewData["district"] = district.select_district();

            //profile img
            empModel em = new empModel();
            em.check_img(code);

            if (string.IsNullOrEmpty(em.img_name) == true)
            {

                ViewData["profile_img"] = "../../profile/face-2.jpg";

            }
            else
            {

                ViewData["profile_img"] = "../../profile/" + em.img_name;

            }

            return View();

        }
        public IActionResult employee(string code, string txt) {


            info_prefixModels prefix = new info_prefixModels();
            info_statusModel status = new info_statusModel();
            emp_typeModel type = new emp_typeModel();


            ViewData["prefix_th"] = prefix.select_prefixTH();
            ViewData["prefix_en"] = prefix.select_prefixEN();
            ViewData["type_emp"] = type.dropdown_type();
            ViewData["status"] = status.dropdown_status();
            
            // EmployeeModels emp = new EmployeeModels();
            // emp_contactModel contact = new emp_contactModel();
            // emp_profileModel profile = new emp_profileModel();

            // emp.emp_id = code;
            // emp.tab_employee();
            // ViewData["emp_code"] = emp.emp_code;
            // ViewData["emp_name_th"] = emp.emp_prefix_th + " " + emp.emp_name_th+" "+emp.emp_lastname_th;
            // ViewData["emp_name_en"] = emp.emp_prefix_en+" "+emp.emp_name_en+" "+emp.emp_lastname_en;
            // ViewData["emp_status"] = emp.emp_status;
            // ViewData["emp_start_date"] = emp.emp_start_date;
            // ViewData["emp_id"] = code;

            // contact.contact_emp_id = code;
            // ViewData["check_contact"] = contact.check_contact();

            // ViewData["check_profile"] = profile.check_profile(code);
            // checkAddress(code);

            // /// Contact ///

            // //if (contact.contect_check != "0")
            // //{
            //     contact.select_contact();
            //     ViewData["emp_email"] = contact.contact_email;
            //     ViewData["emp_table"] = contact.contact_table;
            //     ViewData["emp_phone"] = contact.contact_phone;
            //     ViewData["emp_mobile1"] = contact.contact_mobile1;
            //     ViewData["emp_mobile2"] = contact.contact_mobile2;
            // // }
            ///position////
            position(code);
            ///

            /// profile ///
            emp_profile(code);
            ///

            /// province ////
            province();
            ///

            /// amphur 
            amphurModel amphur = new amphurModel();
            ViewData["amphur"] = amphur.select_amphur();
            /// //// 

            /// district
            districtModel dis = new districtModel();
            ViewData["district"] = dis.select_district();
            /// 
            /// address
            dataAddress(code);
            /// 

            /// income
            checkPay(code);
            select_income();
            /// 
            /// minus
            minus();
            minusSalary(code);
            /// 
            /// fund
            fund(code);
            /// 

            /// commend
            commend(code);
            /// 

            /// admonish
            admonish(code);
            /// 

            // ViewData["txt"] = txt;

            return View();
        }
        public void position(string emp) {
            
            emp_positionModel pos = new emp_positionModel();
            ViewData["check_position"] = pos.checkCount(emp);
            pos.selectPositionByemp(emp);
            ViewData["position_name"] = pos.pos_position_name;
            ViewData["position_comp"] = pos.pos_comp_name;
            ViewData["position_sect"] = pos.pos_sect_name;
            ViewData["position_dept"] = pos.pos_dept_name;
            ViewData["position_type"] = pos.pos_type_name;
            
            info_positionModel post = new info_positionModel();
            ViewData["drop_position"] = post.dropDownPosition();
            emp_typeModel type = new emp_typeModel();
            ViewData["drop_type"] = type.dropdown_type();
            companyModel comp = new companyModel();
            ViewData["company"] = comp.drop_company();
            sectionModel sect = new sectionModel();
            ViewData["section"] = sect.drop_section();
            departmentModel dept = new departmentModel();
            ViewData["department"] = dept.drop_dep(); 

        }
        public void admonish(string emp)
        {

            emp_admonishModel adm = new emp_admonishModel();
            string check = adm.checkAdmonish(emp);
            ViewData["check_admonish"] = check;
            //if (check != "0")
            //{
            ViewData["data_admonish"] = adm.selectAdmbyEmp(emp);

            //  }


        }
        public void commend(string emp) {

            emp_commendModel comm = new emp_commendModel();
            string check = comm.checkCommend(emp);
            ViewData["check_commend"] = check;
            //if (check != "0")
            //{
                ViewData["data_commend"] = comm.selectCommbyEmp(emp);

          //  }


        }
        public void fund(string emp) {

            info_fundModel fund = new info_fundModel();
            ViewData["fund"] = fund.dropdownFund();

            emp_fundRegisModel fr = new emp_fundRegisModel();
            string check = fr.checkFund(emp);
            ViewData["check_fund"] = check;
           // if (check != "0") {

                ViewData["data_fund"] = fr.selectFundByEmp(emp);
           // }

        }
        public void minusSalary(string emp) {

            emp_minusSalaryModel ms = new emp_minusSalaryModel();
            string check_minus = ms.checkMinus(emp);
            ViewData["check_minus"] = check_minus;
            //   if (check_minus != "0") {
            // ViewData["data_minus"] = ms.dataMinus(emp);

            ViewData["data_minus"] = ms.emp_minus(emp);
            ms.Daymax_minus(emp);
            ViewData["max_minus"] = ms.max;

            // }

        }
        public void minus() {

            info_minusModel minus = new info_minusModel();
            ViewData["minus"] = minus.selectMinus();

            
        }
        public void checkPay(string emp) {

            emp_payModel pay = new emp_payModel();
            ViewData["check_pay"] = pay.checkPay(emp);
            string check = pay.checkPay(emp);
            //  if (check != "0")
            //  {
            // ViewData["data_pay"] = pay.select_pay(emp);
            ViewData["data_pay"] = pay.emp_pay(emp);

            pay.Daymax_pay(emp);
            ViewData["max_pay"] = pay.max;
            //  }
        }
        public void cancel_pay(string emp, string start, string end) {

            emp_payModel pay = new emp_payModel();
            
            List<string> pid = pay.cancel_pay(emp, start, end);

            foreach (string id in pid) {

                pay.dataForUpdate(id);
                pay.insert_payLOG();

                pay.pay_status = "N";
                pay.event_status = "U";
                pay.update_pay();

            }
           
        }
        public void cancel_minus(string emp, string start, string end)
        {

            emp_minusSalaryModel ms = new emp_minusSalaryModel();

            List<string> mid = ms.cancel_minus(emp, start, end);

            foreach (string id in mid)
            {

                ms.dataForUpdate(id);
                ms.insertMinusSqlaryLOG();;

                ms.ms_status = "N";
                ms.event_status = "U";
                ms.insertMinusSqlary_edit();

            }

        }
        public string income_new()
        {

            info_incomeModel ic = new info_incomeModel();

            return ic.selectIncome_new();
        }
        public string plusPay(string emp,string start, string end) {

            CultureInfo th = new CultureInfo("th-TH");

            emp_payModel pay = new emp_payModel();
            info_incomeModel income = new info_incomeModel();

            List<string> id = new List<string>();
            id = pay.check_id_pay_emp_select(emp, start, end);
            
            return  Convert.ToDateTime(start).ToString("dd/MM/yyyy") +"^"+Convert.ToDateTime(end).ToString("dd/MM/yyyy")+"^"+income.select_income_emp(id);

        }
        public string plusMinus(string emp, string start, string end)
        {

            CultureInfo th = new CultureInfo("th-TH");

            emp_minusSalaryModel ms = new emp_minusSalaryModel();
            info_minusModel minus = new info_minusModel();

            List<string> id = new List<string>();
            id = ms.check_id_minus_emp_select(emp, start, end);

            return Convert.ToDateTime(start).ToString("dd/MM/yyyy") + "^" + Convert.ToDateTime(end).ToString("dd/MM/yyyy") + "^" + minus.select_minus_emp(id);

        }
        public void select_income() {

            info_incomeModel income = new info_incomeModel();
            ViewData["income"] = income.selectIncome();

        }
        public void dataAddress(string emp) {

            AddressModel add = new AddressModel();
            add.data_address(emp);
            ViewData["num"] = add.address_num;
            ViewData["moo"] = add.address_moo;
            ViewData["type"] = add.address_type_name;
            ViewData["name"] = add.address_name;
            ViewData["alley"] = add.address_alley;
            ViewData["road"] = add.address_road;
            ViewData["district_name"] = add.address_district_name;
            ViewData["amphur_name"] = add.address_amphur_name;
            ViewData["province_name"] = add.address_province_name;
            ViewData["postcode"] = add.address_postcode;

            ViewData["num_call"] = add.address_num_call;
            ViewData["moo_call"] = add.address_moo_call;
            ViewData["type_call"] = add.address_type_name_call;
            ViewData["name_call"] = add.address_name_call;
            ViewData["alley_call"] = add.address_alley_call;
            ViewData["road_call"] = add.address_road_call;
            ViewData["district_call"] = add.address_district_name_call;
            ViewData["amphur_call"] = add.address_amphur_name_call;
            ViewData["province_call"] = add.address_province_name_call;
            ViewData["postcode_call"] = add.address_postcode_call;
        }
        public void checkAddress(string emp) {

            AddressModel add = new AddressModel();
            ViewData["check_address"] = add.checkAddress(emp);
        }
        public void province() {

            provinceModel province = new provinceModel();
            ViewData["province"] = province.selectProvince();
        }
        public string amphur(string province)
        {
            amphurModel amphur = new amphurModel();
            return "<select id='select_amphur' name='select_amphur' class='form-control select2' onchange='myFunction_amphur()' style='width:100%'><option>เลือกเขต/อำเภอ</option>" + amphur.getamphur(province)+"</select>";
        }
        public string amphur1(string province)
        {
            amphurModel amphur = new amphurModel();
            return "<select id='select_amphur1' name='select_amphur1' class='form-control select2' onchange='myFunction_amphur1()' style='width:100%'><option>เลือกเขต/อำเภอ</option>" + amphur.getamphur(province) + "</select>";
        }
        public string district(string amphur) {

            districtModel district = new districtModel();

            return "<select id='select_district' name='select_district' class='form-control select2' style='width:100%'><option>เลือกแขวง/ตำบล</option>" + district.getDistinct(amphur)+"</select>";
        }
        public string district1(string amphur)
        {

            districtModel district = new districtModel();

            return "<select id='select_district1' name='select_district1' class='form-control select2' style='width:100%'><option>เลือกแขวง/ตำบล</option>" + district.getDistinct(amphur) + "</select>";
        }
        public void emp_profile(string emp) {

            emp_profileModel profile = new emp_profileModel();
            if (profile.check_profile(emp) != "0")
            {
                profile.select_profile(emp);
                ViewData["gender"] = profile.profile_gender;
                ViewData["age"] = profile.profile_age;
                ViewData["nationality"] = profile.profile_nationality;
                ViewData["race"] = profile.profile_race;
                ViewData["religion"] = profile.profile_religion;
                ViewData["blood"] = profile.profile_blood;
                ViewData["birthday"] = profile.profile_birthday;
                ViewData["identification"] = profile.profile_identification;
                ViewData["date_issue"] = profile.profile_date_issue;
                ViewData["expired_date"] = profile.profile_expired_date;
                ViewData["weigth"] = profile.profile_weight;
                ViewData["height"] = profile.profile_height;
                if (profile.profile_marital_status == "single")
                {
                    ViewData["marital"] = "โสด";

                }
                else if (profile.profile_marital_status == "marry")
                {
                    ViewData["marital"] = "สมรส";
                }
                else if(profile.profile_marital_status == "divorce") {

                    ViewData["marital"] = "หยย่า";
                }
                else if (profile.profile_marital_status == "separate") {

                    ViewData["marital"] = "แยกกันอยู่";

                }
                
                ViewData["child"] = profile.profile_child_num;
            }

        }
        public IActionResult addEmp()
        {
            EmployeeModels emp = new EmployeeModels();
            emp.insertEmp();
            string str = emp.turnId;
            return RedirectToAction("emp",new { ID = str});
        }
        [HttpPost]
        public IActionResult insertEmp(string prefix_th, string name_th, string name_en, string status, string type, string start, string last_th, string last_en, string prefix_en, string position, string company, string section, string department) {

            CultureInfo en = new CultureInfo("EN");

            EmployeeModels emp = new EmployeeModels();
            emp.emp_prefix_th = prefix_th;
            emp.emp_name_th = name_th;
            emp.emp_name_en = name_en;
            emp.emp_status = status;
            emp.emp_type = type;
            emp.emp_start_date = start;
            emp.emp_lastname_th = last_th;
            emp.emp_lastname_en = last_en;
            emp.emp_prefix_en = prefix_en;

            emp.insertEmp();

            return RedirectToAction("employee", new { code = emp.emp_id });
        }
        [HttpPost]
        public IActionResult addPosition(string type, string start, string position, string company, string txtsection, string txtdepartment, string emp_id) {

            CultureInfo en = new CultureInfo("EN");

            emp_positionModel pos = new emp_positionModel();
            pos.pos_emp_id = emp_id;
            pos.pos_position_id = position;
            pos.pos_type = type;
            pos.pos_comp_id = company;
            pos.pos_sect_id = txtsection;
            pos.pos_dept_id = txtdepartment;
            pos.pos_start_date = Convert.ToDateTime(start).ToString("yyyy-MM-dd", en);
            pos.pos_resign_date = Convert.ToDateTime("3000-01-01").ToString("yyyy-MM-dd", en);
            pos.insert_position();

            return RedirectToAction("emp", new { code = emp_id });

        }
        [HttpPost]
        public IActionResult addEmp(string ps_id, string type, string start, string position, string company, string txtsection, string txtdepartment) {


            CultureInfo en = new CultureInfo("EN");
            CultureInfo th = new CultureInfo("TH");

            DateTime dt = new DateTime(3000,01,01);
            empModel em = new empModel();
            em.ep_ref_personal_id = ps_id;
            em.ep_ref_type_id = type;
            em.ep_start = Convert.ToDateTime(start).ToString("yyyy-MM-dd", th);

            em.insertEmp();

            ///
            emp_positionModel pos = new emp_positionModel();
            pos.pos_emp_id = em.ep_id;
            pos.pos_position_id = position;
            pos.pos_type = type;
            pos.pos_comp_id = company;
            pos.pos_sect_id = txtsection;
            pos.pos_dept_id = txtdepartment;
            pos.pos_start_date = Convert.ToDateTime(start).ToString("yyyy-MM-dd", en);
            pos.pos_resign_date = Convert.ToDateTime(dt).ToString("yyyy-MM-dd", en);
            pos.insert_position();
            //  string txt = pos.pos_emp_id + "^" + pos.pos_position_id + "^" + pos.pos_type + "^" + pos.pos_comp_id + "^" + pos.pos_sect_id + "^" + pos.pos_dept_id +"^" + pos.pos_start_date + "^" + pos.pos_resign_date;

            view_employeeModel v_emp = new view_employeeModel();
            v_emp.selectData(em.ep_id);

            DateTime date = new DateTime(3000, 01, 01);
            emp_actionModel emp_action = new emp_actionModel();
            emp_action.emp_code = v_emp.ep_code;
            emp_action.emp_prefix_th = v_emp.prefix_name_th;
            emp_action.emp_name_th = v_emp.ps_name_th;
            emp_action.emp_lastname_th = v_emp.ps_lastname_th;
            emp_action.emp_national_id = v_emp.ps_national_id;
            emp_action.emp_full_name = v_emp.ps_name_full;
            emp_action.emp_type_name = v_emp.type_name;
            emp_action.emp_start_date = Convert.ToDateTime(v_emp.ep_start).ToString("yyyy-MM-dd",en);
            emp_action.emp_end_date = date.ToString();
            emp_action.emp_salary = "";
            emp_action.emp_stipend = "";
            emp_action.emp_action_start = DateTime.Now.ToString("yyyy-MM-dd",en);
            emp_action.emp_action_end = date.ToString();
       //     emp_action.insert_emp_action();


            return RedirectToAction("emp", new { code = em.ep_id ,startaction = emp_action.emp_action_start , empcode = emp_action.emp_code, prefix = emp_action.emp_prefix_th, name = emp_action.emp_name_th, last = emp_action.emp_lastname_th , national = emp_action.emp_national_id ,full = emp_action.emp_full_name, type = emp_action.emp_type_name, start = emp_action.emp_start_date, end = emp_action.emp_end_date, action = emp_action.emp_action_start, endaction = emp_action.emp_action_end });
        }
        public string  dataForEdit(string emp) {

            EmployeeModels em = new EmployeeModels();
            em.emp_id = emp;
            em.tab_employee();
            string data = em.emp_id + "^" + em.emp_prefix_th + "^" + em.emp_name_th + "^" + em.emp_lastname_th + "^" + em.emp_prefix_en + "^" + em.emp_name_en + "^" + em.emp_lastname_en + "^" + em.emp_type + "^" + em.emp_status + "^" + em.emp_start_date + "^" + em.emp_end_date;

            return data;
        }
        public string getPerson(string id) {

            personalModel ps = new personalModel();
            
            return ps.getdata_personal(id);

        }
        public IActionResult edit_contact(string code) {
            
            return View();
        }
        [HttpPost]
        public IActionResult editEmp(string emp_id, string emp_person_edit, string emp_start_edit, string type_) {


            empModel emp = new empModel();

            emp.select_emp(emp_id);
            emp.insertEmpLOG();

            emp.ep_ref_personal_id = emp_person_edit;
            emp.ep_start = emp_start_edit;
            emp.ep_ref_type_id = type_;

            emp.update_emp();

            return RedirectToAction("emp","Employee",new { code = emp_id});
        }
        private IHostingEnvironment _hostingEnvironment;

        public EmployeeController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IList<IFormFile> selectFile ,string emp_id, string emp_code)
        {
            string status = "aa";

            view_employeeModel vm = new view_employeeModel();
            empModel em = new empModel();

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "profile");
            foreach (var file in selectFile)
            {
                if (file.Length > 0)
                {
                    
                    if (string.IsNullOrEmpty(vm.check_img(emp_id)) == true)
                    {
                        em.img_ref_emp_id = emp_id;
                        em.img_ref_person_id = em.empPerson(emp_id);
                        em.img_name = file.FileName;
                        
                        em.insert_img();

                        em.check_img(emp_id);
                        
                        em.insert_imgLOG();

                    }
                    else {

                        em.check_img(emp_id);

                        em.insert_imgLOG();

                        em.img_ref_emp_id = emp_id;
                        em.img_ref_person_id = em.empPerson(emp_id);
                        em.img_name = file.FileName;
                        
                        em.update_img();

                    }
                    
                    var filePath = Path.Combine(uploads, file.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);

                    }
                    

                }
            }




            return RedirectToAction("emp", "Employee", new { code = emp_id , n = "check"});
        }
        public IActionResult resign() {

            view_employeeModel emp = new view_employeeModel();
            ViewData["data_resign"] = emp.emp_data_resign();

            return View();
        }
        public IActionResult addResign()
        {

            empModel emp = new empModel();
            ViewData["emp"] = emp.drop_emp_resign();
            return View();
        }
        public IActionResult editResign(string id)
        {
            ViewData["re_id"] = id;

            emp_resignModel er = new emp_resignModel();
            er.re_id = id;
            er.select_resign();

            ViewData["re_id"] = er.re_id;
            ViewData["emp_id"] = er.re_ref_emp_id;
            ViewData["re_resign_date"] = er.re_resign_date;
            ViewData["re_type"] = er.re_type;
            ViewData["re_detail"] = er.re_detail;

            empModel emp = new empModel();
            ViewData["emp"] = emp.drop_emp_resign(er.re_ref_emp_id);


            return View();
        }
        public string  select_data_resign(string id) {

            view_employeeModel emp = new view_employeeModel();
            emp.selectData(id);


            return emp.prefix_name_th + " " + emp.ps_name_full + "^" + emp.post_name + "^" + emp.T_Company + "^" + emp.Section_name + "^" + emp.dept_name + "^" + emp.ep_start;

        }
       
    }
}
