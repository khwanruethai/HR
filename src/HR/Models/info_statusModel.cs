using HR.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class info_statusModel
    {
        public string status_id { get; set; }
        public string status_name { get; set; }
        public string status_date { get; set; }
        public string status_admin { get; set; }
        public string event_status { get; set; }
        dbFile strCon = new dbFile();
        databaseClass db = new databaseClass();
        CultureInfo en = new CultureInfo("EN");
        public List<info_statusModel> select_status() {

            List<info_statusModel> objSt = new List<info_statusModel>();
           
            using (SqlConnection conn = new SqlConnection(strCon.sqlConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_info_status WHERE event_status != 'D'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    info_statusModel st = new info_statusModel();

                    st.status_name = rdr["status_name"].ToString();
                    st.status_id = rdr["status_id"].ToString();

                    objSt.Add(st);

                }
                conn.Close();
            }

            return objSt;

        }
        public void insert_status() {

            string table = "tab_info_status";
            string[] Columns = { "status_name","status_submit_date","status_admin_id", "event_status" };
            string[] Value = { status_name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss",en), "1", "S"};
            db.insert(table, Columns, Value);

        }
        public List<SelectListItem> dropdown_status() {

            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(strCon.sqlConnection)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT status_id, status_name FROM tab_info_status WHERE event_status != 'D'",conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    items.Add(new SelectListItem { Text = rdr["status_name"].ToString(), Value = rdr["status_id"].ToString()});

               }
            }

            return items;
        }
        public string statusList() {

            string txt = "";

            using (SqlConnection conn = new SqlConnection(strCon.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_info_status WHERE event_status != 'D'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    txt += "<option>"+rdr["status_name"] +"</option>";

                }

                conn.Close();
            }

                return txt;
            
        }
        public void selectStatusbyId(string status) {

            using (SqlConnection conn = new SqlConnection(strCon.sqlConnection)) {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_info_status WHERE status_id = '"+status+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    status_id = rdr["status_id"].ToString();
                    status_name = rdr["status_name"].ToString();
                    status_date = rdr["status_submit_date"].ToString();
                    status_admin = rdr["status_admin_id"].ToString();
                    event_status = rdr["event_status"].ToString();
                }

                conn.Close();
            }

        }
        public void insertStatusLOG() {

            databaseClassLOG dbl = new databaseClassLOG();

            string table = "tab_info_status";
            string[] Columns = {"status_id", "status_name", "status_submit_date", "status_admin_id", "event_status" };
            string[] Value = { status_id,status_name, Convert.ToDateTime(status_date).ToString("yyyy-MM-dd HH:mm:ss",en), status_admin , event_status};

            dbl.insert(table, Columns, Value);

        }
        public void update_Status()
        {
            databaseClass dbc = new databaseClass();

            string table = "tab_info_status";
            string[] Columns = { "status_name", "status_submit_date", "status_admin_id" , "event_status"};
            string[] Value = { status_name, Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss",en), "1" , event_status};
            string where = "status_id = '"+status_id+"'";

            dbc.update(table, Columns, Value, where);

        }
    }
}
