using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class emp_typeModel
    {
        public string type_id { get; set; }
        public string type_name { get; set; }
        public string type_submit_date { get; set; }
        public string type_admin_id { get; set; }
        public string type_salary { get; set; }
        public string type_chk_salary2 { get; set; }
        public string type_chk_incentive { get; set; }
        public string event_status { get; set; }

        databaseClass db = new databaseClass();
        dbFile conStr = new dbFile();
        CultureInfo en = new CultureInfo("EN");
        public List<emp_typeModel> select_type() {

            List<emp_typeModel> obj = new List<emp_typeModel>();

            using (SqlConnection conn = new SqlConnection(conStr.sqlConnection)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_type WHERE event_status != 'D'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {
                    emp_typeModel type = new emp_typeModel();
                    type.type_id = rdr["type_id"].ToString();
                    type.type_name = rdr["type_name"].ToString();
                    obj.Add(type);
                }
                conn.Close();

            }


          return obj;
        }
        public void insert_type() {

            string table = "tab_emp_type";
            string[] Columns = { "type_name","type_submit_date","type_admin_id", "event_status"};
            string[] Value= { type_name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "1", "S" };
            db.insert(table, Columns, Value);

        }
        public List<SelectListItem> dropdown_type()
        {
            AppConfig connect = new AppConfig();
            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(connect.sqlConnString1()))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT type_id, type_name FROM tab_emp_type WHERE event_status != 'D'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    items.Add(new SelectListItem { Text = rdr["type_name"].ToString(), Value = rdr["type_id"].ToString() });

                }
                conn.Close();
            }

            return items;
        }
        public List<SelectListItem> dropdown_type_id(string id)
        {
            AppConfig connect = new AppConfig();
            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(connect.sqlConnString1()))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT type_id, type_name FROM tab_emp_type WHERE event_status != 'D'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    if (rdr["type_id"].ToString() == id)
                    {
                        items.Add(new SelectListItem { Text = rdr["type_name"].ToString(), Value = rdr["type_id"].ToString(), Selected = true });

                    }
                    else {

                        items.Add(new SelectListItem { Text = rdr["type_name"].ToString(), Value = rdr["type_id"].ToString() });
                    }

                    

                }
                conn.Close();
            }

            return items;
        }
        public string typeList() {

            string txt = "";

            using (SqlConnection conn = new SqlConnection(conStr.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_type WHERE event_status != 'D'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    txt += "<option>"+rdr["type_name"]+"</option>";


                }

                conn.Close();
            }


                return txt;


        }
        public void selecTypebyId(string type) {

            using (SqlConnection conn = new SqlConnection(conStr.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_type WHERE type_id = '"+type+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    type_id = rdr["type_id"].ToString();
                    type_name = rdr["type_name"].ToString();
                    type_admin_id = rdr["type_admin_id"].ToString();
                    type_submit_date = rdr["type_submit_date"].ToString();
                    type_salary = rdr["type_salary"].ToString();
                    type_chk_salary2 = rdr["type_chk_salary2"].ToString();
                    type_chk_incentive = rdr["type_chk_incentive"].ToString();
                    event_status = rdr["event_status"].ToString();
                    
                }

                conn.Close();

            }
            
        }
        public void insertTypeLOG() {

            databaseClassLOG dbl = new databaseClassLOG();


            string table = "tab_emp_type";
            string[] Columns = { "type_id","type_name", "type_submit_date", "type_admin_id", "type_salary", "type_chk_salary2", "type_chk_incentive", "event_status" };
            string[] Value = { type_id,type_name, Convert.ToDateTime(type_submit_date).ToString("yyyy-MM-dd HH:mm:ss", en), type_admin_id, type_salary, type_chk_salary2, type_chk_incentive, event_status };

            dbl.insert(table, Columns, Value);

        }
        public void update_type() {

            string table = "tab_emp_type";
            string[] Columns = {  "type_name", "type_submit_date", "type_admin_id", "type_salary", "type_chk_salary2", "type_chk_incentive", "event_status" };
            string[] Value = {  type_name, Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss",en), "1", type_salary, type_chk_salary2, type_chk_incentive, event_status };
            string where = "type_id = '"+type_id+"'";

            db.update(table, Columns, Value, where);

        }
    }
}
