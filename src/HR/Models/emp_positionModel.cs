using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class emp_positionModel
    {
        public string pos_id { get; set; }
        public string pos_emp_id { get; set; }
        public string pos_comp_id { get; set; }
        public string pos_comp_name { get; set; }
        public string pos_sect_id { get; set; }
        public string pos_sect_name { get; set; }
        public string pos_dept_id { get; set; }
        public string pos_dept_name { get; set; }
        public string pos_position_id { get; set; }
        public string pos_position_name { get; set; }
        public string pos_type { get; set; }
        public string pos_type_name { get; set; }
        public string pos_start_date { get; set; }
        public string pos_resign_date { get; set; }
        public string pos_admin_id { get; set; }
        public string pos_submit_date { get; set; }
        public string pos_status { get; set; }
        public string pos_check { get; set; }
        public string pos_active { get; set; }
        public string event_status { get; set; }

       public int num { get; set; }

        databaseClass db = new databaseClass();
        dbFile conStr = new dbFile();
        CultureInfo en = new CultureInfo("EN");

        public string connectionString() {

            return conStr.sqlConnection;
        }
        public string checkCount(string emp) {

            using (SqlConnection conn = new SqlConnection(connectionString())) {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(position_emp_id) AS countPosition FROM tab_emp_position WHERE position_emp_id = '" + emp+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    pos_check = rdr["countPosition"].ToString();
                }
                conn.Close();
            }
            
            return pos_check;
        }
        public void check_position() {

            using (SqlConnection conn = new SqlConnection(connectionString())) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(position_id) AS num FROM tab_emp_position WHERE position_emp_id = '"+pos_emp_id+"' AND position_active = 'Y' AND position_status = 'Y' AND event_status != 'D' ", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {
                    
                    num = Convert.ToInt32(rdr["num"]);

                }
                conn.Close();
            }
            
        }

        public void insert_position() {

            check_position();

            if (num > 0)
            {
                pos_active = "N";

            }
            else {

                pos_active = "Y";

            }


            string table = "tab_emp_position";
            string[] Columns = { "position_emp_id", "position_comp_id", "position_sect_id", "position_dept_id", "position_posit_id", "position_type", "position_start_date", "position_resign_date", "position_admin_id", "position_submit_date", "position_status", "position_active", "event_status" };
            string[] Value = {  pos_emp_id, pos_comp_id, pos_sect_id, pos_dept_id, pos_position_id, pos_type, pos_start_date, pos_resign_date, "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "Y", pos_active, "S"};
            db.insert_db(table, Columns, Value);

        }
        public void selectPositionByemp(string emp) {

            using (SqlConnection conn = new SqlConnection(connectionString())) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_position "+
                    " INNER JOIN tab_position ON tab_position.post_id = position_id" +
                    " INNER JOIN tab_company ON tab_company.comp_id = position_comp_id" +
                    " INNER JOIN tab_section ON tab_section.section_id = position_sect_id" +
                    " INNER JOIN tab_department ON tab_department.dept_id = position_dept_id" +
                    " INNER JOIN tab_emp_type ON tab_emp_type.type_id = position_type" +
                    " WHERE position_emp_id = '"+emp+"'"
                    , conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    pos_admin_id = rdr["position_admin_id"].ToString();
                    pos_comp_id = rdr["position_comp_id"].ToString();
                    pos_comp_name = rdr["T_Company"].ToString();
                    pos_dept_id = rdr["position_dept_id"].ToString();
                    pos_dept_name = rdr["dept_name"].ToString();
                    pos_emp_id = rdr["position_emp_id"].ToString();
                    pos_id = rdr["position_id"].ToString();
                    pos_position_id = rdr["position_posit_id"].ToString();
                    pos_position_name = rdr["post_name"].ToString();
                    pos_resign_date = rdr["position_resign_date"].ToString();
                    pos_sect_id = rdr["position_sect_id"].ToString();
                    pos_sect_name = rdr["Section_name"].ToString();
                    pos_start_date = rdr["position_start_date"].ToString();
                    pos_status = rdr["position_status"].ToString();
                    pos_submit_date = rdr["position_submit_date"].ToString();
                    pos_type = rdr["position_type"].ToString();
                    pos_type_name = rdr["type_name"].ToString();
                    pos_active = rdr["position_active"].ToString();
                    event_status = rdr["event_status"].ToString();
                    

                }

                conn.Close();
            }

        }
        public void selectPositionById(string position)
        {

            using (SqlConnection conn = new SqlConnection(connectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_position " +
                    " WHERE position_id = '" + position + "'"
                    , conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    pos_admin_id = rdr["position_admin_id"].ToString();
                    pos_comp_id = rdr["position_comp_id"].ToString();
                  //  pos_comp_name = rdr["T_Company"].ToString();
                    pos_dept_id = rdr["position_dept_id"].ToString();
                  //  pos_dept_name = rdr["dept_name"].ToString();
                    pos_emp_id = rdr["position_emp_id"].ToString();
                    pos_id = rdr["position_id"].ToString();
                    pos_position_id = rdr["position_posit_id"].ToString();
                   // pos_position_name = rdr["post_name"].ToString();
                    pos_resign_date = Convert.ToDateTime(rdr["position_resign_date"]).ToString("dd/MM/yyyy");
                    pos_sect_id = rdr["position_sect_id"].ToString();
                   // pos_sect_name = rdr["Section_name"].ToString();
                    pos_start_date = Convert.ToDateTime(rdr["position_start_date"]).ToString("dd/MM/yyyy");
                    pos_status = rdr["position_status"].ToString();
                    pos_submit_date = rdr["position_submit_date"].ToString();
                    pos_type = rdr["position_type"].ToString();
                    pos_active = rdr["position_active"].ToString();
                    event_status = rdr["event_status"].ToString();
                    // pos_type_name = rdr["type_name"].ToString();


                }

                conn.Close();
            }

        }
        public List<emp_positionModel> emp_position_list(string emp_id) {


            List<emp_positionModel> obj = new List<emp_positionModel>();

            using (SqlConnection conn = new SqlConnection(connectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_position AS p" +
                    " INNER JOIN tab_position ON tab_position.post_id = position_posit_id" +
                    " INNER JOIN tab_company ON tab_company.comp_id = position_comp_id" +
                    " INNER JOIN tab_section ON tab_section.section_id = position_sect_id" +
                    " INNER JOIN tab_department ON tab_department.dept_id = position_dept_id" +
                    " INNER JOIN tab_emp_type ON tab_emp_type.type_id = position_type" +
                    " WHERE p.position_emp_id ='"+emp_id+"' AND NOT EXISTS ("+
                    "    SELECT ch.pc_ref_emp_position_id FROM  tab_emp_position_change AS ch WHERE p.position_id = ch.pc_ref_emp_position_id)", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    emp_positionModel emp = new emp_positionModel();

                    emp.pos_admin_id = rdr["position_admin_id"].ToString();
                    emp.pos_comp_id = rdr["position_comp_id"].ToString();
                    emp.pos_comp_name = rdr["T_Company"].ToString();
                    emp.pos_dept_id = rdr["position_dept_id"].ToString();
                    emp.pos_dept_name = rdr["dept_name"].ToString();
                    emp.pos_emp_id = rdr["position_emp_id"].ToString();
                    emp.pos_id = rdr["position_id"].ToString();
                    emp.pos_position_id = rdr["position_posit_id"].ToString();
                    emp.pos_position_name = rdr["post_name"].ToString();
                    emp.pos_resign_date = rdr["position_resign_date"].ToString();
                    emp.pos_sect_id = rdr["position_sect_id"].ToString();
                    emp.pos_sect_name = rdr["Section_name"].ToString();
                    emp.pos_start_date = rdr["position_start_date"].ToString();
                    emp.pos_status = rdr["position_status"].ToString();
                    emp.pos_submit_date = rdr["position_submit_date"].ToString();
                    emp.pos_type = rdr["position_type"].ToString();
                    emp.pos_type_name = rdr["type_name"].ToString();
                    emp.pos_active = rdr["position_active"].ToString();

                    obj.Add(emp);
                }

                conn.Close();
            }
            
            return obj;

        }
        public void insert_positionLOG()
        {
            databaseClassLOG dbl = new databaseClassLOG();

            string table = "tab_emp_position";
            string[] Columns = { "position_id", "position_emp_id", "position_comp_id", "position_sect_id", "position_dept_id", "position_posit_id", "position_type", "position_start_date", "position_resign_date", "position_admin_id", "position_submit_date", "position_status", "position_active", "event_status" };
            string[] Value = { pos_id,pos_emp_id, pos_comp_id, pos_sect_id, pos_dept_id, pos_position_id, pos_type, Convert.ToDateTime(pos_start_date).ToString("yyyy-MM-dd", en), Convert.ToDateTime(pos_resign_date).ToString("yyyy-MM-dd", en), pos_emp_id, Convert.ToDateTime(pos_submit_date).ToString("yyyy-MM-dd HH:mm:ss",en), pos_status, pos_active, event_status };
            dbl.insert_db(table, Columns, Value);

        }
        public void update_position()
        {

            string table = "tab_emp_position";
            string[] Columns = { "position_emp_id", "position_comp_id", "position_sect_id", "position_dept_id", "position_posit_id", "position_type", "position_start_date", "position_resign_date", "position_admin_id", "position_submit_date", "position_status", "position_active" , "event_status"};
            string[] Value = { pos_emp_id, pos_comp_id, pos_sect_id, pos_dept_id, pos_position_id, pos_type, Convert.ToDateTime(pos_start_date).ToString("yyyy-MM-dd", en), Convert.ToDateTime(pos_resign_date).ToString("yyyy-MM-dd",en), "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en),pos_status, pos_active, event_status };
            string where = "position_id = '"+pos_id+"'";

            db.update(table, Columns, Value, where);

        }
        public void check_position_main() {

            using (SqlConnection conn = new SqlConnection(connectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT position_id FROM tab_emp_position WHERE position_emp_id = '"+pos_emp_id+"' AND position_active = 'Y' AND position_status = 'Y'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    pos_id = rdr["position_id"].ToString();

                }
                conn.Close();
            }
        }
    }
}
