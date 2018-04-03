using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class personalModel
    {
        public string prefix_th { get; set; }
        public string prefix_th_name { get; set; }
        public string prefix_en { get; set; }
        public string prefix_en_name { get; set; }
        public string name_th { get; set; }
        public string name_en { get; set; }
        public string lastname_th { get; set; }
        public string lastname_en { get; set; }
        public string gender { get; set; }
        public string blood { get; set; }
        public string national_id { get; set; }
        public string national_start { get; set; }
        public string national_end { get; set; }
        public string birthday { get; set; }
        public string age { get; set; }
        public string nationality { get; set; }
        public string race { get; set; }
        public string religion { get; set; }
        public string marital { get; set; }

        public string personal_id { get; set; }

        public string event_status { get; set; }

        dbFile connect = new dbFile();
        CultureInfo en = new CultureInfo("EN");
        CultureInfo th = new CultureInfo("TH");
        public void insertPersonal() {

            databaseClass db = new databaseClass();

            string table = "tab_personal";
            string[] Columns = { "ps_prefix_th","ps_prefix_en","ps_name_th","ps_lastname_th","ps_name_en","ps_lastname_en","ps_gender","ps_blood","ps_national_id","ps_national_date_start","ps_national_date_end", "ps_birthday", "ps_nationality", "ps_race", "ps_status_marital", "ps_admin_id", "ps_create_date", "ps_religion"};
            string[] Value = { prefix_th, prefix_en, name_th, lastname_th, name_en, lastname_en, gender, blood, national_id, national_start, national_end, Convert.ToDateTime(birthday).ToString("yyyy-MM-dd",en), nationality, race, marital, "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), religion};

          personal_id =  db.insert(table, Columns, Value);
            
        }
        public string checkName(string name="", string lastname = "") {

            string value = "";

            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(ps_name_th) AS checkName FROM tab_personal WHERE ps_name_th = '"+name+"' AND ps_lastname_th = '"+lastname+"'" ,conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    value = rdr["checkName"].ToString();
                }
                conn.Close();

            }

            return value;
        }
        public List<personalModel> infoPersonal() {

            List<personalModel> obj = new List<personalModel>();
            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM view_personal", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                   personalModel ps = new personalModel();
                   ps.personal_id = rdr["ps_id"].ToString();
                   ps.prefix_th = rdr["prefix_name_th"].ToString();
                   ps.name_th = rdr["ps_name_th"].ToString();
                   ps.lastname_th = rdr["ps_lastname_th"].ToString();
                   ps.gender = rdr["ps_gender"].ToString();
                   ps.age = ((Convert.ToInt32(DateTime.Now.Year)) - Convert.ToInt32(Convert.ToDateTime(rdr["ps_birthday"]).ToString("yyyy", en))).ToString(); //rdr["ps_age"].ToString();

                    obj.Add(ps);
                }

                conn.Close();

            }
            
            return obj;
        }
        public List<SelectListItem> national() {

            List<SelectListItem> item = new List<SelectListItem>();

            dbFile db = new dbFile();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ps_national_id, ps_id FROM tab_personal", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    item.Add(new SelectListItem { Text = rdr["ps_national_id"].ToString(), Value = rdr["ps_id"].ToString() });

                }

                conn.Close();


            }



            item.Insert(0, new SelectListItem { Text = "ค้นหาจากเลขประจำตัวประชาชน", Value = "0" });


            return item;
        }
        public void select_personal(string ps) {

            dbFile db = new dbFile();
            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_personal INNER JOIN tab_info_prefix ON tab_info_prefix.prefix_id = ps_prefix_th  WHERE ps_id = '"+ps+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    prefix_th = rdr["ps_prefix_th"].ToString();
                    prefix_en = rdr["ps_prefix_en"].ToString();
                    prefix_th_name = rdr["prefix_name_th"].ToString();
                    prefix_en_name = rdr["prefix_name_en"].ToString();
                    name_th = rdr["ps_name_th"].ToString();
                    name_en = rdr["ps_name_en"].ToString();
                    lastname_th = rdr["ps_lastname_th"].ToString();
                    lastname_en = rdr["ps_lastname_en"].ToString();
                    gender = rdr["ps_gender"].ToString();
                    blood = rdr["ps_blood"].ToString();
                    national_id = rdr["ps_national_id"].ToString();
                    national_start = Convert.ToDateTime(rdr["ps_national_date_start"]).ToString("dd/MM/yyyy", th);
                    national_end = Convert.ToDateTime(rdr["ps_national_date_end"]).ToString("dd/MM/yyyy",th);
                    birthday = Convert.ToDateTime(rdr["ps_birthday"]).ToString("dd/MM/yyyy", th);
                    age = (Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(Convert.ToDateTime(birthday).Year)).ToString();
                    nationality = rdr["ps_nationality"].ToString();
                    race = rdr["ps_race"].ToString();
                    religion = rdr["ps_religion"].ToString();
                    marital = rdr["ps_status_marital"].ToString();
                    event_status = rdr["ps_status_marital"].ToString();
                    personal_id = rdr["ps_id"].ToString();

                }

                conn.Close();
            }


        }
        public List<SelectListItem> personal()
        {

            List<SelectListItem> item = new List<SelectListItem>();

            dbFile db = new dbFile();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ps_name_th, ps_id, ps_lastname_th FROM tab_personal", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    item.Add(new SelectListItem { Text = rdr["ps_name_th"].ToString()+" "+ rdr["ps_lastname_th"], Value = rdr["ps_id"].ToString() });

                }

                conn.Close();

            }
            
            item.Insert(0, new SelectListItem { Text = "ค้นหาจากชื่อนามสกุล", Value = "0" });

            return item;
        }
        public List<SelectListItem> personal_for_edit()
        {

            List<SelectListItem> item = new List<SelectListItem>();

            dbFile db = new dbFile();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ps_name_th, ps_id, ps_lastname_th, ps_national_id FROM tab_personal", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    item.Add(new SelectListItem { Text = rdr["ps_national_id"] +" | "+rdr["ps_name_th"].ToString() + " " + rdr["ps_lastname_th"], Value = rdr["ps_id"].ToString() });

                }

                conn.Close();
            }

            item.Insert(0, new SelectListItem { Text = "เลือก", Value = "0" });

            return item;
        }

        public string getdata_personal(string id) {

            dbFile db = new dbFile();
            string txt = "";

            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM view_personal WHERE ps_id = '"+id+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {


                    if (rdr["ps_national_id"] != DBNull.Value)
                    {
                        txt = rdr["ps_national_id"] + "^" + rdr["prefix_name_th"] + "^" + rdr["prefix_name_en"] + "^" + rdr["ps_name_th"] + " " + rdr["ps_lastname_th"] + "^" + rdr["ps_name_en"] + " " + rdr["ps_lastname_en"];
                    }
                }
                
            }

            return txt;
        }
        public void select_person_byEmp(string emp) {

            dbFile db = new dbFile();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_personal INNER JOIN tab_emp ON tab_emp.ep_ref_personal_id = ps_id  WHERE ep_id = '"+emp+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    prefix_th = rdr["ps_prefix_th"].ToString();
                    prefix_en = rdr["ps_prefix_en"].ToString();
                    name_th = rdr["ps_name_th"].ToString();
                    name_en = rdr["ps_name_en"].ToString();
                    lastname_th = rdr["ps_lastname_th"].ToString();
                    lastname_en = rdr["ps_lastname_en"].ToString();
                    gender = rdr["ps_gender"].ToString();
                    blood = rdr["ps_blood"].ToString();
                    national_id = rdr["ps_national_id"].ToString();
                    national_start = Convert.ToDateTime(rdr["ps_national_date_start"]).ToString("dd/MM/yyyy",th);
                    national_end = Convert.ToDateTime(rdr["ps_national_date_end"]).ToString("dd/MM/yyyy", th);
                    birthday = Convert.ToDateTime(rdr["ps_birthday"]).ToString("dd/MM/yyyy",th);
                    nationality = rdr["ps_nationality"].ToString();
                    race = rdr["ps_race"].ToString();
                    religion = rdr["ps_religion"].ToString();
                    marital = rdr["ps_status_marital"].ToString();
                    personal_id = rdr["ps_id"].ToString();

                }
                
                conn.Close();
            }
        }
        public void updatePersonal() {
            
            databaseClass db = new databaseClass();

            string table = "tab_personal";
            string[] Columns = { "ps_gender", "ps_blood", "ps_national_id", "ps_national_date_start", "ps_national_date_end", "ps_birthday", "ps_nationality", "ps_race", "ps_religion", "ps_status_marital", "event_status"};
            string[] Value = {gender, blood, national_id, national_start, national_end, Convert.ToDateTime(birthday).ToString("yyyy-MM-dd", en), nationality, race, religion, marital, event_status  };
            string where = "ps_id = '"+personal_id+"'";

            db.update(table, Columns, Value, where);
            
        }
        public void insertPersonalLOG() {

            databaseClassLOG db = new databaseClassLOG();
            

            string table = "tab_personal";
            string[] Columns = { "ps_id", "ps_prefix_th", "ps_prefix_en", "ps_name_th", "ps_lastname_th", "ps_name_en", "ps_lastname_en", "ps_gender", "ps_blood", "ps_national_id", "ps_national_date_start", "ps_national_date_end", "ps_birthday", "ps_nationality", "ps_race", "ps_status_marital", "ps_admin_id", "ps_create_date", "ps_religion", "event_status" };
            string[] Value = { personal_id,  prefix_th, prefix_en, name_th, lastname_th, name_en, lastname_en, gender, blood, national_id, national_start, national_end, Convert.ToDateTime(birthday).ToString("yyyy-MM-dd", en), nationality, race, marital, "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), religion, event_status };

            db.insert(table, Columns, Value);
            
        }
        public void updatePerson() {

            //databaseClass db = new databaseClass();

            //string table = "tab_personal";
            //string[] Columns = { "ps_prefix_th", "ps_prefix_en", "ps_name_th", "ps_lastname_th", "ps_name_en", "ps_lastname_en", "ps_gender", "ps_blood", "ps_national_id", "ps_national_date_start", "ps_national_date_end", "ps_birthday", "ps_nationality", "ps_race", "ps_status_marital", "ps_admin_id", "ps_create_date", "ps_religion" };
            //string[] Value = { prefix_th, prefix_en, name_th, lastname_th, name_en, lastname_en, gender, blood, national_id, national_start, national_end, Convert.ToDateTime(birthday).ToString("yyyy-MM-dd", en), nationality, race, marital, "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), religion };
            //string where = "ps_id = '"+personal_id+"'";

            //db.update(table, Columns, Value, where);

            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {

                conn.Open();
                event_status = "U";

                SqlCommand cmd = new SqlCommand("UPDATE tab_personal SET ps_prefix_th = '"+prefix_th+"', ps_prefix_en = '"+prefix_en+"', ps_name_th = '"+name_th+"', ps_lastname_th = '"+lastname_th+"', ps_name_en = '"+name_en+"', ps_lastname_en = '"+lastname_en+"', ps_gender = '"+gender+"', ps_blood = '"+blood+"', ps_national_id = '"+national_id+"', ps_national_date_start = '"+national_start+"', ps_national_date_end = '"+national_end+"', ps_birthday = '"+Convert.ToDateTime(birthday).ToString("yyyy-MM-dd", en)+"', ps_nationality = '"+nationality+"', ps_race = '"+race+"', ps_status_marital = '"+marital+"', ps_admin_id = '1', ps_create_date = '"+DateTime.Now.ToString("yyyy-MM-dd")+"', ps_religion = '"+religion+"', event_status = '"+event_status+"' WHERE ps_id = '"+personal_id+"'", conn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                conn.Close();
            }

        }
        
    }
}
