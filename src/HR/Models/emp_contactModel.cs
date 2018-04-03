using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;


namespace HR.Models
{
    public class emp_contactModel
    {
        public string contact_id { get; set; }
        public string contact_email { get; set; }
        public string contact_table { get; set; }
        public string contact_phone { get; set; }
        public string contact_mobile1 { get; set; }
        public string contact_mobile2 { get; set; }
        public string contact_emp_id { get; set; }
        public string contact_admin_id { get; set; }
        public string contact_submit_date { get; set; }
        public string contact_status { get; set; }
        public string contect_check { get; set; }

        public string personal_id { get; set; }
       

        databaseClass db = new databaseClass();

        public string connected() {

            dbFile dbStr = new dbFile();

            return dbStr.sqlConnection;

        }
        public string check_contact() {

            using (SqlConnection conn = new SqlConnection(connected())) {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(contact_id) AS numContact FROM tab_emp_contact WHERE contact_emp_id = '"+contact_emp_id+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    contect_check = rdr["numContact"].ToString();

                }
                conn.Close();
            }


            return contect_check;
        }
        public string select_contact() {

            using (SqlConnection conn = new SqlConnection(connected())) {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_contact WHERE contact_emp_id = '"+contact_emp_id+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()){

                    contact_id = rdr["contact_id"].ToString();
                    contact_email = rdr["contact_email"].ToString();
                    contact_table = rdr["contact_table"].ToString();
                    contact_phone = rdr["contact_phone"].ToString();
                    contact_mobile1 = rdr["contact_mobile1"].ToString();
                    contact_mobile2 = rdr["contact_mobile2"].ToString();
                    contact_emp_id = rdr["contact_emp_id"].ToString();
                    contact_admin_id = rdr["contact_admin_id"].ToString();
                    contact_submit_date = rdr["contact_submit_date"].ToString();
                    contact_status = rdr["contact_status"].ToString();

                }
                conn.Close();
            }

