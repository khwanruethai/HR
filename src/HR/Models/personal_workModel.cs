using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class personal_workModel
    {
        public string work_id { get; set; }
        public string work_company { get; set; }
        public string work_address { get; set; }
        public string work_start { get; set; }
        public string work_end { get; set; }
        public string work_position { get; set; }
        public string work_ref_personal_id { get; set; }
        public string work_submit_date { get; set; }
        public string work_ref_admin_id { get; set; }

        dbFile db = new dbFile();

        public void insertWork() {


            databaseClass dbclass = new databaseClass();

            string table = "tab_personal_work";
            string[] Columns = { "work_company", "work_address", "work_start", "work_end", "work_position", "work_ref_personal_id", "work_submit_date", "work_ref_admin_id" };
            string[] Value = {work_company, work_address, work_start, work_end, work_position, work_ref_personal_id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1" };

            dbclass.insert(table, Columns, Value);

        }
        public List<personal_workModel> tb_work(string id) {
            
            List<personal_workModel> obj = new List<personal_workModel>();
            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_personal_work INNER JOIN tab_emp ON tab_emp.ep_ref_personal_id = tab_personal_work.work_ref_personal_id WHERE tab_emp.ep_id = '" + id + "'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    personal_workModel pw = new personal_workModel();
                    pw.work_company = rdr["work_company"].ToString();
                    pw.work_position = rdr["work_position"].ToString();
                    pw.work_address = rdr["work_address"].ToString();
                    pw.work_start = rdr["work_start"].ToString();
                    pw.work_end = rdr["work_end"].ToString();
                    obj.Add(pw);

                }

                conn.Close();

            }
            
          return obj;
        }
        public List<personal_workModel> tb_work_person(string person)
        {

            List<personal_workModel> obj = new List<personal_workModel>();
            using (SqlConnection conn = new SqlConnection(db.sqlConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_personal_work WHERE work_ref_personal_id = '"+person+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    personal_workModel pw = new personal_workModel();
                    pw.work_company = rdr["work_company"].ToString();
                    pw.work_position = rdr["work_position"].ToString();
                    pw.work_address = rdr["work_address"].ToString();
                    pw.work_start =  Convert.ToDateTime(rdr["work_start"]).ToString("dd/MM/yyyy");
                    pw.work_end = Convert.ToDateTime(rdr["work_end"]).ToString("dd/MM/yyyy");
                    pw.work_id = rdr["work_id"].ToString();
                    pw.work_ref_personal_id = rdr["work_ref_personal_id"].ToString();
                    pw.work_ref_admin_id = rdr["work_ref_admin_id"].ToString();
                    pw.work_submit_date = rdr["work_submit_date"].ToString();


                    obj.Add(pw);

                }

                conn.Close();
            }

            return obj;
        }
        public void select_form_workId(string work) {

            using (SqlConnection conn = new SqlConnection(db.sqlConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_personal_work WHERE work_id = '" + work + "'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    
                    work_company = rdr["work_company"].ToString();
                    work_position = rdr["work_position"].ToString();
                    work_address = rdr["work_address"].ToString();
                    work_start = Convert.ToDateTime(rdr["work_start"]).ToString("dd/MM/yyyy");
                    work_end = Convert.ToDateTime(rdr["work_end"]).ToString("dd/MM/yyyy");
                    work_id = rdr["work_id"].ToString();
                    work_ref_personal_id = rdr["work_ref_personal_id"].ToString();
                    work_ref_admin_id = rdr["work_ref_admin_id"].ToString();
                    work_submit_date = rdr["work_submit_date"].ToString();

                    
                }

                conn.Close();
            }

        }
        public void insertWorkLOG() {

            databaseClassLOG dbl = new databaseClassLOG();

            string table = "tab_personal_work";
            string[] Columns = { "work_id","work_company", "work_address", "work_start", "work_end", "work_position", "work_ref_personal_id", "work_submit_date", "work_ref_admin_id" };
            string[] Value = {work_id, work_company, work_address, work_start, work_end, work_position, work_ref_personal_id, Convert.ToDateTime(work_submit_date).ToString("yyyy-MM-dd HH:mm:ss"), work_ref_admin_id };

            dbl.insert(table, Columns, Value);

        }
        public void updateWork() {

            databaseClass dbc = new databaseClass();

            string table = "tab_personal_work";
            string[] Columns = {  "work_company", "work_address", "work_start", "work_end", "work_position", "work_ref_personal_id", "work_submit_date", "work_ref_admin_id" };
            string[] Value = {  work_company, work_address, work_start, work_end, work_position, work_ref_personal_id, Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"), "1" };
            string where = "work_id = '"+work_id+"'";

            dbc.update(table, Columns, Value, where);
        }
    }
}
