using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class empFundChange
    {
        public string cf_id { get; set; }
        public string cf_fund_regis_id { get; set; }
        public string cf_fund_id_old { get; set; }
        public string cf_fund_start_old { get; set; }
        public string cf_fund_id_new { get; set; }
        public string cf_fund_start_new { get; set; }
        public string cf_change_type { get; set; }
        public string cf_submit_date { get; set; }
        public string cf_admin_id { get; set; }
        public string event_status { get; set; }
        public string cf_fund_age_old { get; set; }
        public string cf_ref_emp_id { get; set; }


        public string emp_code { get; set; }
        public string emp_name { get; set; }
        public string position { get; set; }
        public string comp { get; set; }
        public string sect { get; set; }
        public string dept { get; set; }
        public string fund_code_old { get; set; }
        public string fund_name_old { get; set; }
        public string fund_code_new { get; set; }
        public string fund_name_new { get; set; }
        
        
        CultureInfo en = new CultureInfo("EN");

        dbClass db = new dbClass();

        public void insert_fund_Change()
        {

            string table = "tab_emp_fundChange";

            string[] Columns = {
                
                "cf_fund_regis_id" ,
                "cf_fund_id_old",
                "cf_fund_start_old" ,
                "cf_fund_id_new" ,
                "cf_fund_start_new" ,
                "cf_change_type" ,
                "cf_submit_date",
                "cf_admin_id" ,
                "event_status",
                "cf_fund_age_old",
                "cf_ref_emp_id"

            };
            string[] Values = {
               cf_fund_regis_id ,
               cf_fund_id_old,
               Convert.ToDateTime(cf_fund_start_old).ToString("yyyy-MM-dd",en) ,
               cf_fund_id_new ,
               Convert.ToDateTime(cf_fund_start_new).ToString("yyyy-MM-dd",en) ,
               cf_change_type ,
               DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss",en),
               "1" ,
               "S" ,
               cf_fund_age_old,
               cf_ref_emp_id
            };


            db.insert_db(table, Columns, Values);

        }
        public void update_fund_Change()
        {

            string table = "tab_emp_fundChange";

            string[] Columns = {

                "cf_id",
                "cf_fund_regis_id" ,
                "cf_fund_id_old",
                "cf_fund_start_old" ,
                "cf_fund_id_new" ,
                "cf_fund_start_new" ,
                "cf_change_type" ,
                "cf_submit_date",
                "cf_admin_id" ,
                "event_status",
                "cf_fund_age_old",
                "cf_ref_emp_id"

            };
            string[] Values = {
               cf_id ,
               cf_fund_regis_id ,
               cf_fund_id_old,
               cf_fund_start_old ,
               cf_fund_id_new ,
               Convert.ToDateTime(cf_fund_start_old).ToString("yyyy-MM-dd",en) ,
               cf_fund_id_new ,
               Convert.ToDateTime(cf_fund_start_new).ToString("yyyy-MM-dd",en) ,
               cf_change_type ,
               DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss",en),
               cf_admin_id ,
               event_status ,
               cf_fund_age_old,
               cf_ref_emp_id
            };
            string where = "cf_id = '" + cf_id + "'";


            db.update_db(table, Columns, Values, where);

        }
        public void select_fund_Change()
        {


            string table = "tab_emp_fundChange";

            string[] Columns = {

                "cf_id",
                "cf_fund_regis_id" ,
                "cf_fund_id_old",
                "cf_fund_start_old" ,
                "cf_fund_id_new" ,
                "cf_fund_start_new" ,
                "cf_change_type" ,
                "cf_submit_date",
                "cf_admin_id" ,
                "event_status",
                "cf_fund_age_old",
                "cf_ref_emp_id"

            };
            string where = "cf_id = '" + cf_id + "'";
            string join = "";
            string groupby = "";
            string orderby = "";


            List<string> result = db.select_db(Columns, table, join, where, groupby, orderby);

            cf_id = result[0];
            cf_fund_regis_id = result[1];
            cf_fund_id_old = result[2];
            cf_fund_start_old = result[3];
            cf_fund_id_new = result[4];
            cf_fund_start_new = result[5];
            cf_change_type = result[6];
            cf_submit_date = result[7];
            cf_admin_id = result[8];
            event_status = result[9];
            cf_fund_age_old = result[10];


        }
        public void insert_fund_ChangeLOG()
        {

            db.sqlConnection = db.sqlConnection2;

            string table = "tab_emp_fundChange";

            string[] Columns = {

                "cf_id",
                "cf_fund_regis_id" ,
                "cf_fund_id_old",
                "cf_fund_start_old" ,
                "cf_fund_id_new" ,
                "cf_fund_start_new" ,
                "cf_change_type" ,
                "cf_submit_date",
                "cf_admin_id" ,
                "event_status",
                "cf_fund_age_old",
                "cf_ref_emp_id"

            };
            string[] Values = {
               cf_id ,
               cf_fund_regis_id ,
               cf_fund_id_old,
               cf_fund_start_old ,
               cf_fund_id_new ,
               Convert.ToDateTime(cf_fund_start_old).ToString("yyyy-MM-dd",en) ,
               cf_fund_id_new ,
               Convert.ToDateTime(cf_fund_start_new).ToString("yyyy-MM-dd",en) ,
               cf_change_type ,
               Convert.ToDateTime(cf_submit_date).ToString("yyyy-MM-dd",en) ,
               cf_admin_id ,
               event_status ,
               cf_fund_age_old,
               cf_ref_emp_id
            };


            db.insert_db(table, Columns, Values);

        }
        public List<empFundChange> list_fundChange()
        {

            List<empFundChange> obj = new List<empFundChange>();

            db.dbConnect();

            db.cmd = new System.Data.SqlClient.SqlCommand("SELECT cf.cf_id, em.ep_id, em.ep_code,p.ps_name_th+'   '+p.ps_lastname_th AS fullname,  p1.post_name AS post, c1.T_Company AS comp, s1.Section_name AS sect, d1.dept_name AS dept,"+
                   " f1.fund_code AS code_old, f1.fund_name AS fund_old, cf.cf_fund_start_old,"+
                   " f2.fund_code AS code_new, f2.fund_name AS fund_new, cf.cf_fund_start_new,"+
                   " cf.cf_submit_date, cf.cf_change_type, cf.cf_fund_age_old" +
                   " FROM tab_emp_fundChange AS cf"+
                   " INNER JOIN tab_info_fund AS f1 ON f1.fund_id = cf.cf_fund_id_old"+
                   " INNER JOIN tab_info_fund AS f2 ON f2.fund_id = cf.cf_fund_id_new"+
                   " INNER JOIN tab_emp AS em ON em.ep_id = cf.cf_ref_emp_id"+
                   " INNER JOIN tab_personal AS p ON p.ps_id = em.ep_ref_personal_id"+
                   " INNER JOIN tab_emp_position AS ps ON ps.position_emp_id = cf.cf_ref_emp_id"+
                   " INNER JOIN tab_position AS p1 ON p1.post_id = ps.position_posit_id"+
                   " INNER JOIN tab_company AS c1 ON c1.comp_id = ps.position_comp_id"+
                   " INNER JOIN tab_section As s1 ON s1.section_id = ps.position_sect_id"+
                   " INNER JOIN tab_department AS d1 ON d1.dept_id = ps.position_dept_id"+
                   " WHERE ps.position_active = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                empFundChange cf = new empFundChange();
                cf.cf_id = db.rdr["cf_id"].ToString();
                cf.cf_ref_emp_id = db.rdr["ep_id"].ToString();
                cf.emp_code = db.rdr["ep_code"].ToString();
                cf.emp_name = db.rdr["fullname"].ToString();
                cf.position = db.rdr["post"].ToString();
                cf.comp = db.rdr["comp"].ToString();
                cf.sect = db.rdr["sect"].ToString();
                cf.dept = db.rdr["dept"].ToString();
                cf.fund_code_old = db.rdr["code_old"].ToString();
                cf.fund_code_new = db.rdr["code_new"].ToString();
                cf.fund_name_old = db.rdr["fund_old"].ToString();
                cf.fund_name_new = db.rdr["fund_new"].ToString();
                cf.cf_fund_start_old = Convert.ToDateTime(db.rdr["cf_fund_start_old"]).ToString("dd MMMM yyyy");
                cf.cf_fund_start_new = Convert.ToDateTime(db.rdr["cf_fund_start_new"]).ToString("dd MMMM yyyy");
                cf.cf_submit_date=  Convert.ToDateTime(db.rdr["cf_submit_date"]).ToString("yyyyMM",en);
                cf.cf_change_type = db.rdr["cf_change_type"].ToString();
                cf.cf_fund_age_old = db.rdr["cf_fund_age_old"].ToString();

                obj.Add(cf);
            }

            db.dbClosed();

            return obj;
        }

        public List<empFundChange> list_fundChange_emp(string emp)
        {

            List<empFundChange> obj = new List<empFundChange>();

            db.dbConnect();

            db.cmd = new System.Data.SqlClient.SqlCommand("SELECT cf.cf_id, em.ep_id, em.ep_code,p.ps_name_th+'   '+p.ps_lastname_th AS fullname,  p1.post_name AS post, c1.T_Company AS comp, s1.Section_name AS sect, d1.dept_name AS dept," +
                   " f1.fund_code AS code_old, f1.fund_name AS fund_old, cf.cf_fund_start_old," +
                   " f2.fund_code AS code_new, f2.fund_name AS fund_new, cf.cf_fund_start_new," +
                   " cf.cf_submit_date, cf.cf_change_type, cf.cf_fund_age_old" +
                   " FROM tab_emp_fundChange AS cf" +
                   " INNER JOIN tab_info_fund AS f1 ON f1.fund_id = cf.cf_fund_id_old" +
                   " INNER JOIN tab_info_fund AS f2 ON f2.fund_id = cf.cf_fund_id_new" +
                   " INNER JOIN tab_emp AS em ON em.ep_id = cf.cf_ref_emp_id" +
                   " INNER JOIN tab_personal AS p ON p.ps_id = em.ep_ref_personal_id" +
                   " INNER JOIN tab_emp_position AS ps ON ps.position_emp_id = cf.cf_ref_emp_id" +
                   " INNER JOIN tab_position AS p1 ON p1.post_id = ps.position_posit_id" +
                   " INNER JOIN tab_company AS c1 ON c1.comp_id = ps.position_comp_id" +
                   " INNER JOIN tab_section As s1 ON s1.section_id = ps.position_sect_id" +
                   " INNER JOIN tab_department AS d1 ON d1.dept_id = ps.position_dept_id" +
                   " WHERE cf.cf_ref_emp_id = '"+emp+"' AND ps.position_active = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                empFundChange cf = new empFundChange();
                cf.cf_id = db.rdr["cf_id"].ToString();
                cf.cf_ref_emp_id = db.rdr["ep_id"].ToString();
                cf.emp_code = db.rdr["ep_code"].ToString();
                cf.emp_name = db.rdr["fullname"].ToString();
                cf.position = db.rdr["post"].ToString();
                cf.comp = db.rdr["comp"].ToString();
                cf.sect = db.rdr["sect"].ToString();
                cf.dept = db.rdr["dept"].ToString();
                cf.fund_code_old = db.rdr["code_old"].ToString();
                cf.fund_code_new = db.rdr["code_new"].ToString();
                cf.fund_name_old = db.rdr["fund_old"].ToString();
                cf.fund_name_new = db.rdr["fund_new"].ToString();
                cf.cf_fund_start_old = Convert.ToDateTime(db.rdr["cf_fund_start_old"]).ToString("dd MMMM yyyy");
                cf.cf_fund_start_new = Convert.ToDateTime(db.rdr["cf_fund_start_new"]).ToString("dd MMMM yyyy");
                cf.cf_submit_date = Convert.ToDateTime(db.rdr["cf_submit_date"]).ToString("dd MMMM yyyy");
                cf.cf_change_type = db.rdr["cf_change_type"].ToString();
                cf.cf_fund_age_old = db.rdr["cf_fund_age_old"].ToString();

                obj.Add(cf);
            }

            db.dbClosed();

            return obj;
        }


    }
}
