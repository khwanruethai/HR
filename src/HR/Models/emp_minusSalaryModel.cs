using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;


namespace HR.Models
{
    public class emp_minusSalaryModel
    {
        public string ms_id { get; set; }
        public string ms_ref_minus_id { get; set; }
        public string ms_minus_name { get; set; }
        public string ms_amount { get; set; }
        public string ms_ref_emp_id { get; set; }
        public string ms_admin_id { get; set; }
        public string ms_submit_date { get; set; }
        public string ms_check { get; set; }
        public string return_data { get; set; }
        public string ms_start_date { get; set; }
        public string ms_end_date { get; set; }
        public string ms_status { get; set; }
        public string event_status { get; set; }

        public string start { get; set; }
        public string end { get; set; }

        public string max { get; set; }

        databaseClass db = new databaseClass();
        dbFile connect = new dbFile();

        CultureInfo en = new CultureInfo("EN");
        CultureInfo th = new CultureInfo("th-TH");

        public string connectionString() {
            return connect.sqlConnection;
        }
        public string  checkMinus(string emp) {

            using (SqlConnection conn = new SqlConnection(connectionString())) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(ms_ref_emp_id) AS checkMinus FROM tab_emp_minusSalary WHERE ms_ref_emp_id = '"+emp+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    ms_check = rdr["checkMinus"].ToString();

                }

