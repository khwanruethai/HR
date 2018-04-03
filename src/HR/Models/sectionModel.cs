using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class sectionModel
    {
        public string section_id { get; set; }
        public string section_Code { get; set; }
        public string Section_name { get; set; }
        public string Code_Comp { get; set; }
        databaseClass db = new databaseClass();
        dbFile connect = new dbFile();

        public List<SelectListItem> drop_section() {

            List<SelectListItem> item = new List<SelectListItem>();

            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_section",conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    item.Add(new SelectListItem { Text=rdr["Section_name"].ToString(), Value=rdr["section_id"].ToString()});

                }
                conn.Close();
            }

            item.Insert(0, new SelectListItem {Text="เลือกฝ่าย",Value="0" });

                return item;
        }
        public string sectList() {

            string txt = "";

            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_section", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    txt += "<option>"+rdr["Section_name"] +"</option>";

                }
                
                conn.Close();
            }
            
            return txt;
        }
        public List<sectionModel> sect() {


            List<sectionModel> obj = new List<sectionModel>();


            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_section", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    sectionModel st = new sectionModel();

                    st.section_id = rdr["section_id"].ToString();
                    st.Section_name = rdr["Section_name"].ToString();

                    obj.Add(st);

                }


                conn.Close();
            }



                return obj;
        }

        
    }
}
