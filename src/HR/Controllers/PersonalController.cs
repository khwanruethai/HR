using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;
using HR.Controllers;
using Microsoft.AspNetCore.Http;
using System.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class PersonalController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            personalModel ps = new personalModel();

            ViewData["data"] = ps.infoPersonal();
            HttpContext.Session.SetString("tabClick", "");


            return View();
        }
        public IActionResult addPersonal()
        {

            info_prefixModels prefix = new info_prefixModels();

            ViewData["prefix_th"] = prefix.select_prefixTH();
            ViewData["prefix_en"] = prefix.select_prefixEN();

            provinceModel province = new provinceModel();
            ViewData["province"] = province.selectProvince();

            amphurModel amphur = new amphurModel();
            ViewData["amphur"] = amphur.select_amphur();

            districtModel district = new districtModel();
            ViewData["district"] = district.select_district();
            

            return View();
        }
        public IActionResult editPersonal(string person)
        {

            personalModel ps = new personalModel();
            info_prefixModels px = new info_prefixModels();
            ps.select_personal(person);

            ViewData["ps_id"] = ps.personal_id;
            ViewData["prefix_th"] =  px.select_prefixTH_for_edit(ps.prefix_th);
            ViewData["prefix_en"] = px.select_prefixEN_for_edit(ps.prefix_en);
            ViewData["name_th"] = ps.name_th;
            ViewData["name_en"] = ps.name_en;
            ViewData["lastname_th"] = ps.lastname_th;
            ViewData["lastname_en"] = ps.lastname_en;
            ViewData["gender"] = ps.gender;
            ViewData["blood"] = ps.blood;
            ViewData["national_id"] = ps.national_id;
            ViewData["national_start"] = ps.national_start;
            ViewData["national_end"] = ps.national_end;
            ViewData["birthday"] = ps.birthday;
            ViewData["age"] = ps.age;
            ViewData["nationality"] = ps.nationality;
            ViewData["race"] = ps.race;
            ViewData["marital"] = ps.marital;
            ViewData["religion"] = ps.religion;

            selectAddressPerson(person);
            selectContact(person);
            selectFamily(person);
            select_kid(person);
            select_study(person);
            select_work(person);
            select_train(person);

            try
            {

                ViewData["test_step"] = HttpContext.Session.GetString("step").ToString();
            }
            catch {

                ViewData["test_step"] = "false";

            }

            personalChangeModel pc = new personalChangeModel();
            pc.ch_ref_person_id = person;
            ViewData["person_change"] = pc.list_chane_name();
            

            return View();
        }
        public IActionResult viewPersonal(string person)
        {
            personalModel ps = new personalModel();
            info_prefixModels px = new info_prefixModels();

            ps.select_personal(person);

            ViewData["ps_id"] = ps.personal_id;
            ViewData["prefix_th"] = px.select_prefixTH_for_edit(ps.prefix_th);
            ViewData["prefix_en"] = px.select_prefixEN_for_edit(ps.prefix_en);
            ViewData["prefix_th_name"] = ps.prefix_th_name;
            ViewData["prefix_en_name"] = ps.prefix_en_name;
            ViewData["name_th"] = ps.name_th;
            ViewData["name_en"] = ps.name_en;
            ViewData["lastname_th"] = ps.lastname_th;
            ViewData["lastname_en"] = ps.lastname_en;
            ViewData["gender"] = ps.gender;
            ViewData["blood"] = ps.blood;
            ViewData["national_id"] = ps.national_id;
            ViewData["national_start"] = ps.national_start;
            ViewData["national_end"] = ps.national_end;
            ViewData["birthday"] = ps.birthday;
            ViewData["age"] = ps.age;
            ViewData["nationality"] = ps.nationality;
            ViewData["race"] = ps.race;
            ViewData["marital"] = ps.marital;
            ViewData["religion"] = ps.religion;

            selectAddressPerson(person);
            selectContact(person);
            selectFamily(person);
            select_kid(person);
            select_study(person);
            select_work(person);
            select_train(person);

            return View();
        }
        public void selectAddressPerson(string person)
        {
            AddressModel add = new AddressModel();
            districtModel dis = new districtModel();
            amphurModel amp = new amphurModel();
            provinceModel prov = new provinceModel();

            add.selectAddressPerson(person);

            ViewData["add_num"] = add.address_num;
            ViewData["add_moo"] = add.address_moo;
            ViewData["add_type"] = add.address_type;
            ViewData["add_type_name"] = add.address_type_name;
            ViewData["add_name"] = add.address_name;
            ViewData["add_alley"] = add.address_alley;
            ViewData["add_road"] = add.address_road;
            ViewData["add_district"] = dis.select_district_forEdit(add.address_district_id);
            ViewData["add_district_name"] = add.address_district_name;
            ViewData["add_amphur"] = amp.select_amphur_forEdit(add.address_amphur_id);
            ViewData["add_amphur_name"] = add.address_amphur_name;
            ViewData["add_province"] = prov.selectProvince_forEdit(add.address_province_id);
            ViewData["add_province_name"] = add.address_province_name;
            ViewData["add_postcode"] = add.address_postcode;
            ViewData["call_num"] = add.address_num_call;
            ViewData["call_moo"] = add.address_moo_call;
            ViewData["call_type"] = add.address_type_call;
            ViewData["call_type_name"] = add.address_type_name_call;
            ViewData["call_name"] = add.address_name_call;
            ViewData["call_alley"] = add.address_alley_call;
            ViewData["call_road"] = add.address_road_call;
            ViewData["call_district"] = dis.select_district_forEdit(add.address_district_id_call);
            ViewData["call_district_name"] = add.address_district_name_call;
            ViewData["call_amphur"] = amp.select_amphur_forEdit(add.address_amphur_id_call);
            ViewData["call_amphur_name"] = add.address_amphur_name_call;
            ViewData["call_province"] = prov.selectProvince_forEdit(add.address_province_id_call);
            ViewData["call_province_name"] = add.address_province_name_call;
            ViewData["call_postcode"] = add.address_postcode_call;

            
        }
        public void selectContact(string person) {

            emp_contactModel ct = new emp_contactModel();
            ct.selectContact_Person(person);
            ViewData["ct_mail"] = ct.contact_email;
            ViewData["ct_table"] = ct.contact_table;
            ViewData["ct_phone"] = ct.contact_phone;
            ViewData["ct_mobile1"] = ct.contact_mobile1;
            ViewData["ct_mobile2"] = ct.contact_mobile2;

        }
        public void selectFamily(string person) {

            personal_familyModel fm = new personal_familyModel();
            districtModel dis = new districtModel();
            amphurModel amp = new amphurModel();
            provinceModel prov = new provinceModel();

            fm.selectFamilyPerson(person);

            ViewData["d_name"] = fm.fam_name_dad;
            ViewData["d_last"] = fm.fam_lastname_dad;
            ViewData["d_age"] = fm.fam_age_dad;
            ViewData["d_num"] = fm.fam_num_dad;
            ViewData["d_moo"] = fm.fam_moo_dad;
            ViewData["d_province"] = prov.selectProvince_forEdit(fm.fam_province_dad);
            ViewData["d_amphur"] = amp.select_amphur_forEdit(fm.fam_amphur_dad);
            ViewData["d_district"] = dis.select_district_forEdit(fm.fam_district_dad);
            ViewData["d_postcode"] = fm.fam_postcode_dad;
            ViewData["d_tel"] = fm.fam_tel_dad;
            ViewData["d_mobile"] = fm.fam_mobile_dad;
            ViewData["d_province_name"] = fm.province_name_dad;
            ViewData["d_amphur_name"] = fm.amphur_name_dad;
            ViewData["d_district_name"] = fm.district_name_dad;

            ViewData["m_name"] = fm.fam_name_mom;
            ViewData["m_last"] = fm.fam_lastname_mom;
            ViewData["m_age"] = fm.fam_age_mom;
            ViewData["m_num"] = fm.fam_num_mom;
            ViewData["m_moo"] = fm.fam_moo_mom;
            ViewData["m_province"] = prov.selectProvince_forEdit(fm.fam_province_mom);
            ViewData["m_amphur"] = amp.select_amphur_forEdit(fm.fam_amphur_mom);
            ViewData["m_district"] = dis.select_district_forEdit(fm.fam_district_mom);
            ViewData["m_postcode"] = fm.fam_postcode_mom;
            ViewData["m_tel"] = fm.fam_tel_mom;
            ViewData["m_mobile"] = fm.fam_mobile_mom;
            ViewData["m_province_name"] = fm.province_name_mom;
            ViewData["m_amphur_name"] = fm.amphur_name_mom;
            ViewData["m_district_name"] = fm.district_name_mom;

            ViewData["h_name"] = fm.fam_name_marry;
            ViewData["h_last"] = fm.fam_lastname_marry;
            ViewData["h_age"] = fm.fam_age_marry;
            ViewData["h_num"] = fm.fam_num_marry;
            ViewData["h_moo"] = fm.fam_moo_marry;
            ViewData["h_province"] = prov.selectProvince_forEdit(fm.fam_province_marry);
            ViewData["h_amphur"] = amp.select_amphur_forEdit(fm.fam_amphur_marry);
            ViewData["h_district"] = dis.select_district_forEdit(fm.fam_district_marry);
            ViewData["h_postcode"] = fm.fam_postcode_marry;
            ViewData["h_tel"] = fm.fam_tel_marry;
            ViewData["h_mobile"] = fm.fam_mobile_marry;
            ViewData["h_province_name"] = fm.province_name_marry;
            ViewData["h_amphur_name"] = fm.amphur_name_marry;
            ViewData["h_district_name"] = fm.district_name_marry;

        }
        public void select_kid(string person)
        {
            personal_kidModel kid = new personal_kidModel();

            ViewData["data_kid"] = kid.tb_kid_person(person);

        }
        public void select_study(string person) {

            personal_studyModel st = new personal_studyModel();
            ViewData["data_study"] = st.tb_study_person(person);

        }
        public void select_work(string person) {

            personal_workModel w = new personal_workModel();
            ViewData["data_work"] = w.tb_work_person(person);

        }
        public void select_train(string person) {

            personal_trainModel tr = new personal_trainModel();
            ViewData["data_train"] = tr.tb_train_person(person);
        }
         //[HttpPost]
        public string insertPersonal(string prefix_th, string name_th, string lastname_th, string prefix_en, string name_en, string lastname_en, string gender, string blood, string national_id, string national_start, string national_end, string birthday, string age, string nationality, string race, string marital, string gion) {

            personalModel ps = new personalModel();
            ps.prefix_th = prefix_th;
            ps.prefix_en = prefix_en;
            ps.name_th = name_th;
            ps.name_en = name_en;
            ps.lastname_th = lastname_th;
            ps.lastname_en = lastname_en;
            ps.gender = gender;
            ps.blood = blood;
            ps.national_id = national_id;
            ps.national_start = national_start;
            ps.national_end = national_end;
            ps.birthday = birthday;
            ps.nationality = nationality;
            ps.race = race;
            ps.religion = gion;
            ps.marital = marital;
            ps.insertPersonal();

            DateTime dt = new DateTime(3000,01,01);
            personalChangeModel pc = new personalChangeModel();
            pc.ch_ref_prefix_id = prefix_th;
            pc.ch_ref_prefix_id_old = prefix_th;
            pc.ch_ref_person_id = ps.personal_id;
            pc.ch_name_th = name_th;
            pc.ch_name_th_old = name_th;
            pc.ch_name_en = name_en;
            pc.ch_name_en_old = name_en;
            pc.ch_lastname_th = lastname_th;
            pc.ch_lastname_th_old = lastname_th;
            pc.ch_lastname_en = lastname_en;
            pc.ch_lastname_en_old = lastname_en;
            pc.ch_start_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            pc.ch_end_date = Convert.ToDateTime(dt).ToString("yyyy-MM-dd HH:mm:ss");
            pc.insert_person_change();


            return ps.personal_id;
        }
        public string checkName(string name, string lastname) {

            personalModel ps = new personalModel();


            return ps.checkName(name, lastname);
        }
        public IActionResult insertAddress(string add_num, string add_moo, string add_type, string add_name, string add_alley, string add_road, string add_district, string add_amphur, string add_province, string add_code, string add_num1, string add_moo1, string add_type1, string add_name1, string add_alley1, string add_road1, string add_district1, string add_amphur1, string add_province1, string add_code1) {

            AddressModel ads = new AddressModel();

            ads.address_num = add_num;
            ads.address_moo = add_moo;
            ads.address_type = add_type;
            ads.address_name = add_name;
            ads.address_alley = add_alley;
            ads.address_road = add_road;
            ads.address_district_id = add_district;
            ads.address_amphur_id = add_amphur;
            ads.address_province_id = add_province;
            ads.address_postcode = add_code;

            ads.address_num_call = add_num1;
            ads.address_moo_call = add_moo1;
            ads.address_type_call = add_type1;
            ads.address_name_call = add_name1;
            ads.address_alley_call = add_alley1;
            ads.address_road_call = add_road1;
            ads.address_district_id_call = add_district1;
            ads.address_amphur_id_call = add_amphur1;
            ads.address_province_id_call = add_province1;
            ads.address_postcode_call = add_code1;

            ads.insertAddress();
            return View();
        }
        public string getAmphur(string id) {

            amphurModel amphur = new amphurModel();

            return amphur.getamphur(id);

        }
        public string getDistrict(string id)
        {

            districtModel dis = new districtModel();

            return dis.getDistinct(id);

        }
        public string address(string num, string moo, string type, string name, string alley, string road, string province, string amphur, string district, string code, string num1, string moo1, string type1, string name1, string alley1, string road1, string province1, string amphur1, string district1, string code1, string personal) {


            AddressModel add = new AddressModel();

            add.address_num = num;
            add.address_num_call = num1;
            add.address_moo = moo;
            add.address_moo_call = moo1;
            add.address_type = type;
            add.address_type_call = type1;
            add.address_name = name;
            add.address_name_call = name;
            add.address_alley = alley;
            add.address_alley_call = alley1;
            add.address_road = road;
            add.address_road_call = road1;
            add.address_province_id = province;
            add.address_province_id_call = province1;
            add.address_amphur_id = amphur;
            add.address_amphur_id_call = amphur1;
            add.address_district_id = district;
            add.address_district_id_call = district1;
            add.address_postcode = code;
            add.address_postcode_call = code1;
            add.address_ref_emp_id = personal;

            add.insertAddress();

            return "ok";
        }

        public void contact(string mail, string tel, string table, string mobile1, string mobile2, string person) {

            emp_contactModel ct = new emp_contactModel();

            ct.contact_email = mail;
            ct.contact_phone = tel;
            ct.contact_table = table;
            ct.contact_mobile1 = mobile1;
            ct.contact_mobile2 = mobile2;
            ct.contact_emp_id = person;

            ct.insert_contact();

        }
        //[HttpPost]
        //public IActionResult Family(string d_name, string d_last, string d_age, string d_num, string d_moo, string d_pro, string d_amp, string d_dis, string d_post, string d_tel, string d_mo, string m_name, string m_last, string m_age, string m_num, string m_moo, string m_pro, string m_amp, string m_dis, string m_post, string m_tel, string m_mo, string ma_name, string ma_last, string ma_age, string ma_num, string ma_moo, string ma_pro, string ma_amp, string ma_dis, string ma_post, string ma_tel, string ma_mo, string person) {
    public string Family(string dad_name, string dad_lastname, string dad_age, string dad_num, string dad_moo, string dadProvince, string dad_amphur, string dad_district, string dad_postcode, string dad_tel, string dad_mobile, string mom_name, string mom_lastname, string mom_age, string mom_num, string mom_moo, string mom_province, string mom_amphur, string mom_district, string mom_postcode, string mom_tel, string mom_mobile, string mar_name, string mar_lastname, string mar_age, string mar_num, string mar_moo, string mar_province, string mar_amphur, string mar_district, string mar_postcode, string mar_tel, string mar_mobile, string person) { 
            personal_familyModel fm = new personal_familyModel();
            fm.fam_name_dad = dad_name;
            fm.fam_lastname_dad = dad_lastname;
            fm.fam_age_dad = dad_age;
            fm.fam_num_dad = dad_num;
            fm.fam_moo_dad = "0";//dad_moo;
            fm.fam_province_dad = dadProvince;
            fm.fam_amphur_dad = "1";//dad_amphur;
            fm.fam_district_dad = "1"; //dad_district;
            fm.fam_postcode_dad = dad_postcode;
            fm.fam_tel_dad = dad_tel;
            fm.fam_mobile_dad = dad_mobile;

            //
            fm.fam_name_mom = mom_name;
            fm.fam_lastname_mom = mom_lastname;
            fm.fam_age_mom = mom_age;
            fm.fam_num_mom = mom_num;
            fm.fam_moo_mom = mom_moo;
            fm.fam_province_mom = mom_province;
            fm.fam_amphur_mom = "1";// mom_amphur;
            fm.fam_district_mom = "1"; //mom_district;
            fm.fam_postcode_mom = mom_postcode;
            fm.fam_tel_mom = mom_tel;
            fm.fam_mobile_mom = mom_mobile;
            //
            fm.fam_name_marry = mar_name;
            fm.fam_lastname_marry = mar_lastname;
            fm.fam_age_marry = mar_age;
            fm.fam_num_marry = mar_num;
            fm.fam_moo_marry = mar_moo;
            fm.fam_province_marry = mar_province;
            fm.fam_amphur_marry = "1"; //mar_amphur;
            fm.fam_district_marry = "1";// mar_district;
            fm.fam_postcode_marry = mar_postcode;
            fm.fam_tel_marry = mar_tel;
            fm.fam_mobile_marry = mar_mobile;

            fm.person_id = person;

            fm.insertFamily();

            string aa ="-"+ fm.fam_name_dad+
                       "-"+ fm.fam_lastname_dad +
                       "-"+ fm.fam_age_dad+
                       "-"+ fm.fam_num_dad+
                       "-"+ fm.fam_moo_dad+
                       "-"+ fm.fam_province_dad+
                       "-"+ fm.fam_amphur_dad+
                       "-"+ fm.fam_district_dad+
                       "-"+ fm.fam_postcode_dad+
                       "-"+ fm.fam_tel_dad+
                       "-"+ fm.fam_mobile_dad+
                       "-"+ fm.fam_name_mom+
                       "-"+ fm.fam_lastname_mom+
                       "-"+ fm.fam_age_mom+
                       "-"+ fm.fam_num_mom+
                       "-"+ fm.fam_moo_mom+
                       "-"+ fm.fam_province_mom+
                       "-"+ fm.fam_amphur_mom+
                       "-"+ fm.fam_district_mom+
                       "-"+ fm.fam_postcode_mom+
                       "-"+ fm.fam_tel_mom+
                       "-"+ fm.fam_mobile_mom+
                       "-"+ fm.fam_name_marry+
                       "-"+ fm.fam_lastname_marry+
                       "-"+ fm.fam_age_marry+
                       "-"+ fm.fam_num_marry+
                       "-"+ fm.fam_moo_marry+
                       "-"+ fm.fam_province_marry+
                       "-"+ fm.fam_amphur_marry+
                       "-"+ fm.fam_district_marry+
                       "-"+ fm.fam_postcode_marry+
                       "-"+ fm.fam_tel_marry+
                       "-"+ fm.fam_mobile_marry+
                       "-"+ fm.person_id;

            return aa;
        }

        public string Kid(int num, string name, string lastname, string age, string status, string level, string school,string person ) {

            string[] res_name = name.Split('^');
            string[] res_lastname = lastname.Split('^');
            string[] res_age = age.Split('^');
            string[] res_status = status.Split('^');
            string[] res_level = level.Split('^');
            string[] res_school = level.Split('^');

            int lentg = res_name.Length;

            personal_kidModel k = new personal_kidModel();

            for (int i = 0; i < num; i++) {


                k.kid_name = res_name[i];
                k.kid_lastname = res_lastname[i];
                k.kid_age = res_age[i];
                k.kid_study_status = res_status[i];
                k.kid_study_level = res_level[i];
                k.kid_study_school = res_school[i];
                k.kid_ref_personal_id = person;

                k.insertKid();


            }



            //

            return "ok";
        }
        public string Study(string year, string academy, string gpa, string degree, string branch, int num, string person) {


            personal_studyModel st = new personal_studyModel();

            string[] res_year = year.Split('^');
            string[] res_academy = academy.Split('^');
            string[] res_gpa = gpa.Split('^');
            string[] res_degree = degree.Split('^');
            string[] res_branch = branch.Split('^');
            int i = 0;

            for (i = 0; i < num; i++) {

                st.study_year = res_year[i];
                st.study_academy = res_academy[i];
                st.study_gpa = res_gpa[i];
                st.study_degree = res_degree[i];
                st.study_branch = res_branch[i];
                st.study_ref_personal_id = person;


                st.insertStudy();
            }


           


            return "ok";
        }
        public string Work(string company, string address, string position, string start, string end, string person, int num) {

            string[] txt_company = company.Split('^');
            string[] txt_address = address.Split('^');
            string[] txt_position = position.Split('^');
            string[] txt_start = start.Split('^');
            string[] txt_end = end.Split('^');
            int i = 0;

            personal_workModel w = new personal_workModel();

            for (i = 0; i < num; i++) {


                w.work_company = txt_company[i];
                w.work_address = txt_address[i];
                w.work_position = txt_position[i];
                w.work_start = txt_start[i];
                w.work_end = txt_end[i];
                w.work_ref_personal_id = person;


                w.insertWork();

            }


            return "ok";

        }
        public string Train(string title, string location, string start, string end, int num, string person) {

            string[] txt_title = title.Split('^');
            string[] txt_location = location.Split('^');
            string[] txt_start = start.Split('^');
            string[] txt_end = end.Split('^');
            int i = 0;

            personal_trainModel tr = new personal_trainModel();

            for (i = 0; i < num; i++) {

                tr.train_title = txt_title[i];
                tr.train_location = txt_location[i];
                tr.train_start = txt_start[i];
                tr.train_end = txt_end[i];
                tr.train_ref_personal_id = person;

                tr.insertTrain();
            }

            return "ok";
        }
        public IActionResult update_person_profile(string emp_id, string gender_edit, string blood_edit, string national_id_edit, string national_start_edit, string national_end_edit, string birthday_edit, string age_edit, string nationality_edit, string race_edit, string religion_edit, string marital_edit) {

            personalModel ps = new personalModel();

            ps.select_person_byEmp(emp_id);
            ps.insertPersonalLOG();

            ps.gender = gender_edit;
            ps.blood = blood_edit;
            ps.national_id = national_id_edit;
            ps.national_start = national_start_edit;
            ps.national_end = national_end_edit;
            ps.birthday = birthday_edit;
            ps.age = age_edit;
            ps.nationality = nationality_edit;
            ps.race = race_edit;
            ps.religion = religion_edit;
            ps.marital = marital_edit;

            ps.updatePersonal();

            return RedirectToAction("emp","Employee", new { code = emp_id });
        }
        [HttpPost]
        public IActionResult updatePerson(string person_id, string prefix_th, string name_th, string lastname_th, string prefix_en, string name_en, string lastname_en, string gender, string blood, string national_id, string national_start, string national_end, string birthday, string age, string nationality, string race, string religion, string marital) {

            personalModel ps = new personalModel();

            ps.select_personal(person_id);
            ps.insertPersonalLOG();

            ps.personal_id = person_id;
            ps.prefix_th = prefix_th;
            ps.name_th = name_th;
            ps.lastname_th = lastname_th;
            ps.prefix_en = prefix_en;
            ps.name_en = name_en;
            ps.lastname_en = lastname_en;
            ps.gender = gender;
            ps.blood = blood;
            ps.national_id = national_id;
            ps.national_start = national_start;
            ps.national_end = national_end;
            ps.birthday = birthday;
            ps.nationality = nationality;
            ps.race = race;
            ps.religion = religion;
            ps.marital = marital;
            ps.event_status = "U";

            ps.updatePerson();
           
            return RedirectToAction("editPersonal","Personal", new { person = person_id});
        }
        public void tabPerson(string tab) {

            HttpContext.Session.SetString("tabClick", tab);
        }
        public void delPerson(string id) {

            
        }
    }
}