                conn.Close();
            }
            return ms_check;
        }
        public void insertMinusSqlary() {

            CultureInfo en = new CultureInfo("EN");

            string table = "tab_emp_minusSalary";
            string[] Columns = { "ms_ref_minus_id", "ms_amount", "ms_ref_emp_id", "ms_admin_id", "ms_submit_date", "ms_start_date", "ms_end_date", "ms_status" , "event_status"};
            string[] Value = { ms_ref_minus_id, ms_amount, ms_ref_emp_id, "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", en), Convert.ToDateTime(ms_start_date).ToString("yyyy-MM-dd HH:mm:ss", en), Convert.ToDateTime(ms_end_date).ToString("yyyy-MM-dd HH:mm:ss", en), "Y", "S" };
            db.insert_db(table, Columns, Value);

        }
       
        public List<emp_minusSalaryModel> dataMinus(string emp) {

            List<emp_minusSalaryModel> obj = new List<emp_minusSalaryModel>();
            using (SqlConnection conn = new SqlConnection(connectionString())) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_minusSalary INNER JOIN tab_info_minus ON tab_info_minus.minus_id = ms_ref_minus_id WHERE ms_ref_emp_id = '"+emp+"'",conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    emp_minusSalaryModel ms = new emp_minusSalaryModel();
                    ms.ms_id = rdr["ms_id"].ToString();
                    ms.ms_ref_minus_id = rdr["ms_ref_minus_id"].ToString();
                    ms.ms_minus_name = rdr["minus_name"].ToString();
                    ms.ms_amount = rdr["ms_amount"].ToString();
                    ms.ms_ref_emp_id = rdr["ms_ref_emp_id"].ToString();
                    ms.ms_admin_id = rdr["ms_admin_id"].ToString();
                    ms.ms_submit_date = rdr["ms_submit_date"].ToString();
                    ms.event_status = rdr["event_status"].ToString();
                    obj.Add(ms);
                }

                conn.Close();
            }
            
                return obj;
        }
        public string dataForUpdate(string minus) {

            using (SqlConnection conn = new SqlConnection(connectionString())) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_minusSalary WHERE ms_id = '" + minus + "'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    ms_id = rdr["ms_id"].ToString();
                    ms_ref_minus_id = rdr["ms_ref_minus_id"].ToString();
                    ms_amount = rdr["ms_amount"].ToString();
                    ms_ref_emp_id = rdr["ms_ref_emp_id"].ToString();
                    ms_admin_id = rdr["ms_admin_id"].ToString();
                    ms_submit_date = rdr["ms_submit_date"].ToString();
                    ms_start_date = rdr["ms_start_date"].ToString();
                    ms_end_date = rdr["ms_end_date"].ToString();
                    ms_status = rdr["ms_status"].ToString();
                    event_status = rdr["event_status"].ToString();
                    
                }

                conn.Close();
            }


            return_data = ms_id + "^" + ms_ref_minus_id + "^" + ms_amount;

            return return_data;
        }
        public List<emp_minusSalaryModel> emp_minus(string emp)
        {
            dbFile db = new dbFile();
            List<emp_minusSalaryModel> obj = new List<emp_minusSalaryModel>();
            CultureInfo en = new CultureInfo("EN");

            List<string> ls = new List<string>();
            List<string> le = new List<string>();

            try
            {
                using (SqlConnection conn = new SqlConnection(db.sqlConnection))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT ms_start_date, ms_end_date FROM tab_emp_minusSalary WHERE ms_ref_emp_id = '" + emp + "' AND ms_status = 'Y' AND event_status != 'D' GROUP BY ms_start_date , ms_end_date", conn);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {

                        emp_minusSalaryModel pay = new emp_minusSalaryModel();
                        pay.ms_start_date = Convert.ToDateTime(rdr["ms_start_date"]).ToString("dd MMMM yyyy", th);
                        pay.ms_end_date = Convert.ToDateTime(rdr["ms_end_date"]).ToString("dd MMMM yyyy", th);
                        pay.start = Convert.ToDateTime(rdr["ms_start_date"]).ToString("yyyy-MM-dd",en);
                        pay.end = Convert.ToDateTime(rdr["ms_end_date"]).ToString("yyyy-MM-dd",en);
                        obj.Add(pay);

                    }

                }
            }
            catch {

            }

            return obj;

        }
        public string getMinus(string start, string end, string emp)
        {

            CultureInfo en = new CultureInfo("EN");
            string txt = "";
            int i = 1;
            using (SqlConnection conn = new SqlConnection(connect.sqlConnection))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_minusSalary INNER JOIN tab_info_minus ON tab_info_minus.minus_id = ms_ref_minus_id WHERE ms_ref_emp_id = '" + emp + "' AND ms_start_date = '" + start + "' AND ms_end_date = '" +end + "' AND ms_status = 'Y'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    txt += "<tr>" +
                        "<td  class='text-center'>" + i + "</td>" +
                        "<td class='text-center'>" +  rdr["minus_name"] + "</td>" +
                        "<td class='text-right'>" + Convert.ToDouble(rdr["ms_amount"]).ToString("0,0.00") + "</td>"+
                        "<td class='text-center'><a class='btn btn-warning minusEdit' data-toggle='modal' data-target = '#myModalMinusEdit' ref='"+rdr["ms_id"]+"'><i class='fa fa-edit'></i> แก้ไข</a>"+
                        "&nbsp;&nbsp;&nbsp;<a class='btn btn-danger minusDel'  ref='" + rdr["ms_id"] + "'><i class='fa fa-trash-o'></i> ลบ</a>"
                        + "</td><td class='hidden'>"+rdr["ms_ref_minus_id"]+"</td>"
                        + "</tr>";

                    i++;
                }

                conn.Close();
            }


            return txt;
        }
        public void insertMinusSqlaryLOG()
        {

            CultureInfo en = new CultureInfo("EN");

            databaseClassLOG dbl = new databaseClassLOG();

            string table = "tab_emp_minusSalary";
            string[] Columns = { "ms_id","ms_ref_minus_id", "ms_amount", "ms_ref_emp_id", "ms_admin_id", "ms_submit_date", "ms_start_date", "ms_end_date", "ms_status" , "event_status"};
            string[] Value = { ms_id,ms_ref_minus_id, ms_amount, ms_ref_emp_id, ms_admin_id, Convert.ToDateTime(ms_submit_date).ToString("yyyy-MM-dd HH:mm:ss", en), Convert.ToDateTime(ms_start_date).ToString("yyyy-MM-dd HH:mm:ss", en), Convert.ToDateTime(ms_end_date).ToString("yyyy-MM-dd HH:mm:ss", en), ms_status, event_status };
            dbl.insert(table, Columns, Value);

        }
        public void insertMinusSqlary_edit()
        {

            CultureInfo en = new CultureInfo("EN");
            

            string table = "tab_emp_minusSalary";
            string[] Columns = {  "ms_ref_minus_id", "ms_amount", "ms_ref_emp_id", "ms_admin_id", "ms_submit_date", "ms_start_date", "ms_end_date", "ms_status" , "event_status"};
            string[] Value = { ms_ref_minus_id, ms_amount, ms_ref_emp_id, ms_admin_id, Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss", en), Convert.ToDateTime(ms_start_date).ToString("yyyy-MM-dd HH:mm:ss", en), Convert.ToDateTime(ms_end_date).ToString("yyyy-MM-dd HH:mm:ss", en), ms_status , event_status};
            string where = "ms_id = '"+ms_id+"'";

            db.update(table, Columns, Value, where);

        }
        public List<string> check_id_minus_emp_select(string emp, string start_dt, string end_dt)
        {

            List<string> minus = new List<string>();

            using (SqlConnection conn = new SqlConnection(connect.sqlConnection))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT m.ms_ref_minus_id  AS minus FROM tab_emp_minusSalary as m" +
                                                 "   WHERE m.ms_ref_emp_id = '" + emp + "' AND m.ms_start_date = '" + start_dt + "' AND m.ms_end_date = '" + end_dt + "'", conn);

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    minus.Add(rdr["minus"].ToString());

                }

                conn.Close();
            }

           
            return minus;
        }
        public void Daymax_minus(string emp)
        {

            using (SqlConnection conn = new SqlConnection(connect.sqlConnection))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT MAX(ms_end_date) AS ms FROM tab_emp_minusSalary WHERE ms_status = 'Y' AND ms_ref_emp_id = '" + emp + "'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    if (string.IsNullOrEmpty(rdr["ms"].ToString()) == true)
                    {

                        max = "N";
                    }
                    else
                    {

                        max = Convert.ToDateTime(rdr["ms"]).ToString("yyyy/MM/dd", en);
                    }

                }
                conn.Close();
            }
            
        }
        public List<string> cancel_minus(string emp, string start, string end)
        {

            List<string> mid = new List<string>();

            string st = start;
            string en_ = end;

            using (SqlConnection conn = new SqlConnection(connect.sqlConnection))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_minusSalary AS ms " +
                                                " WHERE ms.ms_ref_emp_id = '" + emp + "' AND ms.ms_start_date = '" + st + "' AND ms.ms_end_date = '" + en_ + "'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    mid.Add(rdr["ms_id"].ToString());

                }

                conn.Close();
            }

            ///
            return mid;
        }
    }
}
