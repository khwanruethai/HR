using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class EmpPositionResignModel
    {
        public string prs_id { get; set; }
        public string prs_ref_emp_posit_id { get; set; }
        public string prs_ref_emp_id { get; set; }
        public string prs_position_id { get; set; }
        public string prs_comp_id { get; set; }
        public string prs_section_id { get; set; }
        public string prs_dept_id { get; set; }
        public string prs_type { get; set; }
        public string prs_start_date { get; set; }
        public string prs_resign_date { get; set; }
        public string prs_submit_date { get; set; }
        public string prs_admin_id { get; set; }
        public string event_status { get; set; }
        public string prs_resign_type { get; set; }
        public string prs_resign_detail { get; set; }

        public string position_name { get; set; }
        public string comp_name { get; set; }
        public string section_name { get; set; }
        public string dept_name { get; set; }
        public string  type_name{ get; set; }

        CultureInfo en = new CultureInfo("EN");

        public void insert_resign_position()
        {
            databaseClass db = new databaseClass();

            string table = "tab_emp_position_resign";
            string[] Columns = {"prs_ref_emp_posit_id", "prs_ref_emp_id", "prs_position_id", "prs_comp_id", "prs_section_id", "prs_dept_id", "prs_type", "prs_start_date", "prs_resign_date", "prs_submit_date", "prs_admin_id", "event_status", "prs_resign_type", "prs_resign_detail" };
            string[] Value = { prs_ref_emp_posit_id, prs_ref_emp_id, prs_position_id, prs_comp_id, prs_section_id, prs_dept_id, prs_type, Convert.ToDateTime(prs_start_date).ToString("yyyy-MM-dd",en), Convert.ToDateTime(prs_resign_date).ToString("yyyy-MM-dd", en), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), "1", "S", prs_resign_type, prs_resign_detail};

            db.insert(table, Columns, Value);
        }
        public void update_resign_position()
        {
            databaseClass db = new databaseClass();

            string table = "tab_emp_position_resign";
            string[] Columns = { "prs_ref_emp_posit_id", "prs_ref_emp_id", "prs_position_id", "prs_comp_id", "prs_section_id", "prs_dept_id", "prs_type", "prs_start_date", "prs_resign_date", "prs_submit_date", "prs_admin_id", "event_status", "prs_resign_type", "prs_resign_detail" };
            string[] Value = {  prs_ref_emp_posit_id, prs_ref_emp_id, prs_position_id, prs_comp_id, prs_section_id, prs_dept_id, prs_type, Convert.ToDateTime(prs_start_date).ToString("yyyy-MM-dd", en), Convert.ToDateTime(prs_resign_date).ToString("yyyy-MM-dd",en), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss",en), "1", event_status, prs_resign_type, prs_resign_detail };
            string where = "prs_id = '"+ prs_id + "'";
            db.update(table, Columns, Value, where);
        }
        public void insert_resign_LOG()
        {
            databaseClass db = new databaseClass();

            string table = "tab_emp_position_resign";
            string[] Columns = { "prs_id", "prs_ref_emp_posit_id", "prs_ref_emp_id", "prs_position_id", "prs_comp_id", "prs_section_id", "prs_dept_id", "prs_type", "prs_start_date", "prs_resign_date", "prs_submit_date", "prs_admin_id", "event_status", "prs_resign_type", "prs_resign_detail" };
            string[] Value = { prs_id, prs_ref_emp_posit_id, prs_ref_emp_id, prs_position_id, prs_comp_id, prs_section_id, prs_dept_id, prs_type, Convert.ToDateTime(prs_start_date).ToString("yyyy-MM-dd", en), Convert.ToDateTime(prs_resign_date).ToString("yyyy-MM-dd", en), Convert.ToDateTime(prs_submit_date).ToString("yyyy-MM-dd HH:mm:ss",en), prs_admin_id, event_status, prs_resign_type, prs_resign_detail };

            db.insert(table, Columns, Value);
        }
        public void select_resign_position()
        {
            dbFile db = new dbFile();
            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_position_resign WHERE pres_id = '"+prs_id+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    prs_id = rdr["prs_id"].ToString();
                    prs_ref_emp_posit_id = rdr["prs_ref_emp_posit_id"].ToString();
                    prs_ref_emp_id = rdr["prs_ref_emp_id"].ToString();
                    prs_position_id = rdr["prs_position_id"].ToString();
                    prs_comp_id = rdr["prs_comp_id"].ToString();
                    prs_section_id = rdr["prs_section_id"].ToString();
                    prs_dept_id = rdr["prs_dept_id"].ToString();
                    prs_type = rdr["prs_type"].ToString();
                    prs_start_date = rdr["prs_start_date"].ToString();
                    prs_resign_date = rdr["prs_resign_date"].ToString();
                    prs_submit_date = rdr["prs_submit_date"].ToString();
                    prs_admin_id = rdr["prs_admin_id"].ToString();
                    event_status = rdr["event_status"].ToString();
                    prs_resign_type = rdr["prs_resign_type"].ToString();
                    prs_resign_detail = rdr["prs_resign_detail"].ToString();
                    

                }

                conn.Close();
            }
        }
        public List<EmpPositionResignModel> list_position_resign_emp(string emp) {

            List<EmpPositionResignModel> obj = new List<EmpPositionResignModel>();

            dbFile db = new dbFile();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT "+
                      " rs.prs_id, rs.prs_ref_emp_posit_id, rs.prs_ref_emp_id, rs.prs_start_date, rs.prs_resign_date, rs.prs_submit_date, rs.prs_admin_id, rs.event_status, rs.prs_resign_type, rs.prs_resign_detail, " +
                      " rs.prs_position_id, pos.post_name AS position_name, rs.prs_comp_id, comp.T_Company AS comp_name, rs.prs_section_id, sect.Section_name AS section_name, rs.prs_dept_id, dept.dept_name AS dept_name, rs.prs_type, type.type_name"+
                      " FROM tab_emp_position_resign AS rs"+
                      " INNER JOIN tab_position AS pos ON pos.post_id = rs.prs_position_id"+
                      " INNER JOIN tab_company AS comp ON comp.comp_id = rs.prs_comp_id"+
                      " INNER JOIN tab_section AS sect ON sect.section_id = rs.prs_section_id"+
                      " INNER JOIN tab_department AS dept ON dept.dept_id = rs.prs_dept_id"+
                      " INNER JOIN tab_emp_type AS type ON type.type_id = rs.prs_type"+
                      " WHERE rs.prs_ref_emp_id = '"+emp+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    EmpPositionResignModel prs = new EmpPositionResignModel();
                    prs.prs_id = rdr["prs_id"].ToString();
                    prs.prs_ref_emp_posit_id = rdr["prs_ref_emp_posit_id"].ToString();
                    prs.prs_ref_emp_id = rdr["prs_ref_emp_id"].ToString();
                    prs.prs_position_id = rdr["prs_position_id"].ToString();
                    prs.prs_comp_id = rdr["prs_comp_id"].ToString();
                    prs.prs_section_id = rdr["prs_section_id"].ToString();
                    prs.prs_dept_id = rdr["prs_dept_id"].ToString();
                    prs.prs_type = rdr["prs_type"].ToString();
                    prs.prs_start_date = Convert.ToDateTime(rdr["prs_start_date"]).ToString("dd MMMM yyyy");
                    prs.prs_resign_date = Convert.ToDateTime(rdr["prs_resign_date"]).ToString("dd MMMM yyyy");
                    prs.prs_submit_date = rdr["prs_submit_date"].ToString();
                    prs.prs_admin_id = rdr["prs_admin_id"].ToString();
                    prs.event_status = rdr["event_status"].ToString();
                    prs.prs_resign_type = rdr["prs_resign_type"].ToString();
                    prs.prs_resign_detail = rdr["prs_resign_detail"].ToString();

                    prs.position_name = rdr["position_name"].ToString();
                    prs.comp_name = rdr["comp_name"].ToString();
                    prs.section_name = rdr["section_name"].ToString();
                    prs.dept_name = rdr["dept_name"].ToString();
                    prs.type_name = rdr["type_name"].ToString();

                    obj.Add(prs);
                }

                conn.Close();
            }
            
         return obj;
        }
    }

  }
