using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Models;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace HR.Models
{
    public class info_minusModel
    {
        public string minus_id { get; set; }
        public string minus_name { get; set; }
        public string minus_date { get; set; }
        public string minus_admin { get; set; }
        public string event_status { get; set; }
        databaseClass db = new databaseClass();
        dbFile conStr = new dbFile();
        CultureInfo en = new CultureInfo("EN");
        public List<info_minusModel> select_minus() {

            List<info_minusModel> obj = new List<info_minusModel>();
            using (SqlConnection conn = new SqlConnection(conStr.sqlConnection)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_info_minus WHERE event_status NOT LIKE '%D%'",conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    info_minusModel minus = new info_minusModel();
                    minus.minus_id = rdr["minus_id"].ToString();
                    minus.minus_name = rdr["minus_name"].ToString();

                    obj.Add(minus);
                }
                conn.Close();

            }

                return obj;
        }
        public List<SelectListItem> selectMinus()
        {

            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(conStr.sqlConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_info_minus WHERE event_status NOT LIKE '%D%'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    items.Add(new SelectListItem { Text = rdr["minus_name"].ToString(), Value = rdr["minus_id"].ToString() });
                    
                }

                conn.Close();
            }


            return items;
        }
        public void insert_minus() {

            string table = "tab_info_minus";
            string[] Columns = { "minus_name","minus_submit_date","minus_admin_id", "event_status" };
            string[] Value = { minus_name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "1", "S" };
            db.insert_db(table, Columns, Value);

        }
        public void selectMinusId(string minus) {

            using (SqlConnection conn = new SqlConnection(conStr.sqlConnection)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_info_minus WHERE minus_id = '"+minus+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    minus_id = rdr["minus_id"].ToString();
                    minus_name = rdr["minus_name"].ToString();
                    minus_date = rdr["minus_submit_date"].ToString();
                    minus_admin = rdr["minus_admin_id"].ToString();
                    event_status = rdr["event_status"].ToString();
                }
                
                conn.Close();
            }

        }
        public void insertMinusLOG() {

            databaseClassLOG dbl = new databaseClassLOG();

            string table = "tab_info_minus";
            string[] Columns = { "minus_id","minus_name", "minus_submit_date", "minus_admin_id" , "event_status"};
            string[] Value = { minus_id,minus_name, Convert.ToDateTime(minus_date).ToString("yyyy-MM-dd HH:mm:ss", en), minus_admin , event_status};
            
            dbl.insert(table, Columns, Value);
        }
        public void updateMinus() {

            string table = "tab_info_minus";
            string[] Columns = { "minus_name", "minus_submit_date", "minus_admin_id", "event_status" };
            string[] Value = { minus_name, Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss",en), "1", event_status };
            string where = "minus_id = '"+minus_id+"'";

            db.update(table, Columns, Value, where);
        }
        public string select_minus_emp(List<string> where)
        {
            
            string result = "";

            int len = where.Count();
            int last = (len - 1);
            string where_ = "";
            for (int i = 0; i < len; i++)
            {

                if (i == last)
                {

                    where_ += " minus_id != '" + where[i] + "'";
                }
                else
                {
                    where_ += " minus_id != '" + where[i] + "' AND ";

                }


            }

            using (SqlConnection conn = new SqlConnection(conStr.sqlConnection))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_info_minus WHERE " + where_ + " AND event_status != 'D'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    
                    result += "<option value='" + rdr["minus_id"] + "'>" + rdr["minus_name"] + "</option>";

                }

                conn.Close();
            }

            return result;
        }

    }
}
