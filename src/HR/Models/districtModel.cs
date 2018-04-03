using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class districtModel
    {
        public string district_id { get; set; }
        public string district_code { get; set; }
        public string district_name { get; set; }
        public string district_ref_amphur_id { get; set; }
        public string district_ref_province_id { get; set; }

        dbFile connect = new dbFile();
        public string connectionString() {

            return connect.sqlConnection;
        }

        public List<SelectListItem> select_district() {

            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(connectionString())) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_district", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    items.Add(new SelectListItem { Text = rdr["district_name"].ToString(), Value = rdr["district_id"].ToString() });

                }

                conn.Close();
            }

                return items;
        }
        public List<SelectListItem> select_district_forEdit(string dis)
        {

            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(connectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_district", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr["district_id"].ToString() == dis) {

                        items.Insert(0, new SelectListItem { Text = rdr["district_name"].ToString(), Value = rdr["district_id"].ToString() });

                    }

                    items.Add(new SelectListItem { Text = rdr["district_name"].ToString(), Value = rdr["district_id"].ToString() });

                }

                conn.Close();
            }

            return items;
        }
        public string  getDistinct(string amphur="") {

            string result = "";

            using (SqlConnection conn = new SqlConnection(connectionString())) {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_district WHERE district_ref_ampur_id = '"+amphur+"'",conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    result += "<option value='"+rdr["district_id"]+"'>"+rdr["district_name"]+"</option>";

                }

                conn.Close();
            }
            
            return result;
        }
        
    }
}
