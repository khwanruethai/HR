using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class departmentModel
    {
        public string dept_id { get; set; }
        public string dept_name { get; set; }

        databaseClass db = new databaseClass();
        dbFile connect = new dbFile();

        public List<SelectListItem> drop_dep ()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_department", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    items.Add(new SelectListItem { Text=rdr["dept_name"].ToString(), Value=rdr["dept_id"].ToString()});

                }

                conn.Close();
            }


            items.Insert(0,new SelectListItem { Text="เลือกแผนก", Value="0"});


                return items;

        }
       
        public string deptList()
        {

            string txt = "";

            using (SqlConnection conn = new SqlConnection(connect.sqlConnection))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_department", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    txt += "<option>" + rdr["dept_name"] + "</option>";

                }

                conn.Close();
            }

            return txt;
        }
        public List<info_positionModel> tablePosition()
        {

            List<info_positionModel> obj = new List<info_positionModel>();
            using (SqlConnection conn = new SqlConnection(connect.sqlConnection))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_position WHERE event_status != 'D'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

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

    }
}
