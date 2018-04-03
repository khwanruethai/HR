using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class info_departmentModel
    {
        public string dept_id { get; set; }
        public string dept_name { get; set; }


        public List<info_departmentModel> list_dept() {

            dbFile db = new dbFile();

            List<info_departmentModel> obj = new List<info_departmentModel>();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_department",conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    info_departmentModel dt = new info_departmentModel();
                    dt.dept_id = rdr["dept_id"].ToString();
                    dt.dept_name = rdr["dept_name"].ToString();

                    obj.Add(dt);
                }

                conn.Close();
            }



                return obj;
        }
    }
}