            return contact_email + "^" + contact_table + "^" + contact_phone + "^" + contact_mobile1 + "^" + contact_mobile2;
        }
        public string insert_contact() {

            string table = "tab_emp_contact";
            string[] Columns = { "contact_email", "contact_table", "contact_phone", "contact_mobile1", "contact_mobile2", "contact_admin_id", "contact_submit_date", "contact_status", "contact_emp_id"};
            string[] Value = {contact_email, contact_table, contact_phone, contact_mobile1, contact_mobile2, "1", DateTime.Now.ToString("yyyy-MM-dd"), "OPEN", contact_emp_id };
            
            db.insert(table, Columns, Value);

            return "";
        }

        public void selectContact_emp(string emp) {

            dbFile constr = new dbFile();

            using (SqlConnection conn = new SqlConnection(constr.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_contact"+
                                                  " INNER JOIN tab_emp ON tab_emp.ep_ref_personal_id = contact_emp_id"+
                                                  " WHERE ep_id = '"+emp+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    contact_id = rdr["contact_id"].ToString();
                    contact_email = rdr["contact_email"].ToString();
                    contact_table = rdr["contact_table"].ToString();
                    contact_phone = rdr["contact_phone"].ToString();
                    contact_mobile1 = rdr["contact_mobile1"].ToString();
                    contact_mobile2 = rdr["contact_mobile2"].ToString();
                    contact_emp_id = rdr["contact_emp_id"].ToString();
                    contact_admin_id = rdr["contact_admin_id"].ToString();
                    contact_submit_date = rdr["contact_submit_date"].ToString();
                    contact_status = rdr["contact_status"].ToString();
                    personal_id = rdr["ep_ref_personal_id"].ToString();
                }
                conn.Close();
            }

        }
        public string insert_contact_log() {

            databaseClassLOG dbClass = new databaseClassLOG();
            dbFile db = new dbFile();
            string txt = "";
            using (SqlConnection conn = new SqlConnection(db.sqlConnection_log)) {

                conn.Open();
                
                SqlCommand cmd = new SqlCommand("INSERT INTO tab_emp_contact(contact_id, contact_email, contact_table, contact_phone, contact_mobile1, contact_mobile2, contact_emp_id, contact_admin_id, contact_submit_date, contact_status) VALUES(@contact_id, @contact_email, @contact_table, @contact_phone, @contact_mobile1, @contact_mobile2, @contact_emp_id, @contact_admin_id, @contact_submit_date, @contact_status)", conn);
                cmd.Parameters.AddWithValue("@contact_id", contact_id);
                cmd.Parameters.AddWithValue("@contact_email", contact_email);
                cmd.Parameters.AddWithValue("@contact_table", contact_table);
                cmd.Parameters.AddWithValue("@contact_phone", contact_phone);
                cmd.Parameters.AddWithValue("@contact_mobile1", contact_mobile1);
                cmd.Parameters.AddWithValue("@contact_mobile2", contact_mobile2);
                cmd.Parameters.AddWithValue("@contact_emp_id", contact_emp_id);
                cmd.Parameters.AddWithValue("@contact_admin_id", contact_admin_id);
                cmd.Parameters.AddWithValue("@contact_submit_date", Convert.ToDateTime(contact_submit_date).ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@contact_status", contact_status);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                conn.Close();

            }

            return txt;
        }
        public void update_contact()
        {
            CultureInfo en = new CultureInfo("EN");
            dbFile dbClass = new dbFile();
            //string table = "tab_emp_contact";
            //string[] Columns = { "contact_email", "contact_table", "contact_phone", "contact_mobile1", "contact_mobile2", "contact_admin_id", "contact_submit_date"};
            //string[] Value = { contact_email, contact_table, contact_phone, contact_mobile1, contact_mobile2, "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en)};
            //string where = "contact_id = '" + contact_id+"'";

            //db.update(table, Columns, Value, where);
            using (SqlConnection conn = new SqlConnection(dbClass.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE tab_emp_contact SET contact_email = @contact_email, contact_table = @contact_table, contact_phone = @contact_phone, contact_mobile1 = @contact_mobile1, contact_mobile2 = @contact_mobile2, contact_emp_id = @contact_emp_id, contact_admin_id = @contact_admin_id, contact_submit_date = @contact_submit_date, contact_status = @contact_status WHERE contact_id = '"+contact_id+"'", conn);
                cmd.Parameters.AddWithValue("@contact_email", contact_email);
                cmd.Parameters.AddWithValue("@contact_table", contact_table);
                cmd.Parameters.AddWithValue("@contact_phone", contact_phone);
                cmd.Parameters.AddWithValue("@contact_mobile1", contact_mobile1);
                cmd.Parameters.AddWithValue("@contact_mobile2", contact_mobile2);
                cmd.Parameters.AddWithValue("@contact_emp_id", contact_emp_id);
                cmd.Parameters.AddWithValue("@contact_admin_id", contact_admin_id);
                cmd.Parameters.AddWithValue("@contact_submit_date", Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss", en));
                cmd.Parameters.AddWithValue("@contact_status", contact_status);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                conn.Close();
            }


        }
        public void selectContact_Person(string person)
        {

            dbFile constr = new dbFile();

            using (SqlConnection conn = new SqlConnection(constr.sqlConnection))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_contact WHERE contact_emp_id = '"+person+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    contact_id = rdr["contact_id"].ToString();
                    contact_email = rdr["contact_email"].ToString();
                    contact_table = rdr["contact_table"].ToString();
                    contact_phone = rdr["contact_phone"].ToString();
                    contact_mobile1 = rdr["contact_mobile1"].ToString();
                    contact_mobile2 = rdr["contact_mobile2"].ToString();
                    contact_emp_id = rdr["contact_emp_id"].ToString();
                    contact_admin_id = rdr["contact_admin_id"].ToString();
                    contact_submit_date = rdr["contact_submit_date"].ToString();
                    contact_status = rdr["contact_status"].ToString();
                    personal_id = rdr["contact_emp_id"].ToString();
                }
                conn.Close();
            }

        }
    }
}
