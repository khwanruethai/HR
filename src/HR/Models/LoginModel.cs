using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class LoginModel
    {
        public int admin_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string admin_status { get; set; }
        public string emp_id { get; set; }

        public string controll { get; set; }
        public string action { get; set; }

        dbFile db = new dbFile();


        public void loginAccount()
        {
            dbFile db = new dbFile();
            string return_page = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(db.sqlConnection))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM tab_admin  INNER JOIN  tab_emp_action ON tab_emp_action.emp_id = tab_admin.emp_id  WHERE username = '" + username + "'  AND password ='" + password + "'  ", conn);

                    SqlDataReader rdr = cmd.ExecuteReader();


                    Boolean flag = false; // กำหนดให้ flag = เท็จ
                    while (rdr.Read())
                    {
                        admin_id = rdr.GetInt32(0);
                        flag = true;

                        username = rdr["username"].ToString();
                        emp_id = rdr["emp_id"].ToString();
                        admin_status = rdr["admin_status"].ToString();//  Session["username"] = name;

                    }


                    if (flag) // ถ้าเป็นจริงให้ทำ...
                    {
                        controll = "Employee";
                        action = "Index";
                    }
                    else {


                        controll = "Login";
                        action = "Index";
                    }

                    conn.Close();
                }
            }
            catch
            {
                controll = "Login";
                action = "Index";

            }
         
        }
        public void test() {

            //SqlConnection cnn;
           
            //string connectiongstring = ConfigurationSettings.AppSettings["SqlConnectionString"];
           
            //cnn = new SqlConnection(connectiongstring);

        }
     
    }
}
