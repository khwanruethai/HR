using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class info_positionModel
    {
        public string post_id { get; set; }
        public string post_name { get; set; }
        public string post_admin { get; set; }
        public string post_submit_date { get; set; }
        public string event_status { get; set; }

        databaseClass db = new databaseClass();
        dbFile connect = new dbFile();

        CultureInfo th = new CultureInfo("TH");
        CultureInfo en = new CultureInfo("EN");
        public List<info_positionModel> tablePosition() {

            List<info_positionModel> obj = new List<info_positionModel>();
            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_position WHERE event_status != 'D'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    info_positionModel post = new info_positionModel();
                    post.post_id = rdr["post_id"].ToString();
                    post.post_name = rdr["post_name"].ToString();
                    post.post_admin = rdr["post_admin"].ToString();
                    post.post_submit_date = rdr["post_submit_date"].ToString();
                    obj.Add(post);
                }
                
                conn.Close();
            }
            
           return obj;
        }
        public void insertPosition() {

            string table = "tab_position";
            string[] Columns = { "post_name", "post_admin", "post_submit_date", "event_status" };
            string[] Value = { post_name, "1", DateTime.Now.ToString("yyyy-MM-dd", en), "S" };
            db.insert_db(table, Columns, Value);
        }
        public void selectBYpost_id(string post) {

            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_position WHERE post_id = '"+post+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    post_id = rdr["post_id"].ToString();
                    post_name = rdr["post_name"].ToString();
                    post_admin = rdr["post_admin"].ToString();
                    post_submit_date = Convert.ToDateTime(rdr["post_submit_date"]).ToString("dd/MM/yyyy",th);
                    event_status = rdr["event_status"].ToString();
                }

                conn.Close();
            }

        }
        public List<SelectListItem> dropDownPosition() {

            List<SelectListItem> items = new List<SelectListItem>();

            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_position WHERE event_status != 'D'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    items.Add(new SelectListItem { Text = rdr["post_name"].ToString(), Value = rdr["post_id"].ToString() });
                }
                conn.Close();
            }

            items.Insert(0, new SelectListItem { Text = "เลือกตำแหน่ง", Value = "0" });

            return items;
        }
        public string positionList() {


            string txt = "";

            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_position WHERE event_status != 'D'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    txt += "<option>"+rdr["post_name"]+"</option>";
                    
                }

                conn.Close();

            }

            return txt;
        }
        public void insertPositionLOG() {

            databaseClassLOG dbl = new databaseClassLOG();

            string table = "tab_position";
            string[] Columns = { "post_id","post_name", "post_admin", "post_submit_date", "event_status" };
            string[] Value = { post_id,post_name, post_admin, Convert.ToDateTime(post_submit_date).ToString("yyyy-MM-dd HH:mm:ss", en), event_status };

            dbl.insert(table, Columns, Value);
        }
        public void updatePosition() {

            string table = "tab_position";
            string[] Columns = {  "post_name", "post_admin", "post_submit_date" , "event_status"};
            string[] Value = {  post_name, post_admin, Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss", en), event_status };
            string where = "post_id = '"+post_id+"'";

            db.update(table, Columns, Value, where);
        }
    }
}
