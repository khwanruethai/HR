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
    public class info_fundModel
    {
        public string fund_id { get; set; }
        public string fund_name { get; set; }
        public string fund_date { get; set; }
        public string fund_admin { get; set; }
        public string event_status { get; set; }
        public string fund_code { get; set; }
        //
        public string check { get; set; }
        //
        public string fund_result { get; set; }
        public List<string> fund { get; set; }

        databaseClass db = new databaseClass();
        CultureInfo en = new CultureInfo("EN");
        dbFile conStr = new dbFile();

        public void check_code_fund() {

            using (SqlConnection conn = new SqlConnection(conStr.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(fund_id) AS num FROM tab_info_fund WHERE fund_code = '"+fund_code+"' AND event_status != 'D'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    check = rdr["num"].ToString();

                }


                conn.Close();
            }


        }


        public List<info_fundModel> select_fund() {

            List<info_fundModel> obj = new List<info_fundModel>();
            using (SqlConnection conn = new SqlConnection(conStr.sqlConnection)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_info_fund WHERE event_status != 'D'",conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {
                    info_fundModel fund = new info_fundModel();
                    fund.fund_id = rdr["fund_id"].ToString();
                    fund.fund_name = rdr["fund_name"].ToString();
                    fund.fund_code = rdr["fund_code"].ToString();
                    obj.Add(fund);
                }
                conn.Close();
            }
            return obj;
        }
        public List<SelectListItem> dropdownFund() {

            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(conStr.sqlConnection)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_info_fund WHERE event_status NOT LIKE '%D%'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    items.Add(new SelectListItem { Text = rdr["fund_code"]+" | "+rdr["fund_name"].ToString(), Value = rdr["fund_id"].ToString() });
                   
                }

                conn.Close();
            }

            return items;
        }
        public void insert_fund() {

            string table = "tab_info_fund";
            string[] Columns = { "fund_name","fund_submit_date","fund_admin_id", "event_status", "fund_code"};
            string[] Value = { fund_name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "1" , "S", fund_code};
            db.insert_db(table, Columns, Value);

        }
        public void selectFund_id(string fund) {

            using (SqlConnection conn = new SqlConnection(conStr.sqlConnection)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_info_fund WHERE fund_id = '"+fund+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    fund_id = rdr["fund_id"].ToString();
                    fund_name = rdr["fund_name"].ToString();
                    fund_date = rdr["fund_submit_date"].ToString();
                    fund_admin = rdr["fund_admin_id"].ToString();
                    event_status = rdr["event_status"].ToString();
                    fund_code = rdr["fund_code"].ToString();
                }
                conn.Close();
            }

        }
        public void insertFundLOG() {


            databaseClassLOG dbl = new databaseClassLOG();

            string table = "tab_info_fund";
            string[] Columns = { "fund_id", "fund_name", "fund_submit_date", "fund_admin_id" , "event_status","fund_code"};
            string[] Value = { fund_id,fund_name, Convert.ToDateTime(fund_date).ToString("yyyy-MM-dd HH:mm:ss", en), fund_admin, event_status,fund_code };

            dbl.insert(table, Columns, Value);

        }
        public void updateFund() {


            string table = "tab_info_fund";
            string[] Columns = {  "fund_name", "fund_submit_date", "fund_admin_id" , "event_status","fund_code" };
            string[] Value = {  fund_name, Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss", en), "1" , event_status,fund_code};
            string where = "fund_id = '"+fund_id+"'";

            db.update(table, Columns, Value, where);

        }
        public string fundRefEmp(string emp = null, string fund = null) {

            // List<SelectListItem> item = new List<SelectListItem>();
            string select = "";
            int count = 0;

            using (SqlConnection conn = new SqlConnection(conStr.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * "+
                           " FROM tab_emp_fundRegis AS emp"+
                           " INNER JOIN tab_info_fund AS fn ON fn.fund_id = emp.fr_ref_fund_id"+
                           " WHERE (emp.fr_ref_emp_id = '"+emp+"' AND fr_status = 'Y') AND emp.event_status != 'D'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    if (string.IsNullOrEmpty(fund) == true)
                    {

                        if (count == 0)
                        {
                            select += "<option value='N'>เลือกกองทุน</option>";
                            select += "<option value='" + rdr["fr_id"].ToString() + "'>" + rdr["fund_code"] + " | " + rdr["fund_name"] + "</option>";
                        }
                        else {

                            select += "<option value='"+ rdr["fr_id"].ToString() + "'>"+ rdr["fund_code"] + " | " + rdr["fund_name"] + "</option>";
                        }
                    }
                    else {

                        if (rdr["fund_id"].ToString() == fund)
                        {
                            select += "<option value='" + rdr["fr_id"].ToString() + "' selected = true>" + rdr["fund_code"] + " | " + rdr["fund_name"] + "</option>";
                        }
                        else {

                            select += "<option value='" + rdr["fr_id"].ToString() + "'>" + rdr["fund_code"] + " | " + rdr["fund_name"] + "</option>";
                        }

                    
                    }


                    count++;

                }

                conn.Close();

            }
            
                return select;
        }
        public void check_fund(string emp) {

            fund = new List<string>();

            using (SqlConnection conn = new SqlConnection(conStr.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT fr_ref_fund_id FROM tab_emp_fundRegis WHERE fr_ref_emp_id = '"+emp+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    fund.Add(rdr["fr_ref_fund_id"].ToString());

                }

                conn.Close();
            }

            fund_result = "";

            foreach (string item in fund) {

                fund_result += "fund_id != '"+item +"' AND ";

            }


        }
        public string fundForChange(string fund = null, string emp= "")
        {

            check_fund(emp);
            // List<SelectListItem> item = new List<SelectListItem>();
            string select = "";
            int count = 0;

            using (SqlConnection conn = new SqlConnection(conStr.sqlConnection))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_info_fund WHERE fund_id != '"+fund+"' AND "+fund_result+" event_status != 'D'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                  

                        if (count == 0)
                        {
                            select += "<option value='N'>เลือกกองทุน</option>";
                            select += "<option value='" + rdr["fund_id"].ToString() + "'>" + rdr["fund_code"] + " | " + rdr["fund_name"] + "</option>";
                        }
                        else
                        {

                            select += "<option value='" + rdr["fund_id"].ToString() + "'>" + rdr["fund_code"] + " | " + rdr["fund_name"] + "</option>";
                        }
                  


                    count++;

                }

                conn.Close();

            }

            return select;
        }
    }
}
