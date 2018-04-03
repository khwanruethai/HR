using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class provinceModel
    {
        public string province_id { get; set; }
        public string province_code { get; set; }
        public string province_name { get; set; }

        dbFile connect = new dbFile();

        public string connectionString() {

            return connect.sqlConnection;
        }
        public List<SelectListItem> selectProvince() {

            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(connectionString())) {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_province", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    items.Add(new SelectListItem { Text = rdr["province_name"].ToString(), Value = rdr["province_id"].ToString() });

                }

                items.Insert(0, new SelectListItem { Text="กรุณาเลือกจังหวัด", Value="0"});

                conn.Close();
            }

            return items;
        }
        public List<SelectListItem> selectProvince_forEdit(string prov)
        {

            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(connectionString()))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_province", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    if (rdr["province_id"].ToString() == prov) {

                        items.Insert(0, new SelectListItem { Text = rdr["province_name"].ToString(), Value = rdr["province_id"].ToString() });

                    }

                    items.Add(new SelectListItem { Text = rdr["province_name"].ToString(), Value = rdr["province_id"].ToString() });

                }

               

                conn.Close();
            }

            return items;
        }
    }
}
