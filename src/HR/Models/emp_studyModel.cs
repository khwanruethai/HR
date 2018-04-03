using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;


namespace HR.Models
{
    public class emp_studyModel
    {
        public string study_id { get; set; }
        public string study_year { get; set; }
        public string study_education { get; set; }
        public string study_academy { get; set; }
        public string study_gpa { get; set; }
        public string study_emp_id { get; set; }
        public string study_admin_id { get; set; }
        public string study_submit_date { get; set; }
        public string checkStudy { get; set; }

        CultureInfo th = new CultureInfo("TH");
        databaseClass db = new databaseClass();
        dbFile connect = new dbFile();
        public void check_studyBYemp(string emp) {

            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(study_emp_id) AS checkStudy FROM tab_emp_study WHERE study_emp_id = '"+emp+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    checkStudy = rdr["checkStudy"].ToString();
                }
                conn.Close();
            }
        }
        public void selectStudyBYEmp(string emp) {

            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_study WHERE study_emp_id = '" + emp + "'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    study_id = rdr["study_id"].ToString();
                    study_year = rdr["study_year"].ToString();
                    study_education = rdr["study_education"].ToString();
                    study_academy = rdr["study_academy"].ToString();
                    study_gpa = rdr["study_gpa"].ToString();
                    study_emp_id = rdr["study_emp_id"].ToString();
                    study_admin_id = rdr["study_admin_id"].ToString();
                    study_submit_date = rdr["study_submit_date"].ToString();
                    
                }

                conn.Close();
            }
        }
        public void insertStudy() {

            string table = "tab_emp_study";
            string[] Columns = { "study_year", "study_education", "study_academy", "study_gpa", "study_emp_id", "study_admin_id", "study_submit_date" };
            string[] Value = { study_year, study_education, study_academy, study_gpa, study_emp_id, "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", th) };

            db.insert(table, Columns, Value);
            
        }
        
    }
}
