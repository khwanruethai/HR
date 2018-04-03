using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class amphurModel
    {
        public string amphur_id { get; set; }
        public string amphur_code { get; set; }
        public string amphur_name { get; set; }
        public string amphur_ref_province_id { get; set; }

        dbFile connect = new dbFile();
        public string connectionString() {

            return connect.sqlConnection;
        }
        public List<SelectListItem> select_amphur() {

            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(connectionString()))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_amphur", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    items.Add(new SelectListItem { Text = rdr["amphur_name"].ToString(), Value = rdr["amphur_id"].ToString() });

                }
                conn.Close();
            }


            return items;
        }

        public List<SelectListItem> select_amphur_forEdit(string amphur)
        {

            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(connectionString()))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_amphur", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    if (rdr["amphur_id"].ToString() == amphur)
                    {
                        items.Insert(0, new SelectListItem { Text = rdr["amphur_name"].ToString(), Value = rdr["amphur_id"].ToString() });
                    }
                   

                        items.Add(new SelectListItem { Text = rdr["amphur_name"].ToString(), Value = rdr["amphur_id"].ToString() });
                   

                }
                conn.Close();
            }


            return items;
        }

        public string  getamphur(string province = "")
        {
            string result = "";
           
            using (SqlConnection conn = new SqlConnection(connectionString()))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_amphur WHERE amphur_ref_province_id = '"+ province +"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    result += "<option value='"+rdr["amphur_id"]+"'>"+rdr["amphur_name"]+"</option>";
                    //result +=  rdr["amphur_name"] ;

                }
                conn.Close();
            }


            return result;
        }
        
    }
}
