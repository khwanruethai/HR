using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class emp_admonishModel
    {
        //admonish
        public string adm_id { get; set; }
        public string adm_date { get; set; }
        public string adm_title { get; set; }
        public string adm_detail { get; set; }
        public string adm_ref_emp_id { get; set; }
        public string adm_admin_id { get; set; }
        public string adm_submit_date { get; set; }
        public string adm_check { get; set; }
        public string adm_return { get; set; }
        databaseClass db = new databaseClass();
        dbFile connect = new dbFile();
        CultureInfo en = new CultureInfo("EN");
        public string connectionString()
        {

            return connect.sqlConnection;
        }
        public string checkAdmonish(string emp)
        {

            using (SqlConnection conn = new SqlConnection(connectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(adm_ref_emp_id) AS checkAdm FROM tab_emp_admonish WHERE adm_ref_emp_id = '" + emp + "'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    adm_check = rdr["checkAdm"].ToString();

                }

                conn.Close();
            }

            return adm_check;
        }
        public void insertAdmonish()
        {

            DateTime dt = Convert.ToDateTime(adm_date);
            adm_date = dt.Year + "-" + dt.Month + "-" + dt.Day;

            string table = "tab_emp_admonish";
            string[] Columns = { "adm_date", "adm_title", "adm_detail", "adm_ref_emp_id", "adm_admin_id", "adm_submit_date" };
            string[] Value = { adm_date, adm_title, adm_detail, adm_ref_emp_id, "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") };
            db.insert_db(table, Columns, Value);

        }
        public List<emp_admonishModel> selectAdmbyEmp(string emp)
        {

            List<emp_admonishModel> obj = new List<emp_admonishModel>();
            using (SqlConnection conn = new SqlConnection(connectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_admonish WHERE adm_ref_emp_id = '" + emp + "'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    emp_admonishModel adm = new emp_admonishModel();

                    adm.adm_id = rdr["adm_id"].ToString();
                    adm.adm_date = Convert.ToDateTime(rdr["adm_date"]).ToString("dd MMM yyyy");
                    adm.adm_title = rdr["adm_title"].ToString();
                    adm.adm_detail = rdr["adm_detail"].ToString();
                    adm.adm_ref_emp_id = rdr["adm_ref_emp_id"].ToString();
                    adm.adm_admin_id = rdr["adm_admin_id"].ToString();
                    adm.adm_submit_date = rdr["adm_submit_date"].ToString();
                    obj.Add(adm);
                }

                conn.Close();
            }

            return obj;
        }
        public string selectByadmId(string adm)
        {

            using (SqlConnection conn = new SqlConnection(connectionString()))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_admonish WHERE adm_id = '" + adm + "'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    adm_id = rdr["adm_id"].ToString();
                    adm_date = Convert.ToDateTime(rdr["adm_date"]).ToString("dd/MM/yyyy");
                    adm_title = rdr["adm_title"].ToString();
                    adm_detail = rdr["adm_detail"].ToString();
                    adm_ref_emp_id = rdr["adm_ref_emp_id"].ToString();
                    adm_admin_id = rdr["adm_admin_id"].ToString();
                    adm_submit_date = rdr["adm_submit_date"].ToString();

                }
                conn.Close();
            }

            adm_return = adm_id + "^" + adm_date + "^" + adm_title + "^" + adm_detail;

            return adm_return;
        }
        public void updateAdm() {

            string table = "tab_emp_admonish";
            string[] Columns = { "adm_date", "adm_title", "adm_detail", "adm_ref_emp_id", "adm_admin_id", "adm_submit_date" };
            string[] Value = { Convert.ToDateTime(adm_date).ToString("yyyy-MM-dd",en), adm_title, adm_detail, adm_ref_emp_id, "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") };
            string where = "adm_id = '"+adm_id+"'";

            db.update(table, Columns, Value, where);

        }
        public void insertAdmLOG() {

            databaseClassLOG dbl = new databaseClassLOG();

            string table = "tab_emp_admonish";
            string[] Columns = {"adm_id" ,"adm_date", "adm_title", "adm_detail", "adm_ref_emp_id", "adm_admin_id", "adm_submit_date" };
            string[] Value = {adm_id, Convert.ToDateTime(adm_date).ToString("yyyy-MM-dd",en), adm_title, adm_detail, adm_ref_emp_id, adm_admin_id, Convert.ToDateTime(adm_submit_date).ToString("yyyy-MM-dd HH:mm:ss") };

            dbl.insert(table, Columns, Value);

        }
    }
}
