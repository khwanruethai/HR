using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class info_incomeModel
    {
        public string income_id { get; set; }
        public string income_name { get; set; }
        public string income_submit_date { get; set; }
        public string income_admin { get; set; }
        public string event_status { get; set; }
        databaseClass db = new databaseClass();
        dbFile conStr = new dbFile();
        CultureInfo en = new CultureInfo("EN");
        public List<info_incomeModel> select_income() {

            List<info_incomeModel> obj = new List<info_incomeModel>();
            using (SqlConnection conn = new SqlConnection(conStr.sqlConnection)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_info_income WHERE event_status != 'D'",conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    info_incomeModel inc = new info_incomeModel();
                    inc.income_id = rdr["income_id"].ToString();
                    inc.income_name = rdr["income_name"].ToString();

                    obj.Add(inc);
                  
                }
                conn.Close();
            }

                return obj;

        }
        public void insert_income() {

            string table = "tab_info_income";
            string[] Columns = { "income_name","income_submit_date","income_admin_id", "event_status"};
            string[] Value = { income_name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "1", "S" };

            db.insert(table, Columns, Value);

        }
        public List<SelectListItem> selectIncome() {

            List<SelectListItem> items = new List<SelectListItem>();

            using (SqlConnection conn = new SqlConnection(conStr.sqlConnection)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_info_income WHERE  chk_fix = 'Y' AND event_status NOT LIKE '%D%'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    items.Add(new SelectListItem { Text = rdr["income_name"].ToString(), Value = rdr["income_id"].ToString() });

                }

                conn.Close();
            }

                return items;
        }
    
        public string selectIncome_new()
        {
            string result = "";
       
            using (SqlConnection conn = new SqlConnection(conStr.sqlConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_info_income WHERE chk_fix = 'Y' AND  event_status NOT LIKE '%D%'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    result += "<option value = '"+rdr["income_id"]+"'>"+rdr["income_name"]+"</option>";
                }

                conn.Close();
            }

            return result;
        }
       
        public string check_income(string id) {

            string txt = "";

            using (SqlConnection conn = new SqlConnection(conStr.sqlConnection)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT income_name FROM tab_info_income WHERE chk_fix = 'Y' AND  income_id = '" + id+"' AND event_status NOT LIKE '%D%'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    txt = rdr["income_name"].ToString();

                }

                conn.Close();
            }


            return txt;
        }
        public void selectincome_id(string income) {

            using (SqlConnection conn = new SqlConnection(conStr.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_info_income WHERE chk_fix = 'Y' AND  income_id = '" + income+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    income_id = rdr["income_id"].ToString();
                    income_name = rdr["income_name"].ToString();
                    income_submit_date = rdr["income_submit_date"].ToString();
                    income_admin = rdr["income_admin_id"].ToString();
                    event_status = rdr["event_status"].ToString();

                }

                conn.Close();
            }
        }
        public void insertIncomeLOG() {

            databaseClassLOG dbl = new databaseClassLOG();

            string table = "tab_info_income";
            string[] Columns = { "income_id","income_name", "income_submit_date", "income_admin_id", "event_status" };
            string[] Value = { income_id,income_name, Convert.ToDateTime(income_submit_date).ToString("yyyy-MM-dd HH:mm:ss", en), income_admin, event_status };

            dbl.insert(table, Columns, Value);

        }
        public void updateIncome() {

            string table = "tab_info_income";
            string[] Columns = {  "income_name", "income_submit_date", "income_admin_id", "event_status" };
            string[] Value = {  income_name, Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss",en), "1" , event_status};
            string where = "income_id = '"+income_id+"'";

            db.update(table, Columns, Value, where);

        }
        public string  select_income_emp(List<string> where) {


            string result = "";

            int len = where.Count();
            int last = (len - 1);
            string where_ = "";
            for (int i = 0; i < len; i++) {

                if (i == last)
                {

                    where_ += " income_id != '" + where[i]+"'";
                }
                else {
                    where_ += " income_id != '"+ where[i] + "' AND ";

                }


            }

            using (SqlConnection conn = new SqlConnection(conStr.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_info_income WHERE chk_fix = 'Y' AND  " + where_+" AND event_status != 'D'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {


                    result += "<option value='"+rdr["income_id"]+"'>"+rdr["income_name"]+"</option>";

                }

                conn.Close();
            }

            return result;
        }
       
    }
}
