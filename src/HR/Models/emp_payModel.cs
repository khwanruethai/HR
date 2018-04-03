using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class emp_payModel
    {
        public string pay_id { get; set; }
        public string pay_ref_income_id { get; set; }
        public string pay_income_name { get; set; }
        public string pay_amount { get; set; }
        public string pay_ref_emp_id { get; set; }
        public string pay_admin_id { get; set; }
        public string pay_submit_date { get; set; }
        public string check_pay { get; set; }
        public string returnPay { get; set; }
        public string pay_start_date { get; set; }
        public string pay_end_date { get; set; }
        public string pay_status { get; set; }
        public string event_status { get; set; }

        public string start { get; set; }
        public string end { get; set; }
        public string max { get; set; }
        

        public List<string> p_id { get; set; }

        databaseClass db = new databaseClass();
        dbFile connect = new dbFile();
        CultureInfo EN = new CultureInfo("EN");
        CultureInfo th = new CultureInfo("th-TH");

        public string connectionString() {

            return connect.sqlConnection;
        }
        public string checkPay(string emp) {

            using (SqlConnection conn = new SqlConnection(connectionString())) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(pay_ref_emp_id) AS check_pay FROM tab_emp_pay WHERE pay_ref_emp_id = '"+emp+"'",conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    check_pay = rdr["check_pay"].ToString();

                }

                conn.Close();
            }

            return check_pay;
        }
        public void insert_pay() {

            string table = "tab_emp_pay";
            string[] Columns = { "pay_ref_income_id", "pay_amount", "pay_ref_emp_id", "pay_admin_id", "pay_submit_date","pay_start_date","pay_end_date","pay_status", "event_status" };
            string[] Value = {pay_ref_income_id, pay_amount, pay_ref_emp_id, "1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", EN), Convert.ToDateTime(pay_start_date).ToString("yyyy-MM-dd HH:mm:ss", EN), Convert.ToDateTime(pay_end_date).ToString("yyyy-MM-dd HH:mm:ss",EN), "Y", "S" };
            db.insert_db(table, Columns, Value);

        }
        
        public List<emp_payModel> select_pay(string emp) {

            List<emp_payModel> obj = new List<emp_payModel>();
            using (SqlConnection conn = new SqlConnection(connectionString())) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_pay INNER JOIN tab_info_income ON tab_info_income.income_id = pay_ref_income_id WHERE pay_ref_emp_id = '" + emp+"'",conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    emp_payModel pay = new emp_payModel();
                    pay.pay_id = rdr["pay_id"].ToString();
                    pay.pay_ref_income_id = rdr["pay_ref_income_id"].ToString();
                    pay.pay_income_name = rdr["income_name"].ToString();
                    pay.pay_amount = rdr["pay_amount"].ToString();
                    pay.pay_ref_emp_id = rdr["pay_ref_emp_id"].ToString();
                    pay.pay_admin_id = rdr["pay_admin_id"].ToString();
                    pay.pay_submit_date = rdr["pay_submit_date"].ToString();
                    obj.Add(pay);

                }
                conn.Close();
            }

           return obj;
        }
        public string dataForUpdate(string pay) {

            using (SqlConnection conn = new SqlConnection(connectionString())) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_pay WHERE pay_id = '"+pay+"'",conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    pay_id = rdr["pay_id"].ToString();
                    pay_ref_income_id = rdr["pay_ref_income_id"].ToString();
                    pay_amount = rdr["pay_amount"].ToString();
                    pay_ref_emp_id = rdr["pay_ref_emp_id"].ToString();
                    pay_admin_id = rdr["pay_admin_id"].ToString();
                    pay_submit_date = rdr["pay_submit_date"].ToString();
                    pay_start_date = rdr["pay_start_date"].ToString();
                    pay_end_date = rdr["pay_end_date"].ToString();
                    pay_status = rdr["pay_status"].ToString();
                    event_status = rdr["event_status"].ToString();
                }
                conn.Close();
            }


            returnPay = pay_id + "^" + pay_ref_income_id + "^" + pay_amount;

            return returnPay;
        }
       
        public List<emp_payModel> emp_pay(string emp) {

           List<emp_payModel> obj = new List<emp_payModel>();

            List<string> ls = new List<string>();
            List<string> le = new List<string>();

            string dt = DateTime.Now.ToString("yyyy-MM",EN);

            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT pay_start_date, pay_end_date FROM tab_emp_pay WHERE pay_ref_emp_id = '"+emp+ "' AND pay_status = 'Y'  AND pay_start_date >= '"+dt+"-01'    GROUP BY pay_start_date , pay_end_date", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    emp_payModel pay = new emp_payModel();
                    pay.pay_start_date =  Convert.ToDateTime(rdr["pay_start_date"]).ToString("dd MMMM yyyy");
                    pay.pay_end_date = Convert.ToDateTime(rdr["pay_end_date"]).ToString("dd MMMM yyyy");
                    pay.start = Convert.ToDateTime(rdr["pay_start_date"]).ToString("yyyy-MM-dd", EN); ;
                    pay.end = Convert.ToDateTime(rdr["pay_end_date"]).ToString("yyyy-MM-dd",EN);

                    obj.Add(pay);

                }


            }

            
            return obj;

        }
        public void Daymax_pay(string emp) {

            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT MAX(pay_start_date) AS mp FROM tab_emp_pay WHERE pay_status = 'Y' AND pay_ref_emp_id = '"+emp+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    if (string.IsNullOrEmpty(rdr["mp"].ToString()) == true)
                    {

                        max = "N";
                    }
                    else {

                        max = Convert.ToDateTime(rdr["mp"]).ToString("yyyy/MM/dd",EN);
                    }

                }
                conn.Close();
            }
            

        }
        public string getPay(string start, string end, string emp) {

            CultureInfo en = new CultureInfo("EN");
            string txt = "";
            int i = 1;
            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp_pay INNER JOIN tab_info_income ON tab_info_income.income_id = pay_ref_income_id WHERE pay_ref_emp_id = '" + emp + "' AND pay_start_date = '" + start+ "' AND pay_end_date = '" +end+ "'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    txt += "<tr>"+
                        "<td class='text-center'>"+i+"</td>"+
                        "<td class='text-center'>"+rdr["income_name"] +"</td>"+
                        "<td class='text-right'>" + Convert.ToDouble(rdr["pay_amount"]).ToString("0,0.00") + "</td>"+
                        "<td class='text-center'><a class='btn btn-warning payEdit' ref='"+rdr["pay_id"]+ "' data-toggle='modal' data-target='#myModalPayEdit'><i class='fa fa-edit'></i> แก้ไข</a>&nbsp;&nbsp;" +
                        "<a class='btn btn-danger payDel'  ref='" + rdr["pay_id"] + "'><i class='fa fa-trash-o'></i> ลบ</a>" + "</td><td class='ic_id hidden'>"+rdr["pay_ref_income_id"]+"</td>"
                        + "</tr>";

                    i++;
                }

                conn.Close();
            }


                return txt;
        }
        public void insert_payLOG()
        {
            databaseClassLOG dbl = new databaseClassLOG();

            string table = "tab_emp_pay";
            string[] Columns = { "pay_id","pay_ref_income_id", "pay_amount", "pay_ref_emp_id", "pay_admin_id", "pay_submit_date", "pay_start_date", "pay_end_date", "pay_status" , "event_status"};
            string[] Value = { pay_id,pay_ref_income_id, pay_amount, pay_ref_emp_id, pay_admin_id, Convert.ToDateTime(pay_submit_date).ToString("yyyy-MM-dd HH:mm:ss", EN), Convert.ToDateTime(pay_start_date).ToString("yyyy-MM-dd HH:mm:ss", EN), Convert.ToDateTime(pay_end_date).ToString("yyyy-MM-dd HH:mm:ss", EN),pay_status, event_status };
            dbl.insert(table, Columns, Value);

        }
        public void update_pay() {


            string table = "tab_emp_pay";
            string[] Columns = { "pay_ref_income_id", "pay_amount", "pay_ref_emp_id", "pay_admin_id", "pay_submit_date", "pay_start_date", "pay_end_date", "pay_status" , "event_status" };
            string[] Value = {  pay_ref_income_id, pay_amount, pay_ref_emp_id, pay_admin_id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", EN), Convert.ToDateTime(pay_start_date).ToString("yyyy-MM-dd HH:mm:ss", EN), Convert.ToDateTime(pay_end_date).ToString("yyyy-MM-dd HH:mm:ss", EN), pay_status , event_status };
            string where = "pay_id = '"+pay_id+"'";

            db.update(table, Columns, Value, where);
            
        }
        
        public List<string> cancel_pay(string emp, string start, string end) {

          List<string> pid = new List<string>();

            string st = start;
            string en_ = end;

            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT pay_id FROM tab_emp_pay pay "+
                               " INNER JOIN tab_info_income ic ON ic.income_id = pay.pay_ref_income_id"+
                               " WHERE pay.pay_ref_emp_id = '"+emp+"' AND ic.chk_fix = 'Y' AND pay.pay_status = 'Y' AND pay.pay_start_date = '"+start+"' AND pay.pay_end_date = '3000-01-01'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    pid.Add(rdr["pay_id"].ToString());

                }
                
                conn.Close();
            }
            
            return pid;
        }
        public List<string> check_id_pay_emp_select(string emp, string start_dt, string end_dt) {

            List<string> income = new List<string>();

            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {

                conn.Open();
                
                SqlCommand cmd = new SqlCommand("SELECT p.pay_ref_income_id  AS income, pay_start_date, pay_end_date  FROM tab_emp_pay as p" +
                                                 "   WHERE p.pay_ref_emp_id = '" + emp + "' AND p.pay_start_date = '" + start_dt + "' AND p.pay_end_date = '" + end_dt + "'", conn);

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                   
                    income.Add(rdr["income"].ToString());

                }
                
                conn.Close();
            }

            start = Convert.ToDateTime(start).ToString("dd/MM/yyyy",th);
            end = Convert.ToDateTime(end).ToString("dd/MM/yyyy", th);

            return income;
        }
    }
}
