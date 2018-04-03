using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class personalChangeModel
    {
        public string ch_name_id { get; set; }
        public string ch_ref_prefix_id { get; set; }
        public string ch_ref_person_id { get; set; }
        public string ch_name_th { get; set; }
        public string ch_lastname_th { get; set; }
        public string ch_name_en { get; set; }
        public string ch_lastname_en { get; set; }
        public string ch_ref_prefix_id_old { get; set; }
        public string ch_name_th_old { get; set; }
        public string ch_lastname_th_old { get; set; }
        public string ch_name_en_old { get; set; }
        public string ch_lastname_en_old { get; set; }
        public string ch_start_date { get; set; }
        public string ch_end_date { get; set; }
        public string ch_create_date { get; set; }
        public string ch_ref_admin_id { get; set; }
        public string event_status { get; set; }
        public string turn_id { get; set; }
        public string file { get; set; }


        //
        public string max_id { get; set; }

        dbFile db = new dbFile();
        CultureInfo en = new CultureInfo("EN");

        public void select_max_id() {

            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT MAX(ch_name_id) AS idMax  FROM tab_personal_change WHERE ch_ref_person_id = '"+ch_ref_person_id+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read()) {

                    if (string.IsNullOrEmpty(rdr["idMax"].ToString()) == true)
                    {

                        max_id = "N";
                    }
                    else {


                        max_id = rdr["idMax"].ToString();

                    }


                }


                conn.Close();

            }


        }

        public void insert_person_change() {

            databaseClass dbc = new databaseClass();

          

            string table = "tab_personal_change";
            string[] Columns = {
                "ch_ref_prefix_id",
                "ch_ref_person_id",
                "ch_name_th",
                "ch_lastname_th",
                "ch_name_en",
                "ch_lastname_en",
                "ch_ref_prefix_id_old",
                "ch_name_th_old",
                "ch_lastname_th_old",
                "ch_name_en_old",
                "ch_lastname_en_old",
                "ch_start_date",
                "ch_end_date" ,
                "ch_create_date",
                "ch_ref_admin_id",
                "event_status" };
            string[] Value = {
                ch_ref_prefix_id,
                ch_ref_person_id,
                ch_name_th,
                ch_lastname_th,
                ch_name_en,
                ch_lastname_en ,
                ch_ref_prefix_id_old,
                ch_name_th_old,
                ch_lastname_th_old,
                ch_name_en_old,
                ch_lastname_en_old,
               Convert.ToDateTime(ch_start_date).ToString("yyyy-MM-dd HH:mm:ss",en),
                Convert.ToDateTime(ch_end_date).ToString("yyyy-MM-dd HH:mm:ss",en),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss",en),
                "1",
                "S"
              };

       turn_id =    dbc.insert(table, Columns, Value);

        }
        public void select_data_id() {

            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_personal_change WHERE ch_name_id = '" + ch_name_id+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    ch_name_id = rdr["ch_name_id"].ToString();
                    ch_ref_prefix_id = rdr["ch_ref_prefix_id"].ToString();
                    ch_ref_person_id = rdr["ch_ref_person_id"].ToString();
                    ch_name_th = rdr["ch_name_th"].ToString();
                    ch_lastname_th = rdr["ch_lastname_th"].ToString();
                    ch_name_en = rdr["ch_name_en"].ToString();
                    ch_lastname_en = rdr["ch_lastname_en"].ToString();
                    ch_ref_prefix_id_old = rdr["ch_ref_prefix_id_old"].ToString();
                    ch_name_th_old = rdr["ch_name_th_old"].ToString();
                    ch_lastname_th_old = rdr["ch_lastname_th_old"].ToString();
                    ch_name_en_old = rdr["ch_name_en_old"].ToString();
                    ch_lastname_en_old = rdr["ch_lastname_en_old"].ToString();
                    ch_start_date = rdr["ch_start_date"].ToString();
                    ch_end_date = rdr["ch_end_date"].ToString();
                    ch_create_date = rdr["ch_create_date"].ToString();
                    ch_ref_admin_id = rdr["ch_ref_admin_id"].ToString();
                    event_status = rdr["event_status"].ToString();

                }
                
                conn.Close();
            }
            

        }
        
        public void update_person_change() {
            
            databaseClass dbc = new databaseClass();

            string table = "tab_personal_change";
            string[] Columns = { "ch_ref_prefix_id", "ch_ref_person_id", "ch_name_th", "ch_lastname_th", "ch_name_en", "ch_lastname_en",
                                 "ch_ref_prefix_id_old","ch_name_th_old","ch_lastname_th_old","ch_name_en_old","ch_lastname_en_old","ch_start_date",
                                 "ch_end_date" , "ch_create_date","ch_ref_admin_id","event_status"};
            string[] Value = {ch_ref_prefix_id, ch_ref_person_id, ch_name_th, ch_lastname_th, ch_name_en, ch_lastname_en ,
                              ch_ref_prefix_id_old, ch_name_th_old, ch_lastname_th_old, ch_name_en_old, ch_lastname_en_old, Convert.ToDateTime(ch_start_date).ToString("yyyy-MM-dd HH:mm:ss", en),
                              Convert.ToDateTime(ch_end_date).ToString("yyyy-MM-dd HH:mm:ss", en), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1", event_status
                               };
            string where = "ch_name_id = '"+ch_name_id+"'";
            dbc.update(table, Columns, Value, where);

        }
        public void insert_person_change_LOG()
        {

            databaseClassLOG dbl = new databaseClassLOG();

            string table = "tab_personal_change";
            string[] Columns = { "ch_name_id","ch_ref_prefix_id", "ch_ref_person_id", "ch_name_th", "ch_lastname_th", "ch_name_en", "ch_lastname_en",
                                 "ch_ref_prefix_id_old","ch_name_th_old","ch_lastname_th_old","ch_name_en_old","ch_lastname_en_old","ch_start_date",
                                 "ch_end_date" , "ch_create_date","ch_ref_admin_id","event_status"};
            string[] Value = {ch_name_id,ch_ref_prefix_id, ch_ref_person_id, ch_name_th, ch_lastname_th, ch_name_en, ch_lastname_en ,
                              ch_ref_prefix_id_old, ch_name_th_old, ch_lastname_th_old, ch_name_en_old, ch_lastname_en_old, Convert.ToDateTime(ch_start_date).ToString("yyyy-MM-dd HH:mm:ss", en),
                              Convert.ToDateTime(ch_end_date).ToString("yyyy-MM-dd HH:mm:ss", en), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1", "S"
                               };

            dbl.insert(table, Columns, Value);

        }
        public List<personalChangeModel> list_chane_name() {

            List<personalChangeModel> obj = new List<personalChangeModel>();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_personal_change "+
" LEFT JOIN tab_person_file ON  tab_personal_change.ch_name_id = tab_person_file.ch_ref_change_name_id "+
" WHERE ch_ref_person_id = '"+ch_ref_person_id+"' AND tab_personal_change.event_status != 'D'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    personalChangeModel ps = new personalChangeModel();

                    ps.ch_name_id = rdr["ch_name_id"].ToString();
                    ps.ch_ref_prefix_id = rdr["ch_ref_prefix_id"].ToString();
                    ps.ch_ref_person_id = rdr["ch_ref_person_id"].ToString();
                    ps.ch_name_th = rdr["ch_name_th"].ToString();
                    ps.ch_lastname_th = rdr["ch_lastname_th"].ToString();
                    ps.ch_name_en = rdr["ch_name_en"].ToString();
                    ps.ch_lastname_en = rdr["ch_lastname_en"].ToString();
                    ps.ch_ref_prefix_id_old = rdr["ch_ref_prefix_id_old"].ToString();
                    ps.ch_name_th_old = rdr["ch_name_th_old"].ToString();
                    ps.ch_lastname_th_old = rdr["ch_lastname_th_old"].ToString();
                    ps.ch_name_en_old = rdr["ch_name_en_old"].ToString();
                    ps.ch_lastname_en_old = rdr["ch_lastname_en_old"].ToString();
                    ps.ch_start_date = rdr["ch_start_date"].ToString();
                    ps.ch_end_date = rdr["ch_end_date"].ToString();
                    ps.ch_create_date = rdr["ch_create_date"].ToString();
                    ps.ch_ref_admin_id = rdr["ch_ref_admin_id"].ToString();
                    ps.event_status = rdr["event_status"].ToString();
                    ps.file = rdr["ch_file_name"].ToString();
                    obj.Add(ps);

                }

                conn.Close();
            }


                return obj;
        }
    }
}
