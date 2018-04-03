using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Models;
using System.Data.SqlClient;
using System.Globalization;

namespace HR.Models
{
    public class EmployeeModels
    {
        public  string turnId { get; set; }
        public string emp_id { get; set; }
        public string emp_code { get; set; }
        public string emp_prefix_th { get; set; }
        public string emp_prefix_en { get; set; }
        public string emp_name_th { get; set; }
        public string emp_name_en { get; set; }
        public string emp_lastname_th { get; set; }
        public string emp_lastname_en { get; set; }
        public string emp_status { get; set; }
        public string emp_type { get; set; }
        public string emp_start_date { get; set; }
        public string emp_end_date { get; set; }
        public string emp_admin_id { get; set; }
        public string emp_submit_date { get; set; }
        public string year { get; set; }
        public string shotYear { get; set; }
        public string month { get; set; }
        public int count { get; set; }
        public string resultCode { get; set; }

        dbFile conStr = new dbFile();
        databaseClass db = new databaseClass();
        CultureInfo th = new CultureInfo("th-TH");
        CultureInfo EN = new CultureInfo("EN");

        public string  constring() {

            return conStr.sqlConnection;
        }
        public void insertEmp() {

            countEmpforCode();

            string table = "tab_employee";
            string[] Columns = { "emp_code", "emp_prefix", "emp_name_th", "emp_lastname_th", "emp_prefix_en", "emp_name_en", "emp_lastname_en", "emp_status", "emp_type","emp_start_date", "emp_admin_id", "emp_submit_date", "emp_end_date"};
            string[] Value = {

                resultCode,
                emp_prefix_th,
                emp_name_th,
                emp_lastname_th,
                emp_prefix_en,
                emp_name_en,
                emp_lastname_en,
                emp_status,
                emp_type,
                Convert.ToDateTime(emp_start_date).ToString("yyyy-MM-dd",EN),
                "1",
               DateTime.Now.ToString("yyyy-MM-ss HH:mm:ss", EN),
               " "

            };

         emp_id =  db.insert(table, Columns, Value);


        }
        public void countEmpforCode() {
            
            DateTime dt = Convert.ToDateTime(emp_start_date);
            year = dt.Year.ToString();
            month = dt.Month.ToString();

            using (SqlConnection conn = new SqlConnection(constring()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(emp_start_date) AS numCount FROM tab_employee WHERE YEAR(emp_start_date) = '" + year + "' AND MONTH(emp_start_date) = '" + month + "'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    count = Convert.ToInt32(rdr["numCount"])+1;
                }
                conn.Close();
            }

            shotYear = Convert.ToDateTime(emp_start_date).ToString("yy", th);
            resultCode = shotYear+month.ToString().PadLeft(2,'0')+count.ToString().PadLeft(2, '0');
        }
        public void tab_employee() {

           
            using (SqlConnection conn = new SqlConnection(constring())) {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_employee INNER JOIN tab_emp_type ON tab_emp_type.type_id = emp_type INNER JOIN tab_info_status ON tab_info_status.status_id = emp_status WHERE tab_employee.emp_id = '" + emp_id+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    emp_code = rdr["emp_code"].ToString();
                    emp_prefix_th = rdr["emp_prefix"].ToString();
                    emp_prefix_en = rdr["emp_prefix_en"].ToString();
                    emp_name_th = rdr["emp_name_th"].ToString();
                    emp_lastname_th = rdr["emp_lastname_th"].ToString();
                    emp_name_en = rdr["emp_name_en"].ToString();
                    emp_lastname_en = rdr["emp_lastname_en"].ToString();
                    emp_status = rdr["status_name"].ToString();
                    emp_type = rdr["type_name"].ToString();
                    
                    emp_start_date = Convert.ToDateTime(rdr["emp_start_date"]).ToString("dd MMMM yyyy", th);
                    emp_end_date = Convert.ToDateTime(rdr["emp_end_date"]).ToString("dd-MM-yyyy", th);
                    emp_admin_id = rdr["emp_admin_id"].ToString();
                    emp_submit_date = rdr["emp_submit_date"].ToString();
                }
                conn.Close();
                
            }

        }
    }
}
