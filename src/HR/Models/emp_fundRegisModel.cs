using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class emp_fundRegisModel
    {
        public string fr_id { get; set; }
        public string fr_ref_fund_id { get; set; }
        public string fr_fund_name { get; set; }
        public string fr_date_start { get; set; }
        public string fr_date_end { get; set; }
        public string fr_ref_emp_id { get; set; }
        public string fr_admin_id { get; set; }
        public string fr_submit_date { get; set; }
        public string fr_check { get; set; }
        public string fr_return { get; set; }
        public string fr_status { get; set; }
        
        public string fund_code { get; set; }

        public string event_status { get; set; }
        databaseClass db = new databaseClass();
        dbFile connect = new dbFile();
        CultureInfo en = new CultureInfo("EN");

        public string connectionString() {

            return connect.sqlConnection;
        }
        public string checkFund(string emp) {

            using (SqlConnection conn = new SqlConnection(connectionString())) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(fr_ref_emp_id) AS checkFund FROM tab_emp_fundRegis WHERE fr_ref_emp_id = '" + emp+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    fr_check = rdr["checkFund"].ToString();

                }

                conn.Close();
            }

                return fr_check;
        }
        public List<emp_fundRegisModel> selectFundByEmp(string emp) {

            List<emp_fundRegisModel> obj = new List<emp_fundRegisModel>();
            using (SqlConnection conn = new SqlConnection(connectionString())) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_fundRegis INNER JOIN tab_info_fund ON tab_info_fund.fund_id = fr_ref_fund_id WHERE fr_ref_emp_id = '"+emp+"' AND fr_status = 'Y'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    emp_fundRegisModel fr = new emp_fundRegisModel();
                    fr.fr_id = rdr["fr_id"].ToString();
                    fr.fr_ref_fund_id = rdr["fr_ref_fund_id"].ToString();
                    fr.fr_fund_name = rdr["fund_name"].ToString();
                    fr.fr_date_start = rdr["fr_date_start"].ToString();
                    fr.fr_date_end = rdr["fr_date_end"].ToString();
                    fr.fr_ref_emp_id = rdr["fr_ref_emp_id"].ToString();
                    fr.fr_admin_id = rdr["fr_admin_id"].ToString();
                    fr.fr_submit_date = rdr["fr_submit_date"].ToString();
                    fr.fr_status = rdr["fr_status"].ToString();
                    fr.fund_code = rdr["fund_code"].ToString();
                    obj.Add(fr);
                }

                conn.Close();
            }
                return obj;
        }
        public string select_dataFund(string fund) {

            using (SqlConnection conn = new SqlConnection(connectionString())) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_fundRegis WHERE fr_id = '"+fund+"'",conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                   fr_id = rdr["fr_id"].ToString();
                   fr_ref_fund_id = rdr["fr_ref_fund_id"].ToString();
                   fr_date_start = Convert.ToDateTime(rdr["fr_date_start"]).ToString("dd/MM/yyyy");
                   fr_date_end = rdr["fr_date_end"].ToString();
                   fr_ref_emp_id = rdr["fr_ref_emp_id"].ToString();
                   fr_admin_id = rdr["fr_admin_id"].ToString();
                   fr_submit_date = rdr["fr_submit_date"].ToString();
                   fr_status = rdr["fr_status"].ToString();
                    event_status = rdr["event_status"].ToString();
                }
                conn.Close();
            }

            fr_return = fr_id + "^" + fr_ref_fund_id + "^" + fr_date_start + "^" + fr_date_end + "^" + fr_status;
            return fr_return;
        }
        public void insertFundRegis() {

            DateTime dt = new DateTime(3000,01,01);

            string table = "tab_emp_fundRegis";
            string[] Columns = { "fr_ref_fund_id", "fr_date_start", "fr_date_end", "fr_ref_emp_id", "fr_admin_id", "fr_submit_date", "fr_status" ,"event_status"};
            string[] Value = { fr_ref_fund_id, Convert.ToDateTime(fr_date_start).ToString("yyyy-MM-dd",en),  Convert.ToDateTime(dt).ToString("yyyy-MM-dd",en), fr_ref_emp_id, "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss",en), "Y", "S"};
            db.insert_db(table, Columns, Value);
        }
        public void updateFund() {

            string table = "tab_emp_fundRegis";
            string[] Columns = { "fr_ref_fund_id", "fr_date_start", "fr_date_end", "fr_ref_emp_id", "fr_admin_id", "fr_submit_date", "fr_status", "event_status" };
            string[] Value = { fr_ref_fund_id, Convert.ToDateTime(fr_date_start).ToString("yyyy-MM-dd", en), Convert.ToDateTime(fr_date_end).ToString("yyyy-MM-dd", en), fr_ref_emp_id, "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss",en), fr_status,event_status };
            string where = "fr_id = '"+fr_id+"'";

            db.update(table, Columns, Value, where);

        }
        public void insertFundLOG() {

            databaseClassLOG dbl = new databaseClassLOG();
            string table = "tab_emp_fundRegis";
            string[] Columns = { "fr_id","fr_ref_fund_id", "fr_date_start", "fr_date_end", "fr_ref_emp_id", "fr_admin_id", "fr_submit_date", "fr_status" };
            string[] Value = { fr_id, fr_ref_fund_id, Convert.ToDateTime(fr_date_start).ToString("yyyy-MM-dd",en), Convert.ToDateTime(fr_date_end).ToString("yyyy-MM-dd",en), fr_ref_emp_id, fr_admin_id, Convert.ToDateTime(fr_submit_date).ToString("yyyy-MM-dd HH:mm:ss",en),fr_status };
            dbl.insert(table, Columns, Value);

        }
      
    }
}
