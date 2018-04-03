using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class personal_kidModel
    {
        public string kid_id { get; set; }
        public string kid_name { get; set; }
        public string kid_lastname { get; set; }
        public string kid_age { get; set; }
        public string kid_study_status { get; set; }
        public string kid_study_level { get; set; }
        public string kid_study_school { get; set; }
        public string kid_ref_personal_id { get; set; }
        public string kid_submit_date { get; set; }
        public string kid_ref_admin_id { get; set; }
        public string kid_check_yes { get; set; }
        public string kid_check_not { get; set; }

        dbFile db = new dbFile();

        public void insertKid() {

            databaseClass dbclass = new databaseClass();

            string table = "tab_personal_kid";
            string[] Columns = { "kid_name", "kid_lastname", "kid_age", "kid_study_status", "kid_study_level", "kid_study_school", "kid_ref_personal_id", "kid_submit_date", "kid_ref_admin_id" };
            string[] Value = { kid_name, kid_lastname, kid_age, kid_study_status, kid_study_level, kid_study_school, kid_ref_personal_id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1"};

            dbclass.insert(table, Columns, Value);
            

        }
        public List<personal_kidModel> tb_kid(string id) {

            List<personal_kidModel> obj = new List<personal_kidModel>();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_personal_kid INNER JOIN tab_emp ON tab_emp.ep_ref_personal_id = tab_personal_kid.kid_ref_personal_id WHERE tab_emp.ep_id = '" + id + "'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read()) {

                    personal_kidModel kid = new personal_kidModel(); ;

                    kid.kid_name = rdr["kid_name"].ToString();
                    kid.kid_lastname = rdr["kid_lastname"].ToString();
                    kid.kid_age = rdr["kid_age"].ToString();
                    if (rdr["kid_study_status"].ToString() == "yes")
                    {

                        kid.kid_study_status = "กำลังศึกษา";
                        kid.kid_study_level = rdr["kid_study_level"].ToString();
                        kid.kid_study_school = rdr["kid_study_school"].ToString();

                    }
                    else {

                        kid.kid_study_status = "-";
                        kid.kid_study_level = "-";
                        kid.kid_study_school = "-";


                    }


                    obj.Add(kid);
                }

                conn.Close();

            }
            
                return obj;

        }
        public List<personal_kidModel> tb_kid_person(string person)
        {

            List<personal_kidModel> obj = new List<personal_kidModel>();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection))
            {

                conn.Open();

                int i = 0;
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_personal_kid WHERE kid_ref_personal_id = '"+person+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    personal_kidModel kid = new personal_kidModel(); ;
                    kid.kid_id = rdr["kid_id"].ToString();
                    kid.kid_name = rdr["kid_name"].ToString();
                    kid.kid_lastname = rdr["kid_lastname"].ToString();
                    kid.kid_age = rdr["kid_age"].ToString();
                    kid.kid_study_status = rdr["kid_study_status"].ToString();
                    kid.kid_study_level = rdr["kid_study_level"].ToString();
                    kid.kid_study_school = rdr["kid_study_school"].ToString();
                    if (rdr["kid_study_status"].ToString() == "yes")
                    {
                        kid.kid_check_yes = "checked";
                        kid.kid_check_not = "";
                    }
                    else if(rdr["kid_study_status"].ToString() == "not") {

                        kid.kid_check_yes = "";
                        kid.kid_check_not = "checked";
                    }

                    obj.Add(kid);
                    i++;
                }

                conn.Close();

            }

            return obj;

        }
        public void select_from_kidId(string kid) {

            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_personal_kid WHERE kid_id = '"+kid+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                   kid_id = rdr["kid_id"].ToString();
                   kid_name = rdr["kid_name"].ToString();
                   kid_lastname = rdr["kid_lastname"].ToString();
                   kid_age = rdr["kid_age"].ToString();
                   kid_study_status = rdr["kid_study_status"].ToString();
                   kid_study_level = rdr["kid_study_level"].ToString();
                   kid_study_school = rdr["kid_study_school"].ToString();
                    kid_submit_date = rdr["kid_submit_date"].ToString();
                    kid_ref_personal_id = rdr["kid_ref_personal_id"].ToString();
                    kid_ref_admin_id = rdr["kid_ref_admin_id"].ToString();

                }

                conn.Close();
            }

        }
        public void insertKidLOG() {

            databaseClassLOG dbl = new databaseClassLOG();

            string table = "tab_personal_kid";
            string[] Columns = { "kid_id", "kid_name", "kid_lastname", "kid_age", "kid_study_status", "kid_study_level", "kid_study_school", "kid_ref_personal_id", "kid_submit_date", "kid_ref_admin_id" };
            string[] Value = { kid_id, kid_name, kid_lastname, kid_age, kid_study_status, kid_study_level, kid_study_school, kid_ref_personal_id, Convert.ToDateTime(kid_submit_date).ToString("yyyy-MM-dd HH:mm:ss"), kid_ref_admin_id };
            
            dbl.insert(table, Columns, Value);

        }
        public void updateKid() {


            databaseClass dbc = new databaseClass();
            string table = "tab_personal_kid";
            string[] Columns = {  "kid_name", "kid_lastname", "kid_age", "kid_study_status", "kid_study_level", "kid_study_school", "kid_ref_personal_id", "kid_submit_date", "kid_ref_admin_id" };
            string[] Value = {  kid_name, kid_lastname, kid_age, kid_study_status, kid_study_level, kid_study_school, kid_ref_personal_id, Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"), "1" };
            string where = "kid_id = '"+kid_id+"'";
            
            dbc.update(table, Columns, Value, where);
            
        }

    }
}
