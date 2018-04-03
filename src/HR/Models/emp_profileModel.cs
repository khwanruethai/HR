using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class emp_profileModel
    {
        public string profile_id { get; set; }
        public string profile_gender { get; set; }
        public string profile_birthday { get; set; }
        public string profile_age { get; set; }
        public string profile_nationality { get; set; }
        public string profile_race { get; set; }
        public string profile_religion { get; set; }
        public string profile_blood { get; set; }
        public string profile_identification { get; set; }
        public string profile_date_issue { get; set; }
        public string profile_expired_date { get; set; }
        public string profile_weight { get; set; }
        public string profile_height { get; set; }
        public string profile_marital_status { get; set; }
        public string profile_child_num { get; set; }
        public string profile_emp_id { get; set; }
        public string profile_admin_id { get; set; }
        public string profile_submit_date { get; set; }
        public string profile_status { get; set; }
        public string profile_check { get; set; }

        databaseClass db = new databaseClass();
        dbFile connect = new dbFile();

        public string connectionString() {

            return connect.sqlConnection;
        }
        public string check_profile(string emp) {

            using (SqlConnection conn = new SqlConnection(connectionString())) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(profile_emp_id) AS checkProfile FROM tab_emp_profile WHERE profile_emp_id = '"+emp+"'",conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    profile_check = rdr["checkProfile"].ToString();
                }
                conn.Close();
            }
            return profile_check;
        }
        public string select_profile(string emp) {

            using (SqlConnection conn = new SqlConnection(connectionString())) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_profile WHERE profile_emp_id = '"+emp+"'",conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    profile_id = rdr["profile_id"].ToString();
                    profile_gender = rdr["profile_gender"].ToString();
                    profile_birthday = rdr["profile_birthday"].ToString();
                    profile_age = rdr["profile_age"].ToString();
                    profile_nationality = rdr["profile_nationality"].ToString();
                    profile_race = rdr["profile_race"].ToString();
                    profile_religion = rdr["profile_religion"].ToString();
                    profile_blood = rdr["profile_blood"].ToString();
                    profile_identification = rdr["profile_identification"].ToString();
                    profile_date_issue = rdr["profile_date_issue"].ToString();
                    profile_expired_date = rdr["profile_expired_date"].ToString();
                    profile_weight = rdr["profile_weigth"].ToString();
                    profile_height = rdr["profile_height"].ToString();
                    profile_marital_status = rdr["profile_marital_status"].ToString();
                    profile_child_num = rdr["profile_child_num"].ToString();
                    profile_emp_id = rdr["profile_emp_id"].ToString();
                    profile_admin_id = rdr["profile_admin_id"].ToString();
                    profile_submit_date = rdr["profile_submit_date"].ToString();
                    profile_status = rdr["profile_status"].ToString();
                    
                }

                conn.Close();
            }

            return profile_gender+"^"+profile_age+"^"+profile_nationality+"^"+profile_race+"^"+profile_religion+"^"+profile_blood+"^"+profile_birthday+"^"+profile_identification+"^"+profile_date_issue+"^"+profile_expired_date+"^"+profile_weight+"^"+profile_height+"^"+profile_marital_status+"^"+profile_child_num;
        }
        public void insert_profile() {

            string table = "tab_emp_profile";
            string[] Columns = { "profile_gender","profile_birthday","profile_age","profile_nationality","profile_race","profile_religion","profile_blood","profile_identification","profile_date_issue", "profile_expired_date", "profile_weigth", "profile_height", "profile_marital_status", "profile_child_num", "profile_emp_id", "profile_admin_id", "profile_submit_date", "profile_status"};
            string[] Value = { profile_gender, profile_birthday, profile_age, profile_nationality, profile_race, profile_religion, profile_blood, profile_identification, profile_date_issue, profile_expired_date, profile_weight, profile_height,profile_marital_status, profile_child_num,profile_emp_id, "1", DateTime.Now.ToString("yyyy-MM-dd"), "OPEN"};
            db.insert(table, Columns, Value);
        }
        

    }
}
