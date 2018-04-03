using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class empPositionChangeModel
    {
        public string pc_id { get; set; }
        public string pc_emp_id { get; set; }
        public string pc_comp_id { get; set; }
        public string pc_sect_id { get; set; }
        public string pc_dept_id { get; set; }
        public string pc_position_id { get; set; }
        public string pc_type { get; set; }
        public string pc_start_date { get; set; }
        public string pc_resign_date { get; set; }
        public string pc_admin_id { get; set; }
        public string pc_submit_date { get; set; }
        public string pc_status { get; set; }
        public string pc_active { get; set; }
        public string event_status { get; set; }
        public string  pc_position_id_old { get; set; }
        public string  pc_company_old { get; set; }
        public string  pc_section_old { get; set; }
        public string  pc_dept_old { get; set; }
        public string  pc_type_old { get; set; }
        public string  pc_start_old { get; set; }
        public string  pc_end_old { get; set; }
        public string  pc_ref_emp_position_id { get; set; }

        CultureInfo en = new CultureInfo("EN");

        DateTime dt = new DateTime(3000,01,01);

        public void insert_position_chane() {

            databaseClass db = new databaseClass();
            

            string table = "tab_emp_position_change";
            string[] Columns = {  "pc_emp_id", "pc_comp_id" , "pc_sect_id", "pc_dept_id" ,  "pc_position_id" ,   "pc_type" ,  "pc_start_date",  "pc_resign_date" ,  "pc_admin_id" ,   "pc_submit_date",  "pc_status" ,  "pc_active" ,  "event_status", "pc_position_id_old", "pc_company_old", "pc_section_old", "pc_dept_old", "pc_type_old", "pc_start_old", "pc_end_old", "pc_ref_emp_position_id" };
            string[] Value = {  pc_emp_id, pc_comp_id, pc_sect_id, pc_dept_id, pc_position_id, pc_type, Convert.ToDateTime(pc_start_date).ToString("yyyy-MM-dd", en), Convert.ToDateTime(dt).ToString("yyyy-MM-dd", en), pc_admin_id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), pc_status, pc_active, event_status, pc_position_id_old, pc_company_old, pc_section_old, pc_dept_old, pc_type_old, Convert.ToDateTime(pc_start_old).ToString("yyyy-MM-dd", en), Convert.ToDateTime(pc_end_old).ToString("yyyy-MM-dd", en), pc_ref_emp_position_id };

            db.insert(table, Columns, Value);

        }
        public void update_position_change() {

            databaseClass db = new databaseClass();
            string table = "tab_emp_position_change";
            string[] Columns = { "pc_emp_id", "pc_comp_id", "pc_sect_id", "pc_dept_id", "pc_position_id", "pc_type", "pc_start_date", "pc_resign_date", "pc_admin_id", "pc_submit_date", "pc_status", "pc_active", "event_status", "pc_position_id_old", "pc_company_old", "pc_section_old", "pc_dept_old", "pc_type_old", "pc_start_old", "pc_end_old", "pc_ref_emp_position_id" };
            string[] Value = { pc_emp_id, pc_comp_id, pc_sect_id, pc_dept_id, pc_position_id, pc_type, pc_start_date, pc_resign_date, pc_admin_id, pc_submit_date, pc_status, pc_active, event_status , pc_position_id_old, pc_company_old, pc_section_old, pc_dept_old, pc_type_old, pc_start_old, pc_end_old, pc_ref_emp_position_id };
            string where = "pc_id = '"+ pc_id + "'";
            db.update(table, Columns, Value, where);

        }
        public void select_position_change_id() {

            dbFile db = new dbFile();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FORM tab_emp_position_change WHERE pc_id = '" + pc_id+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    pc_id = rdr["pc_id"].ToString();
                    pc_emp_id = rdr["pc_emp_id"].ToString();
                    pc_comp_id = rdr["pc_comp_id"].ToString();
                    pc_sect_id = rdr["pc_sect_id"].ToString();
                    pc_dept_id = rdr["pc_dept_id"].ToString();
                    pc_position_id = rdr["pc_position_id"].ToString();
                    pc_type = rdr["pc_type"].ToString();
                    pc_start_date = rdr["pc_start_date"].ToString();
                    pc_resign_date = rdr["pc_resign_date"].ToString();
                    pc_admin_id = rdr["pc_admin_id"].ToString();
                    pc_submit_date = rdr["pc_submit_date"].ToString();
                    pc_status = rdr["pc_status"].ToString();
                    pc_active = rdr["pc_active"].ToString();
                    event_status = rdr["event_status"].ToString();
                    pc_position_id_old = rdr["pc_position_id_old"].ToString();
                    pc_company_old = rdr["pc_company_old"].ToString();
                    pc_section_old = rdr["pc_section_old"].ToString();
                    pc_dept_old = rdr["pc_dept_old"].ToString();
                    pc_type_old = rdr["pc_type_old"].ToString();
                    pc_start_old = rdr["pc_start_old"].ToString();
                    pc_end_old = rdr["pc_end_old"].ToString();
                    pc_ref_emp_position_id = rdr["pc_ref_emp_position_id"].ToString();

                }

                conn.Close();
            }

        }
        public List<empPositionChangeModel> list_posiotnChane_emp_id() {

            dbFile db = new dbFile();

            List<empPositionChangeModel> obj = new List<empPositionChangeModel>();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT pc_id, pc_emp_id, "+
                        " pc_start_date, pc_position_id AS p1, ps1.post_name AS p1_name, pc_comp_id AS c1, cp1.T_Company AS c1_name, pc_sect_id AS s1, st1.Section_name AS s1_name, pc_dept_id AS d1, dp1.dept_name AS d1_name, pc_type, tp1.type_name AS t1_name," +
                        " pc_start_old, pc_position_id_old  AS p2, ps2.post_name AS p2_name, pc_company_old AS c2, cp2.T_Company AS c2_name, pc_section_old AS s2, st2.Section_name AS s2_name, pc_dept_old As d2, dp2.dept_name AS d2_name, pc_type_old, tp2.type_name AS t2_name," +
                        " pc_submit_date "+
                        " FROM tab_emp_position_change "+
                        " INNER JOIN tab_position AS ps1 ON ps1.post_id = pc_position_id"+
                        " INNER JOIN tab_position AS ps2 ON ps2.post_id = pc_position_id_old"+
                        " INNER JOIN tab_company AS cp1 ON cp1.comp_id = pc_comp_id"+
                        " INNER JOIN tab_company AS cp2 ON cp2.comp_id = pc_company_old"+
                        " INNER JOIN tab_section AS st1 ON st1.section_id = pc_sect_id"+
                        " INNER JOIN tab_section AS st2 ON st2.section_id = pc_section_old"+
                        " INNER JOIN tab_department AS dp1 ON dp1.dept_id = pc_dept_id"+
                        " INNER JOIN tab_department AS dp2 ON dp2.dept_id = pc_dept_old"+
                        " INNER JOIN tab_emp_type AS tp1 ON tp1.type_id = pc_type"+
                        " INNER JOIN tab_emp_type AS tp2 ON tp2.type_id = pc_type_old"+
                        " WHERE pc_emp_id = '" +pc_emp_id+"'"+
                        " ORDER BY pc_submit_date DESC", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    empPositionChangeModel pc = new empPositionChangeModel();

                   pc.pc_id = rdr["pc_id"].ToString();
                   pc.pc_emp_id = rdr["pc_emp_id"].ToString();
                   pc.pc_comp_id = rdr["c1_name"].ToString();
                   pc.pc_sect_id = rdr["s1_name"].ToString();
                   pc.pc_dept_id = rdr["d1_name"].ToString();
                   pc.pc_position_id = rdr["p1_name"].ToString();
                   pc.pc_type = rdr["t1_name"].ToString();
                   pc.pc_start_date =  Convert.ToDateTime(rdr["pc_start_date"]).ToString("dd-MM-yyyy");
                   pc.pc_submit_date =  rdr["pc_submit_date"].ToString();
                   pc.pc_position_id_old = rdr["p2_name"].ToString();
                   pc.pc_company_old = rdr["c2_name"].ToString();
                   pc.pc_section_old = rdr["s2_name"].ToString();
                   pc.pc_dept_old = rdr["d2_name"].ToString();
                   pc.pc_type_old = rdr["t2_name"].ToString();
                   pc.pc_start_old = Convert.ToDateTime(rdr["pc_start_old"]).ToString("dd-MM-yyyy");
                    
                    obj.Add(pc);
                }


                conn.Close();
            }



                return obj;
           
        }
       
        
    }
}
