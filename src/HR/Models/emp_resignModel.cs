using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class emp_resignModel
    {
        public string re_id { get; set; }
        public string re_ref_emp_id { get; set; }
        public string re_emp_code { get; set; }
        public string re_type { get; set; }
        public string re_detail { get; set; }
        public string re_resign_date { get; set; }
        public string re_submit_date { get; set; }
        public string re_admin_id { get; set; }
        public string event_status { get; set; }

        CultureInfo en = new CultureInfo("EN");

        public void insert_resign() {

            databaseClass db = new databaseClass();

            string table = "tab_emp_resign";
            string[] Columns = {
               "re_ref_emp_id",
               "re_emp_code", 
               "re_type", 
               "re_detail", 
               "re_resign_date", 
               "re_submit_date", 
               "re_admin_id", 
               "event_status" 
            };
            string[] Value = {
               re_ref_emp_id,
               re_emp_code,
               re_type,
               re_detail,
               Convert.ToDateTime(re_resign_date).ToString("yyyy-MM-dd", en),
               DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en),
               "1",
               "S"
            };


            db.insert(table, Columns, Value);


        }
        public void update_resign()
        {

            databaseClass db = new databaseClass();

            string table = "tab_emp_resign";
            string[] Columns = {
               "re_ref_emp_id",
               "re_emp_code",
               "re_type",
               "re_detail",
               "re_resign_date",
               "re_submit_date",
               "re_admin_id",
               "event_status"
            };
            string[] Value = {
               re_ref_emp_id,
               re_emp_code,
               re_type,
               re_detail,
               Convert.ToDateTime(re_resign_date).ToString("yyyy-MM-dd",en),
               DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss",en),
               re_admin_id,
               event_status
            };
            string where = "re_id = '"+re_id+"'";


            db.update(table, Columns, Value, where);


        }
        public void insert_resignLOG()
        {

            databaseClassLOG db = new databaseClassLOG();

            string table = "tab_emp_resign";
            string[] Columns = {
               "re_id",
               "re_ref_emp_id",
               "re_emp_code",
               "re_type",
               "re_detail",
               "re_resign_date",
               "re_submit_date",
               "re_admin_id",
               "event_status"
            };
            string[] Value = {
                re_id,
               re_ref_emp_id,
               re_emp_code,
               re_type,
               re_detail,
               Convert.ToDateTime(re_resign_date).ToString("yyyy-MM-dd",en),
               Convert.ToDateTime(re_submit_date).ToString("yyyy-MM-dd HH:mm:ss",en),
               re_admin_id,
               event_status
            };


            db.insert(table, Columns, Value);


        }
        public List<emp_resignModel> list_resign() {

            List<emp_resignModel> obj = new List<emp_resignModel>();
            dbFile db = new dbFile();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_resign",conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    emp_resignModel rs = new emp_resignModel();
                    rs.re_id = rdr["re_id"].ToString();
                    rs.re_ref_emp_id = rdr["re_ref_emp_id"].ToString();
                    rs.re_emp_code = rdr["re_emp_code"].ToString();
                    rs.re_type = rdr["re_type"].ToString();
                    rs.re_detail = rdr["re_detail"].ToString();
                    rs.re_resign_date = rdr["re_resign_date"].ToString();
                    rs.re_submit_date = rdr["re_submit_date"].ToString();
                    rs.re_admin_id = rdr["re_admin_id"].ToString();
                    rs.event_status = rdr["event_status"].ToString();
                    obj.Add(rs);
                }

                conn.Close();
            }


            return obj;
        }
        public void select_resign() {


            dbFile db = new dbFile();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_resign WHERE re_id = '"+re_id+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    
                   re_id = rdr["re_id"].ToString();
                   re_ref_emp_id = rdr["re_ref_emp_id"].ToString();
                   re_emp_code = rdr["re_emp_code"].ToString();
                   re_type = rdr["re_type"].ToString();
                   re_detail = rdr["re_detail"].ToString();
                   re_resign_date = rdr["re_resign_date"].ToString();
                   re_submit_date = rdr["re_submit_date"].ToString();
                   re_admin_id = rdr["re_admin_id"].ToString();
                   event_status = rdr["event_status"].ToString();
                   
                }

                conn.Close();
            }


        }

    }
}
