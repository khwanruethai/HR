using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class empModel
    {
        public string ep_id { get; set; }
        public string ep_code { get; set; }
        public string ep_ref_personal_id { get; set; }
        public string ep_ref_type_id { get; set; }
        public string ep_start { get; set; }
        public string ep_end { get; set; }
        public string ep_status { get; set; }
        public string ep_submit_date { get; set; }
        public string ep_ref_admin_id { get; set; }
        //
        public string year { get; set; }
        public string shotYear { get; set; }
        public string month { get; set; }
        public int count { get; set; }
        public string resultCode { get; set; }
        
        //img
        public string img_id { get; set; }
        public string img_name { get; set; }
        public string img_ref_emp_id { get; set;}
        public string img_ref_person_id { get; set; }
        public string img_ref_admin_id { get; set; }
        public string img_submit_date { get; set; }
        public string img_status { get; set; }

        public string event_status { get; set; }



        CultureInfo th = new CultureInfo("TH");
        CultureInfo en = new CultureInfo("EN");

        public void countEmpforCode()
        {

            DateTime dt = Convert.ToDateTime(ep_start);
            year = dt.Year.ToString();
            month = dt.Month.ToString();

            dbFile db = new dbFile();
            using (SqlConnection conn = new SqlConnection(db.sqlConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(ep_id) AS numCount FROM tab_emp WHERE YEAR(ep_start) = '"+Convert.ToDateTime(ep_start).ToString("yyyy",en)+"' AND MONTH(ep_start) = '"+Convert.ToDateTime(ep_start).ToString("MM",en)+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    count = (Convert.ToInt32(rdr["numCount"]) + 1);
                }
                conn.Close();
            }

            shotYear = Convert.ToDateTime(ep_start).ToString("yy", th);
            resultCode = shotYear + month.ToString().PadLeft(2, '0') + count.ToString().PadLeft(2, '0');
        }
        public void insertEmp()
        {
            CultureInfo en = new CultureInfo("EN");

            countEmpforCode();

            DateTime dt = new DateTime(3000,01,01);

            databaseClass db = new databaseClass();

            string table = "tab_emp";
            string[] Columns = { "ep_code", "ep_ref_personal_id", "ep_ref_type_id", "ep_start", "ep_end", "ep_status", "ep_submit_date", "ep_ref_admin_id" , "event_status"};
            string[] Value = {

                resultCode,
                ep_ref_personal_id,
                ep_ref_type_id,
                Convert.ToDateTime(ep_start).ToString("yyyy-MM-dd", en),
                Convert.ToDateTime(dt).ToString("yyyy-MM-dd", en),
                "Y",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en),
                "1",
                "S"

            };

            ep_id = db.insert(table, Columns, Value);
            
        }
        public string empCode(string id) {

            string txt = "";

            dbFile db = new dbFile();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT ep_code FROM tab_emp WHERE ep_id = '"+id+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {


                    txt = rdr["ep_code"].ToString();
                }

                conn.Close();
            }

            return txt;
        }
        public string empPerson(string id)
        {

            string txt = "";

            dbFile db = new dbFile();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT ep_ref_personal_id FROM tab_emp WHERE ep_id = '" + id + "'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {


                    txt = rdr["ep_ref_personal_id"].ToString();
                }

                conn.Close();
            }

            return txt;
        }
        public void select_emp(string emp_id) {

            dbFile db = new dbFile();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp WHERE ep_id = '"+emp_id+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    ep_id = rdr["ep_id"].ToString();
                    ep_code = rdr["ep_code"].ToString();
                    ep_ref_personal_id = rdr["ep_ref_personal_id"].ToString();
                    ep_ref_type_id = rdr["ep_ref_type_id"].ToString();
                    ep_start = rdr["ep_start"].ToString();
                    ep_end = rdr["ep_end"].ToString();
                    ep_status = rdr["ep_status"].ToString();
                    ep_submit_date = rdr["ep_submit_date"].ToString();
                    ep_ref_admin_id = rdr["ep_ref_admin_id"].ToString();
                    event_status = rdr["event_status"].ToString();
                }

                conn.Close();
            }


        }
        public void insertEmpLOG()
        {
            CultureInfo en = new CultureInfo("EN");
            databaseClassLOG dbl = new databaseClassLOG();

            string table = "tab_emp";
            string[] Columns = { "ep_id","ep_code", "ep_ref_personal_id", "ep_ref_type_id", "ep_start", "ep_end", "ep_status", "ep_submit_date", "ep_ref_admin_id", "event_status" };
            string[] Value = {
                ep_id,
                ep_code,
                ep_ref_personal_id,
                ep_ref_type_id,
                Convert.ToDateTime(ep_start).ToString("yyyy-MM-dd", en),
                Convert.ToDateTime(ep_end).ToString("yyyy-MM-dd", en),
                ep_status,
                Convert.ToDateTime(ep_submit_date).ToString("yyyy-MM-dd HH:mm:ss", en),
                ep_ref_admin_id,
                event_status

            };

           dbl.insert(table, Columns, Value);

        }
        public void update_emp()
        {
            CultureInfo en = new CultureInfo("EN");
            databaseClass db = new databaseClass();

            string table = "tab_emp";
            string[] Columns = { "ep_code", "ep_ref_personal_id", "ep_ref_type_id", "ep_start", "ep_end", "ep_status", "ep_submit_date", "ep_ref_admin_id", "event_status" };
            string[] Value = {
                
                ep_code,
                ep_ref_personal_id,
                ep_ref_type_id,
                Convert.ToDateTime(ep_start).ToString("yyyy-MM-dd", en),
                Convert.ToDateTime(ep_end).ToString("yyyy-MM-dd", en),
                ep_status,
                Convert.ToDateTime(ep_submit_date).ToString("yyyy-MM-dd HH:mm:ss", en),
                ep_ref_admin_id,
                event_status

            };
            string where = "ep_id = '"+ep_id+"'";

         db.update(table, Columns, Value, where);

        }
        public void  check_img(string emp_id) {

           dbFile db = new dbFile();


         //   string txt = "";
            using (SqlConnection conn = new SqlConnection(db.sqlConnection))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_profile_img WHERE img_ref_emp_id = '"+emp_id+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                     
                    if (string.IsNullOrEmpty(rdr["img_ref_emp_id"].ToString()) == true)
                    {
                        img_status = "N";
                        img_name = "face-2.jpg";
                    }
                    else
                    {

                        img_status = "Y";

                        img_id = rdr["img_id"].ToString();
                        img_name = rdr["img_name"].ToString();
                        img_ref_emp_id = rdr["img_ref_emp_id"].ToString();
                        img_ref_person_id = rdr["img_ref_person_id"].ToString();
                        img_ref_admin_id = rdr["img_ref_admin_id"].ToString();
                        img_submit_date = rdr["img_submit_date"].ToString();

                    }

               

                }

                conn.Close();
            }


           // return txt;
        }
        public void insert_img() {

            databaseClass dbc = new databaseClass();

            string table = "tab_emp_profile_img";
            string[] Columns = { "img_name", "img_ref_emp_id", "img_ref_person_id", "img_ref_admin_id", "img_submit_date" };
            string[] Value = { img_name, img_ref_emp_id, img_ref_person_id, "1", Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss",en)};

            dbc.insert(table, Columns, Value);

        }
        public void insert_imgLOG()
        {

            databaseClassLOG dbl = new databaseClassLOG();

            string table = "tab_emp_profile_img";
            string[] Columns = { "img_id", "img_name", "img_ref_emp_id", "img_ref_person_id", "img_ref_admin_id", "img_submit_date" };
            string[] Value = { img_id, img_name, img_ref_emp_id, img_ref_person_id, img_ref_admin_id, Convert.ToDateTime(img_submit_date).ToString("yyyy-MM-dd HH:mm:ss", en) };

            dbl.insert(table, Columns, Value);

        }
        public void update_img() {

            databaseClass dbc = new databaseClass();
            
            string table = "tab_emp_profile_img";
            string[] Columns = { "img_name", "img_ref_emp_id", "img_ref_person_id", "img_ref_admin_id", "img_submit_date" };
            string[] Value = { img_name, img_ref_emp_id, img_ref_person_id, "1", Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss", en) };
            string where = "img_id = '"+img_id+"'";

            dbc.update(table, Columns, Value, where);
        }
        public List<SelectListItem> drop_emp_resign(string emp = "") {

            List<SelectListItem> item = new List<SelectListItem>();
            dbFile db = new dbFile();
            string where = "";

            if (string.IsNullOrEmpty(emp) == true) {

                // where   = " WHERE ep_end BETWEEN '" + DateTime.Now.ToString("yyyy-MM-dd", en) + "' AND '3000-01-01'";
                where = " WHERE ep_status = 'Y'";
            }
            int i = 0;
            
            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT ep_code, ps_name_full, ep_id FROM view_employee " + where+ " GROUP BY ep_code, ps_name_full, ep_id", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    if (string.IsNullOrEmpty(emp) == true)
                    {


                        if (i == 0)
                        {
                            item.Insert(0, new SelectListItem { Text = "เลือกพนักงาน" });
                            item.Add(new SelectListItem { Text = rdr["ep_code"] + "|" + rdr["ps_name_full"], Value = rdr["ep_id"].ToString() });
                        }
                        else {


                            item.Add(new SelectListItem { Text = rdr["ep_code"] + "|" + rdr["ps_name_full"], Value = rdr["ep_id"].ToString() });
                        }

                        

                    }
                    else {

                        if (emp == rdr["ep_id"].ToString())
                        {
                            item.Add(new SelectListItem { Text = rdr["ep_code"] + "|" + rdr["ps_name_full"], Value = rdr["ep_id"].ToString(), Selected = true });
                        }
                        else
                        {
                            item.Add(new SelectListItem { Text = rdr["ep_code"] + "|" + rdr["ps_name_full"], Value = rdr["ep_id"].ToString() });
                        }
                    }

                    i++;
                }
                conn.Close();
            }
            
                return item;
        }
        public List<SelectListItem> drop_emp_Fund(string emp = "")
        {

            List<SelectListItem> item = new List<SelectListItem>();
            dbFile db = new dbFile();
            string where = "";

            if (string.IsNullOrEmpty(emp) == true)
            {

                // where   = " WHERE ep_end BETWEEN '" + DateTime.Now.ToString("yyyy-MM-dd", en) + "' AND '3000-01-01'";
                where = " WHERE fund.fr_status = 'Y' ";
            }
            int i = 0;

            using (SqlConnection conn = new SqlConnection(db.sqlConnection))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT emp.ep_id, emp.ep_code,ps.ps_name_th +'   '+ ps.ps_lastname_th AS fullName"+
                                                   " FROM tab_emp_fundRegis AS fund"+
                                                   " INNER JOIN tab_emp AS emp ON emp.ep_id = fund.fr_ref_emp_id"+
                                                   " INNER JOIN tab_personal AS ps ON ps.ps_id = emp.ep_ref_personal_id"+
                                                   where +
                                                   " GROUP BY emp.ep_id, ps.ps_name_th, ps.ps_lastname_th, emp.ep_code", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    if (string.IsNullOrEmpty(emp) == true)
                    {


                        if (i == 0)
                        {
                            item.Insert(0, new SelectListItem { Text = "เลือกพนักงาน" });
                            item.Add(new SelectListItem { Text = rdr["ep_code"] + "|" + rdr["fullName"], Value = rdr["ep_id"].ToString() });
                        }
                        else
                        {


                            item.Add(new SelectListItem { Text = rdr["ep_code"] + "|" + rdr["fullName"], Value = rdr["ep_id"].ToString() });
                        }



                    }
                    else
                    {

                        if (emp == rdr["ep_id"].ToString())
                        {
                            item.Add(new SelectListItem { Text = rdr["ep_code"] + "|" + rdr["ps_name_full"], Value = rdr["ep_id"].ToString(), Selected = true });
                        }
                        else
                        {
                            item.Add(new SelectListItem { Text = rdr["ep_code"] + "|" + rdr["ps_name_full"], Value = rdr["ep_id"].ToString() });
                        }
                    }

                    i++;
                }
                conn.Close();
            }

            return item;
        }
    }
}
