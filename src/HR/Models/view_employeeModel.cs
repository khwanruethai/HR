using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class view_employeeModel
    {
        
        public string ep_id { get; set; }
        public string ep_code { get; set; }
        public string ep_ref_personal_id { get; set; }
        public string prefix_name_th { get; set; }
        public string prefix_name_en { get; set; }
        public string ps_name_th { get; set; }
        public string ps_lastname_th { get; set; }
        public string ps_name_en { get; set; }
        public string ps_lastname_en { get; set; }
        public string ep_ref_type_id { get; set; }
        public string type_name { get; set; }
        public string ep_start { get; set; }
        public string ep_end { get; set; }
        public string ep_status { get; set; }
        public string ep_submit_date { get; set; }
        public string ep_ref_admin_id { get; set; }
        public string ps_name_full { get; set; }
        public string position_posit_id { get; set; }
        public string post_name { get; set; }
        public string position_comp_id { get; set; }
        public string T_Company { get; set; }
        public string position_sect_id { get; set; }
        public string Section_name { get; set; }
        public string position_dept_id { get; set; }
        public string dept_name { get; set; }
        public string position_active { get; set; }
        //contact
        public string contact_id { get; set; }
        public string contact_email { get; set; }
        public string contact_table { get; set; }
        public string contact_phone { get; set; }
        public string contact_mobile1 { get; set; }
        public string contact_mobile2 { get; set; }
        //personal
        public string ps_gender { get; set; }
        public string ps_blood { get; set; }
        public string ps_national_id { get; set; }
        public string ps_national_date_start { get; set; }
        public string ps_national_date_end { get; set; }
        public string ps_birthday { get; set; }
        public string ps_nationality { get; set; }
        public string ps_race { get; set; }
        public string ps_religion { get; set; }
        public string ps_status_marital { get; set; }

        //
        public string type_resign { get; set; }
        public string detail_resign { get; set; }
        public string submit_resign { get; set; }
        public string resign_id { get; set; }

        dbFile db = new dbFile();

        public void selectData(string id) {

            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM view_employee WHERE ep_id = '"+id+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    ep_id = rdr["ep_id"].ToString();
                    ep_code = rdr["ep_code"].ToString();
                    ep_ref_personal_id = rdr["ep_ref_personal_id"].ToString();
                    prefix_name_th = rdr["prefix_name_th"].ToString();
                    prefix_name_en = rdr["prefix_name_en"].ToString();
                    ps_name_th = rdr["ps_name_th"].ToString();
                    ps_lastname_th = rdr["ps_lastname_th"].ToString();
                    ps_name_en = rdr["ps_name_en"].ToString();
                    ps_lastname_en = rdr["ps_lastname_en"].ToString();
                    ep_ref_type_id = rdr["ep_ref_type_id"].ToString();
                    type_name = rdr["type_name"].ToString();
                    ep_start =  Convert.ToDateTime(rdr["ep_start"]).ToString("dd MMMM yyyy");
                    ep_end = Convert.ToDateTime(rdr["ep_end"]).ToString("ddMMyyyy");

                    if (ep_end == "01013000")
                    {
                        ep_end = "-";

                    }
                    else {

                        ep_end = Convert.ToDateTime(rdr["ep_end"]).ToString("dd MMMM yyyy");

                    }

                    if (rdr["ep_status"].ToString() == "Y")
                    {
                        ep_status = "ดำเนินการ";
                    }
                    else {

                        ep_status = "ลาออก";
                    }

                    ep_submit_date = rdr["ep_submit_date"].ToString();
                    ep_ref_admin_id = rdr["ep_ref_admin_id"].ToString();
                    ps_name_full = rdr["ps_name_full"].ToString();
                    position_posit_id = rdr["position_posit_id"].ToString();
                    post_name = rdr["post_name"].ToString();
                    position_comp_id = rdr["position_comp_id"].ToString();
                    T_Company = rdr["T_Company"].ToString();
                    position_sect_id = rdr["position_sect_id"].ToString();
                    Section_name = rdr["Section_name"].ToString();
                    position_dept_id = rdr["position_dept_id"].ToString();
                    dept_name = rdr["dept_name"].ToString();

                    contact_id = rdr["contact_id"].ToString();
                    contact_email = rdr["contact_email"].ToString();
                    contact_table = rdr["contact_table"].ToString();
                    contact_phone = rdr["contact_phone"].ToString();
                    contact_mobile1 = rdr["contact_mobile1"].ToString();
                    contact_mobile2 = rdr["contact_mobile2"].ToString();

                    ps_gender = rdr["ps_gender"].ToString();
                    ps_blood = rdr["ps_blood"].ToString();
                    ps_national_id = rdr["ps_national_id"].ToString();
                    ps_national_date_start = rdr["ps_national_date_start"].ToString();
                    ps_national_date_end = rdr["ps_national_date_end"].ToString();
                    ps_birthday = rdr["ps_birthday"].ToString();
                    ps_nationality = rdr["ps_nationality"].ToString();
                    ps_race = rdr["ps_race"].ToString();
                    ps_religion = rdr["ps_religion"].ToString();
                    ps_status_marital = rdr["ps_status_marital"].ToString();

                }
                conn.Close();

            }

        }
        public List<view_employeeModel> emp_data()
        {

            List<view_employeeModel> obj = new List<view_employeeModel>();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection))
            {

                conn.Open();

               
                SqlCommand cmd = new SqlCommand("SELECT * FROM view_employee WHERE position_active = 'Y' AND position_status = 'Y' ORDER BY ep_code ASC", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    view_employeeModel emp = new view_employeeModel();

                    emp.ep_id = rdr["ep_id"].ToString();
                    emp.ep_code = rdr["ep_code"].ToString();
                    emp.ep_ref_personal_id = rdr["ep_ref_personal_id"].ToString();
                    emp.prefix_name_th = rdr["prefix_name_th"].ToString();
                    emp.prefix_name_en = rdr["prefix_name_en"].ToString();
                    emp.ps_name_th = rdr["ps_name_th"].ToString();
                    emp.ps_lastname_th = rdr["ps_lastname_th"].ToString();
                    emp.ps_name_en = rdr["ps_name_en"].ToString();
                    emp.ps_lastname_en = rdr["ps_lastname_en"].ToString();
                    emp.ep_ref_type_id = rdr["ep_ref_type_id"].ToString();
                    emp.type_name = rdr["type_name"].ToString();
                    emp.ep_start = Convert.ToDateTime(rdr["ep_start"]).ToString("dd MMMM yyyy");
                    emp.ep_end = rdr["ep_end"].ToString();

                    if (Convert.ToDateTime(rdr["ep_end"]) < DateTime.Now)
                    {
                        emp.ep_status = "ลาออก";
                    }
                    else {

                        emp.ep_status = "ดำเนินการ";
                    }

                    //if (rdr["ep_status"].ToString() == "Y")
                    //{
                    //    emp.ep_status = "ดำเนินการ";
                    //}
                    //else
                    //{

                    //    emp.ep_status = "ลาออก";
                    //}

                    emp.ep_submit_date = rdr["ep_submit_date"].ToString();
                    emp.ep_ref_admin_id = rdr["ep_ref_admin_id"].ToString();
                    emp.ps_name_full = rdr["ps_name_full"].ToString();
                    emp.position_posit_id = rdr["position_posit_id"].ToString();
                    emp.post_name = rdr["post_name"].ToString();
                    emp.position_comp_id = rdr["position_comp_id"].ToString();
                    emp.T_Company = rdr["T_Company"].ToString();
                    emp.position_sect_id = rdr["position_sect_id"].ToString();
                    emp.Section_name = rdr["Section_name"].ToString();
                    emp.position_dept_id = rdr["position_dept_id"].ToString();
                    emp.dept_name = rdr["dept_name"].ToString();

                    emp.contact_id = rdr["contact_id"].ToString();
                    emp.contact_email = rdr["contact_email"].ToString();
                    emp.contact_table = rdr["contact_table"].ToString();
                    emp.contact_phone = rdr["contact_phone"].ToString();
                    emp.contact_mobile1 = rdr["contact_mobile1"].ToString();
                    emp.contact_mobile2 = rdr["contact_mobile2"].ToString();

                    emp.ps_gender = rdr["ps_gender"].ToString();
                    emp.ps_blood = rdr["ps_blood"].ToString();
                    emp.ps_national_id = rdr["ps_national_id"].ToString();
                    emp.ps_national_date_start = rdr["ps_national_date_start"].ToString();
                    emp.ps_national_date_end = rdr["ps_national_date_end"].ToString();
                    emp.ps_birthday = rdr["ps_birthday"].ToString();
                    emp.ps_nationality = rdr["ps_nationality"].ToString();
                    emp.ps_race = rdr["ps_race"].ToString();
                    emp.ps_religion = rdr["ps_religion"].ToString();
                    emp.ps_status_marital = rdr["ps_status_marital"].ToString();

                    emp.position_active = rdr["position_active"].ToString();

                    obj.Add(emp);
                }
                conn.Close();

            }


            return obj;

        }
        public string  check_img(string emp_id)
        {

            dbFile db = new dbFile();


              string txt = "";
            string check = "";
            using (SqlConnection conn = new SqlConnection(db.sqlConnection))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_profile_img WHERE img_ref_emp_id = '"+emp_id+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    check = rdr["img_ref_emp_id"].ToString();

                    if (string.IsNullOrEmpty(check) == true)
                    {
                        txt = "N";
                        //img_name = "face-2.jpg";
                    }
                    else
                    {
                        txt = "Y";
                        
                    }
                    
                }

                conn.Close();
            }


             return txt;
        }

        public List<view_employeeModel> emp_data_resign()
        {

            List<view_employeeModel> obj = new List<view_employeeModel>();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection))
            {

                conn.Open();


                SqlCommand cmd = new SqlCommand("SELECT * FROM view_employee AS vw"+
                                              "  INNER JOIN tab_emp_resign AS rs ON rs.re_ref_emp_id = vw.ep_id"+
                                              "  WHERE ep_status = 'N'  ORDER BY re_submit_date DESC", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    view_employeeModel emp = new view_employeeModel();

                    emp.ep_id = rdr["ep_id"].ToString();
                    emp.ep_code = rdr["ep_code"].ToString();
                    emp.ep_ref_personal_id = rdr["ep_ref_personal_id"].ToString();
                    emp.prefix_name_th = rdr["prefix_name_th"].ToString();
                    emp.prefix_name_en = rdr["prefix_name_en"].ToString();
                    emp.ps_name_th = rdr["ps_name_th"].ToString();
                    emp.ps_lastname_th = rdr["ps_lastname_th"].ToString();
                    emp.ps_name_en = rdr["ps_name_en"].ToString();
                    emp.ps_lastname_en = rdr["ps_lastname_en"].ToString();
                    emp.ep_ref_type_id = rdr["ep_ref_type_id"].ToString();
                    emp.type_name = rdr["type_name"].ToString();
                    emp.ep_start = Convert.ToDateTime(rdr["ep_start"]).ToString("dd MMMM yyyy");
                    emp.ep_end = Convert.ToDateTime(rdr["ep_end"]).ToString("dd MMMM yyyy");

                    if (Convert.ToDateTime(rdr["ep_end"]) < DateTime.Now)
                    {
                        emp.ep_status = "ลาออก";
                    }
                    else
                    {

                        emp.ep_status = "ดำเนินการ";
                    }

                    //if (rdr["ep_status"].ToString() == "Y")
                    //{
                    //    emp.ep_status = "ดำเนินการ";
                    //}
                    //else
                    //{

                    //    emp.ep_status = "ลาออก";
                    //}

                    emp.ep_submit_date = rdr["ep_submit_date"].ToString();
                    emp.ep_ref_admin_id = rdr["ep_ref_admin_id"].ToString();
                    emp.ps_name_full = rdr["ps_name_full"].ToString();
                    emp.position_posit_id = rdr["position_posit_id"].ToString();
                    emp.post_name = rdr["post_name"].ToString();
                    emp.position_comp_id = rdr["position_comp_id"].ToString();
                    emp.T_Company = rdr["T_Company"].ToString();
                    emp.position_sect_id = rdr["position_sect_id"].ToString();
                    emp.Section_name = rdr["Section_name"].ToString();
                    emp.position_dept_id = rdr["position_dept_id"].ToString();
                    emp.dept_name = rdr["dept_name"].ToString();

                    emp.contact_id = rdr["contact_id"].ToString();
                    emp.contact_email = rdr["contact_email"].ToString();
                    emp.contact_table = rdr["contact_table"].ToString();
                    emp.contact_phone = rdr["contact_phone"].ToString();
                    emp.contact_mobile1 = rdr["contact_mobile1"].ToString();
                    emp.contact_mobile2 = rdr["contact_mobile2"].ToString();

                    emp.ps_gender = rdr["ps_gender"].ToString();
                    emp.ps_blood = rdr["ps_blood"].ToString();
                    emp.ps_national_id = rdr["ps_national_id"].ToString();
                    emp.ps_national_date_start = rdr["ps_national_date_start"].ToString();
                    emp.ps_national_date_end = rdr["ps_national_date_end"].ToString();
                    emp.ps_birthday = rdr["ps_birthday"].ToString();
                    emp.ps_nationality = rdr["ps_nationality"].ToString();
                    emp.ps_race = rdr["ps_race"].ToString();
                    emp.ps_religion = rdr["ps_religion"].ToString();
                    emp.ps_status_marital = rdr["ps_status_marital"].ToString();

                    emp.type_resign = rdr["re_type"].ToString();
                    emp.detail_resign = rdr["re_detail"].ToString();
                    emp.submit_resign = rdr["re_submit_date"].ToString();
                    emp.resign_id = rdr["re_id"].ToString();


                    obj.Add(emp);
                }
                conn.Close();

            }


            return obj;

        }

    }

}
