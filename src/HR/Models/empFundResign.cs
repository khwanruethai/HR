using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class empFundResign
    {

        public string fnr_id { get; set; }
        public string fnr_ref_fundRegis_id { get; set; }
        public string fnr_ref_fund_id { get; set; }
        public string fnr_ref_emp_id { get; set; }
        public string fnr_start_date { get; set; }
        public string fnr_resign_date { get; set; }
        public string fnr_type_resign { get; set; }
        public string fnr_detail_resign { get; set; }
        public string fnr_submit_date { get; set; }
        public string fnr_admin_id { get; set; }
        public string fnr_status { get; set; }
        public string event_status { get; set; }
        //
        public string emp_id { get; set; }
        public string emp_code { get; set; }
        public string emp_name { get; set; }
        public string emp_position { get; set; }
        public string emp_cpmp { get; set; }
        public string emp_sect{get;set;}
        public string emp_dept { get; set; }

        public string fund_code { get; set; }
        public string fund_name { get; set; }
        public string age { get; set; }


        CultureInfo en = new CultureInfo("EN");

        dbClass db = new dbClass();

        public void insert_fund_resign() {

            string table = "tab_emp_fundResign";
       
            string[] Columns = {
                "fnr_ref_fundRegis_id",
                "fnr_ref_fund_id" ,
                "fnr_ref_emp_id" ,
                "fnr_start_date" ,
                "fnr_resign_date" ,
                "fnr_type_resign" ,
                "fnr_detail_resign" ,
                "fnr_submit_date" ,
                "fnr_admin_id" ,
                "fnr_status" ,
                "event_status"
            };
            string[] Values = {
                fnr_ref_fundRegis_id,
                fnr_ref_fund_id ,
                fnr_ref_emp_id ,
                Convert.ToDateTime(fnr_start_date).ToString("yyyy-MM-dd",en) ,
                Convert.ToDateTime(fnr_resign_date).ToString("yyyy-MM-dd", en) ,
                fnr_type_resign ,
                fnr_detail_resign ,
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en) ,
                "1" ,
                "Y" ,
                "S"
            };


            db.insert_db(table, Columns, Values);
            
        }
        public void update_fund_resign() {
            
            string table = "tab_emp_fundResign";
            string[] Values = {
                fnr_ref_fundRegis_id,
                fnr_ref_fund_id ,
                fnr_ref_emp_id ,
                Convert.ToDateTime(fnr_start_date).ToString("yyyy-MM-dd",en) ,
                Convert.ToDateTime(fnr_resign_date).ToString("yyyy-MM-dd",en) ,
                fnr_type_resign ,
                fnr_detail_resign ,
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss",en) ,
                "1" ,
                fnr_status ,
                event_status
            };
            string[] Columns = {
                "fnr_ref_fundRegis_id",
                "fnr_ref_fund_id" ,
                "fnr_ref_emp_id" ,
                "fnr_start_date" ,
                "fnr_resign_date" ,
                "fnr_type_resign" ,
                "fnr_detail_resign" ,
                "fnr_submit_date" ,
                "fnr_admin_id" ,
                "fnr_status" ,
                "event_status"
            };
            string where = "fnr_id = '"+fnr_id+"'";


            db.update_db(table, Columns, Values, where);

        }
        public void select_fund_resign() {


            string table = "tab_emp_fundResign";
            string[] Columns = {
                "fnr_id" ,
                "fnr_ref_fundRegis_id",
                "fnr_ref_fund_id" ,
                "fnr_ref_emp_id" ,
                "fnr_start_date" ,
                "fnr_resign_date" ,
                "fnr_type_resign" ,
                "fnr_detail_resign" ,
                "fnr_submit_date" ,
                "fnr_admin_id" ,
                "fnr_status" ,
                "event_status"
            };
            string where = "fnr_id = '"+fnr_id+"'";
            string join = "";
            string groupby = "";
            string orderby = "";


         List<string> result =    db.select_db(Columns, table, join, where, groupby, orderby);

            fnr_id = result[0];
            fnr_ref_fundRegis_id = result[1];
            fnr_ref_fund_id = result[2];
            fnr_ref_emp_id = result[3];
            fnr_start_date = result[4];
            fnr_resign_date  = result[5];
            fnr_type_resign = result[6];
            fnr_detail_resign = result[7];
            fnr_submit_date = result[8];
            fnr_admin_id  = result[9];
            fnr_status  = result[10];
            event_status = result[11];


        }
        public void insert_fund_resingLOG() {

            db.sqlConnection = db.sqlConnection2;

            string table = "tab_emp_fundResign";
            string[] Values = {
                fnr_id ,
                fnr_ref_fundRegis_id,
                fnr_ref_fund_id ,
                fnr_ref_emp_id ,
                Convert.ToDateTime(fnr_start_date).ToString("yyyy-MM-dd",en) ,
                Convert.ToDateTime(fnr_resign_date).ToString("yyyyMM-dd",en) ,
                fnr_type_resign ,
                fnr_detail_resign ,
                Convert.ToDateTime(fnr_submit_date).ToString("yyyy-MM-dd HH:mm:ss",en) ,
                fnr_admin_id ,
                fnr_status ,
                event_status
            };
            string[] Columns = {
                "fnr_id" ,
                "fnr_ref_fundRegis_id",
                "fnr_ref_fund_id" ,
                "fnr_ref_emp_id" ,
                "fnr_start_date" ,
                "fnr_resign_date" ,
                "fnr_type_resign" ,
                "fnr_detail_resign" ,
                "fnr_submit_date" ,
                "fnr_admin_id" ,
                "fnr_status" ,
                "event_status"
            };


            db.insert_db(table, Columns, Values);

        }
        public List<empFundResign> list_fundResign() {

            List<empFundResign> obj = new List<empFundResign>();

            db.dbConnect();

            db.cmd = new System.Data.SqlClient.SqlCommand("SELECT fnr.fnr_id,emp.ep_id, emp.ep_code, ps.ps_name_th+'  '+ps.ps_lastname_th AS fullname, p.post_name, comp.T_Company AS comp, sect.Section_name AS sect, dept.dept_name As dept,"+
                              " fn.fund_code, fn.fund_name, fnr.fnr_start_date, fnr.fnr_resign_date,"+
                              " fnr.fnr_type_resign,"+
                              " fnr.fnr_detail_resign, fnr.fnr_submit_date AS submit"+
                              " FROM tab_emp_fundResign AS fnr"+
                              " INNER JOIN tab_emp_fundRegis AS  fr ON fr.fr_id = fnr.fnr_ref_fundRegis_id"+
                              " INNER JOIN tab_info_fund AS fn ON fn.fund_id = fnr.fnr_ref_fund_id"+
                              " INNER JOIN tab_emp AS emp ON emp.ep_id = fnr.fnr_ref_emp_id"+
                              " INNER JOIN tab_personal AS ps ON ps.ps_id = emp.ep_ref_personal_id"+
                              " INNER JOIN tab_emp_position AS ep ON ep.position_emp_id = fnr.fnr_ref_emp_id"+
                              " INNER JOIN tab_position AS p ON p.post_id = ep.position_posit_id"+
                              " INNER JOIN tab_company AS comp ON comp.comp_id = ep.position_comp_id"+
                              " INNER JOIN tab_section AS sect ON sect.section_id = ep.position_sect_id"+
                              " INNER JOIN tab_department AS dept ON dept.dept_id = ep.position_dept_id"+
                              " WHERE ep.position_active = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read()) {

                empFundResign fnr = new empFundResign();

                fnr.fnr_id = db.rdr["fnr_id"].ToString();
                fnr.fnr_start_date = db.rdr["fnr_start_date"].ToString();
                fnr.fnr_resign_date = db.rdr["fnr_resign_date"].ToString();
                fnr.fnr_type_resign = db.rdr["fnr_type_resign"].ToString();
                fnr.fnr_detail_resign = db.rdr["fnr_detail_resign"].ToString();
                fnr.emp_id = db.rdr["ep_id"].ToString();
                fnr.emp_code = db.rdr["ep_code"].ToString();
                fnr.emp_name = db.rdr["fullname"].ToString();
                fnr.emp_position = db.rdr["post_name"].ToString();
                fnr.emp_cpmp = db.rdr["comp"].ToString();
                fnr.emp_sect = db.rdr["sect"].ToString();
                fnr.emp_dept = db.rdr["dept"].ToString();
                fnr.fund_code = db.rdr["fund_code"].ToString();
                fnr.fund_name = db.rdr["fund_name"].ToString();
                fnr.age = (Convert.ToDateTime(fnr.fnr_resign_date) - Convert.ToDateTime(fnr.fnr_start_date)).TotalDays.ToString();
                fnr.fnr_submit_date = db.rdr["submit"].ToString();


                obj.Add(fnr);
            }

            db.dbClosed();

            return obj;
        }
        public List<empFundResign> list_fundResignEmp(string emp)
        {

            List<empFundResign> obj = new List<empFundResign>();

            db.dbConnect();

            db.cmd = new System.Data.SqlClient.SqlCommand("SELECT fnr.fnr_id,emp.ep_id, emp.ep_code, ps.ps_name_th+'  '+ps.ps_lastname_th AS fullname, p.post_name, comp.T_Company AS comp, sect.Section_name AS sect, dept.dept_name As dept," +
                              " fn.fund_code, fn.fund_name, fnr.fnr_start_date, fnr.fnr_resign_date," +
                              " fnr.fnr_type_resign," +
                              " fnr.fnr_detail_resign, fnr.fnr_submit_date AS submit" +
                              " FROM tab_emp_fundResign AS fnr" +
                              " INNER JOIN tab_emp_fundRegis AS  fr ON fr.fr_id = fnr.fnr_ref_fundRegis_id" +
                              " INNER JOIN tab_info_fund AS fn ON fn.fund_id = fnr.fnr_ref_fund_id" +
                              " INNER JOIN tab_emp AS emp ON emp.ep_id = fnr.fnr_ref_emp_id" +
                              " INNER JOIN tab_personal AS ps ON ps.ps_id = emp.ep_ref_personal_id" +
                              " INNER JOIN tab_emp_position AS ep ON ep.position_emp_id = fnr.fnr_ref_emp_id" +
                              " INNER JOIN tab_position AS p ON p.post_id = ep.position_posit_id" +
                              " INNER JOIN tab_company AS comp ON comp.comp_id = ep.position_comp_id" +
                              " INNER JOIN tab_section AS sect ON sect.section_id = ep.position_sect_id" +
                              " INNER JOIN tab_department AS dept ON dept.dept_id = ep.position_dept_id" +
                              " WHERE  emp.ep_id = '"+emp+"' AND ep.position_active = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                empFundResign fnr = new empFundResign();

                fnr.fnr_id = db.rdr["fnr_id"].ToString();
                fnr.fnr_start_date = db.rdr["fnr_start_date"].ToString();
                fnr.fnr_resign_date = db.rdr["fnr_resign_date"].ToString();
                fnr.fnr_type_resign = db.rdr["fnr_type_resign"].ToString();
                fnr.fnr_detail_resign = db.rdr["fnr_detail_resign"].ToString();
                fnr.emp_id = db.rdr["ep_id"].ToString();
                fnr.emp_code = db.rdr["ep_code"].ToString();
                fnr.emp_name = db.rdr["fullname"].ToString();
                fnr.emp_position = db.rdr["post_name"].ToString();
                fnr.emp_cpmp = db.rdr["comp"].ToString();
                fnr.emp_sect = db.rdr["sect"].ToString();
                fnr.emp_dept = db.rdr["dept"].ToString();
                fnr.fund_code = db.rdr["fund_code"].ToString();
                fnr.fund_name = db.rdr["fund_name"].ToString();
                fnr.age = (Convert.ToDateTime(fnr.fnr_resign_date) - Convert.ToDateTime(fnr.fnr_start_date)).TotalDays.ToString();
                fnr.fnr_submit_date = db.rdr["submit"].ToString();


                obj.Add(fnr);
            }

            db.dbClosed();

            return obj;
        }

    }
}
