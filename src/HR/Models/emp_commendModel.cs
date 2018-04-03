using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class emp_commendModel
    {
        public string comm_id { get; set; }
        public string comm_date { get; set; }
        public string comm_title { get; set; }
        public string comm_detail { get; set; }
        public string comm_ref_emp_id { get; set; }
        public string comm_admin_id { get; set; }
        public string comm_submit_date { get; set; }
        public string comm_check { get; set; }
        public string comm_return { get; set; }
        databaseClass db = new databaseClass();
        dbFile connect = new dbFile();

        public string connectionString() {

            return connect.sqlConnection;
        }
        public string checkCommend(string emp) {

            using (SqlConnection conn = new SqlConnection(connectionString())) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(comm_ref_emp_id) AS checkCommend FROM tab_emp_commend WHERE comm_ref_emp_id = '"+emp+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    comm_check = rdr["checkCommend"].ToString();

                }

                conn.Close();
            }

                return comm_check;
        }
        public void insertCommend() {

            DateTime dt = Convert.ToDateTime(comm_date);
            comm_date = dt.Year + "-" + dt.Month + "-" + dt.Day;

            string table = "tab_emp_commend";
            string[] Columns = { "comm_date", "comm_title", "comm_detail", "comm_ref_emp_id", "comm_admin_id", "comm_submit_date" };
            string[] Value = {comm_date, comm_title, comm_detail, comm_ref_emp_id, "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") };
            db.insert_db(table, Columns, Value);

        }
        public List<emp_commendModel> selectCommbyEmp(string emp) {

            List<emp_commendModel> obj = new List<emp_commendModel>();
            using (SqlConnection conn = new SqlConnection(connectionString())) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_commend WHERE comm_ref_emp_id = '"+emp+"'",conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    emp_commendModel comm = new emp_commendModel();

                    comm.comm_id = rdr["comm_id"].ToString();
                    comm.comm_date = Convert.ToDateTime(rdr["comm_date"]).ToString("dd MMM yyyy");
                    comm.comm_title = rdr["comm_title"].ToString();
                    comm.comm_detail = rdr["comm_detail"].ToString();
                    comm.comm_ref_emp_id = rdr["comm_ref_emp_id"].ToString();
                    comm.comm_admin_id = rdr["comm_admin_id"].ToString();
                    comm.comm_submit_date = rdr["comm_submit_date"].ToString();
                    obj.Add(comm);
                }

                conn.Close();
            }

                return obj;
        }
        public string selectBycommId(string comm) {

            using (SqlConnection conn = new SqlConnection(connectionString())) {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_commend WHERE comm_id = '"+comm+"'",conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    comm_id = rdr["comm_id"].ToString();
                    comm_date = Convert.ToDateTime(rdr["comm_date"]).ToString("dd/MMM/yyyy");
                    comm_title = rdr["comm_title"].ToString();
                    comm_detail = rdr["comm_detail"].ToString();
                    comm_ref_emp_id = rdr["comm_ref_emp_id"].ToString();
                    comm_admin_id = rdr["comm_admin_id"].ToString();
                    comm_submit_date = rdr["comm_submit_date"].ToString();

                }


                conn.Close();
            }

            comm_return = comm_id + "^" + comm_date + "^" + comm_title + "^" + comm_detail;

            return comm_return;
        }
        public void insertCommendLOG() {

            databaseClassLOG dbl = new databaseClassLOG();

            CultureInfo en = new CultureInfo("EN");

            string table = "tab_emp_commend";
            string[] Columns = { "comm_id","comm_date", "comm_title", "comm_detail", "comm_ref_emp_id", "comm_admin_id", "comm_submit_date" };
            string[] Value = { comm_id ,Convert.ToDateTime(comm_date).ToString("yyyy-MM-dd",en), comm_title, comm_detail, comm_ref_emp_id, comm_admin_id, Convert.ToDateTime(comm_submit_date).ToString("yyyy-MM-dd HH:mm:ss") };

            dbl.insert(table, Columns, Value);

        }
        public void updateCommend() {

            CultureInfo en = new CultureInfo("EN");

            string table = "tab_emp_commend";
            string[] Columns = { "comm_date", "comm_title", "comm_detail", "comm_ref_emp_id", "comm_admin_id", "comm_submit_date" };
            string[] Value = { Convert.ToDateTime(comm_date).ToString("yyyy-MM-dd",en), comm_title, comm_detail, comm_ref_emp_id, "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") };
            string where = "comm_id = '"+comm_id+"'";

            db.update(table, Columns, Value, where);

        }
    }
}
