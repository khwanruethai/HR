using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class personal_trainModel
    {
        public string train_id { get; set; }
        public string train_title { get; set; }
        public string train_location { get; set; }
        public string train_start { get; set; }
        public string train_end { get; set; }
        public string train_ref_personal_id { get; set; }
        public string train_submit_date { get; set; }
        public string train_ref_admin_id { get; set; }

        dbFile db = new dbFile();
        CultureInfo th = new CultureInfo("TH");
        CultureInfo en = new CultureInfo("EN");

        public void insertTrain() {

            databaseClass dbclass = new databaseClass();

            string table = "tab_personal_train";
            string[] Columns = { "train_title", "train_location", "train_start", "train_end", "train_ref_personal_id", "train_submit_date", "train_ref_admin_id" };
            string[] Value = {train_title, train_location, train_start, train_end, train_ref_personal_id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") , "1"};

            dbclass.insert(table, Columns, Value);


        }
        public List<personal_trainModel> tb_train(string id) {

            List<personal_trainModel> obj = new List<personal_trainModel>();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_personal_train INNER JOIN tab_emp ON tab_emp.ep_ref_personal_id = tab_personal_train.train_ref_personal_id WHERE tab_emp.ep_id = '" + id + "'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    personal_trainModel pt = new personal_trainModel();

                    pt.train_title = rdr["train_title"].ToString();
                    pt.train_location = rdr["train_location"].ToString();
                    pt.train_start = rdr["train_start"].ToString();
                    pt.train_end = rdr["train_end"].ToString();

                    obj.Add(pt);
                    
                }


                conn.Close();
            }

            return obj;


        }
        public List<personal_trainModel> tb_train_person(string person)
        {

            List<personal_trainModel> obj = new List<personal_trainModel>();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_personal_train WHERE train_ref_personal_id = '" + person + "'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    personal_trainModel pt = new personal_trainModel();

                    pt.train_title = rdr["train_title"].ToString();
                    pt.train_location = rdr["train_location"].ToString();
                    pt.train_start = Convert.ToDateTime(rdr["train_start"]).ToString("dd/MM/yyyy");
                    pt.train_end = Convert.ToDateTime(rdr["train_end"]).ToString("dd/MM/yyyy");
                    pt.train_id = rdr["train_id"].ToString();
                    pt.train_ref_personal_id = rdr["train_ref_personal_id"].ToString();
                    pt.train_submit_date = rdr["train_submit_date"].ToString();
                    pt.train_ref_admin_id = rdr["train_ref_admin_id"].ToString();

                    obj.Add(pt);

                }


                conn.Close();
            }

            return obj;


        }

        public void select_form_train(string train) {

            using (SqlConnection conn = new SqlConnection(db.sqlConnection))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_personal_train WHERE train_id = '" + train + "'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    train_title = rdr["train_title"].ToString();
                    train_location = rdr["train_location"].ToString();
                    train_start = Convert.ToDateTime(rdr["train_start"]).ToString("dd/MM/yyyy");
                    train_end = Convert.ToDateTime(rdr["train_end"]).ToString("dd/MM/yyyy");
                    train_id = rdr["train_id"].ToString();
                    train_ref_personal_id = rdr["train_ref_personal_id"].ToString();
                    train_submit_date = rdr["train_submit_date"].ToString();
                    train_ref_admin_id = rdr["train_ref_admin_id"].ToString();
  
                }


                conn.Close();
            }

        }
        public void insertTrainLOG() {

            databaseClassLOG dbl = new databaseClassLOG();

            string table = "tab_personal_train";
            string[] Columns = {"train_id", "train_title", "train_location", "train_start", "train_end", "train_ref_personal_id", "train_submit_date", "train_ref_admin_id" };
            string[] Value = {train_id ,train_title, train_location, train_start, train_end, train_ref_personal_id, Convert.ToDateTime(train_submit_date).ToString("yyyy-MM-dd HH:mm:ss"), train_ref_admin_id};

            dbl.insert(table, Columns, Value);

        }
        public void updateTrain() {

            databaseClass dbc = new databaseClass();

            string table = "tab_personal_train";
            string[] Columns = { "train_title", "train_location", "train_start", "train_end", "train_ref_personal_id", "train_submit_date", "train_ref_admin_id" };
            string[] Value = { train_title, train_location, train_start, train_end, train_ref_personal_id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1" };
            string where = "train_id = '" + train_id + "'";

            dbc.update(table, Columns, Value, where);
        }
    }
}
