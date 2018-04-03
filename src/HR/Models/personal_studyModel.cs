using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class personal_studyModel
    {
        public string study_id { get; set; }
        public string study_year { get; set; }
        public string study_academy { get; set; }
        public string study_gpa { get; set; }
        public string study_degree { get; set; }
        public string study_branch { get; set; }
        public string study_ref_personal_id { get; set; }
        public string study_submit_date { get; set; }
        public string study_ref_admin_id { get; set; }

        dbFile db = new dbFile();

        public void insertStudy() {


            databaseClass dbclass = new databaseClass();

            string table = "tab_personal_study";
            string[] Columns = { "study_year", "study_academy", "study_gpa", "study_degree", "study_branch", "study_ref_personal_id", "study_submit_date", "study_ref_admin_id" };
            string[] Value = { study_year, study_academy, study_gpa, study_degree, study_branch, study_ref_personal_id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1"};


            dbclass.insert(table, Columns, Value);

        }

        public List<personal_studyModel> tb_study(string id)
        {

            List<personal_studyModel> obj = new List<personal_studyModel>();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_personal_study INNER JOIN tab_emp ON tab_emp.ep_ref_personal_id = tab_personal_study.study_ref_personal_id WHERE tab_emp.ep_id = '"+id+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    personal_studyModel st = new personal_studyModel();

                    st.study_year = rdr["study_year"].ToString();
                    st.study_academy = rdr["study_academy"].ToString();
                    st.study_gpa = rdr["study_gpa"].ToString();
                    st.study_degree = rdr["study_degree"].ToString();
                    st.study_branch = rdr["study_branch"].ToString();
                    st.study_id = rdr["study_id"].ToString();

                    obj.Add(st);

                }

                conn.Close();
            }


           return obj;

        }
        public List<personal_studyModel> tb_study_person(string person)
        {

            List<personal_studyModel> obj = new List<personal_studyModel>();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_personal_study WHERE study_ref_personal_id = '" + person + "'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    personal_studyModel st = new personal_studyModel();

                    st.study_year = rdr["study_year"].ToString();
                    st.study_academy = rdr["study_academy"].ToString();
                    st.study_gpa = rdr["study_gpa"].ToString();
                    st.study_degree = rdr["study_degree"].ToString();
                    st.study_branch = rdr["study_branch"].ToString();
                    st.study_id = rdr["study_id"].ToString();
                    st.study_ref_personal_id = rdr["study_ref_personal_id"].ToString();
                    st.study_ref_admin_id = rdr["study_ref_admin_id"].ToString();
                    st.study_submit_date = rdr["study_submit_date"].ToString();

                    obj.Add(st);

                }

                conn.Close();
            }


            return obj;
        }
        public void select_study_person(string study) {

            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_personal_study WHERE study_id = '"+study+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                   study_year = rdr["study_year"].ToString();
                   study_academy = rdr["study_academy"].ToString();
                   study_gpa = rdr["study_gpa"].ToString();
                   study_degree = rdr["study_degree"].ToString();
                   study_branch = rdr["study_branch"].ToString();
                   study_id = rdr["study_id"].ToString();
                   study_ref_personal_id = rdr["study_ref_personal_id"].ToString();
                   study_ref_admin_id = rdr["study_ref_admin_id"].ToString();
                   study_submit_date = rdr["study_submit_date"].ToString();

                }


                conn.Close();
            }
            
        }
        public void insertStudyLOG() {

            databaseClassLOG dbl = new databaseClassLOG();

            string table = "tab_personal_study";
            string[] Columns = { "study_id", "study_year", "study_academy", "study_gpa", "study_degree", "study_branch", "study_ref_personal_id", "study_submit_date", "study_ref_admin_id" };
            string[] Value = { study_id, study_year, study_academy, study_gpa, study_degree, study_branch, study_ref_personal_id, Convert.ToDateTime(study_submit_date).ToString("yyyy-MM-dd HH:mm:ss"), study_ref_admin_id };
            
            dbl.insert(table, Columns, Value);

        }
        public void updateStudy() {

            databaseClass dbc = new databaseClass();
            string table = "tab_personal_study";
            string[] Columns = { "study_year", "study_academy", "study_gpa", "study_degree", "study_branch", "study_ref_personal_id", "study_submit_date", "study_ref_admin_id" };
            string[] Value = {  study_year, study_academy, study_gpa, study_degree, study_branch, study_ref_personal_id, Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"), "1" };
            string where = "study_id = '"+study_id+"'";

            dbc.update(table, Columns, Value, where);

        }
        
    }
}
