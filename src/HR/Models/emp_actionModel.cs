using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class emp_actionModel
    {
        public string emp_id { get; set; }
        public string emp_code { get; set; }
        public string emp_prefix_th { get; set; }
        public string emp_name_th { get; set; }
        public string emp_lastname_th { get; set; }
        public string emp_national_id { get; set; }
        public string emp_full_name { get; set; }
        public string emp_type_name { get; set; }
        public string emp_start_date { get; set; }
        public string emp_end_date { get; set; }
        public string emp_salary { get; set; }
        public string emp_stipend { get; set; }
        public string emp_action_start { get; set; }
        public string emp_action_end { get; set; }
        
        CultureInfo th = new CultureInfo("TH");
        CultureInfo en = new CultureInfo("EN");

        public void insert_emp_action() {

            databaseClass data = new databaseClass();
            
            string table = "tab_emp_action";
            string[] Columns = { "emp_code", "emp_prefix_th", "emp_name_th", "emp_lastname_th", "emp_national_id", "emp_full_name", "emp_type_name", "emp_start_date", "emp_end_date", "emp_salary", "emp_stipend", "emp_action_start", "emp_action_end" , "event_status"};
            string[] Value = { emp_code, emp_prefix_th, emp_name_th, emp_lastname_th, emp_national_id, emp_full_name, emp_type_name, DateTime.Now.ToString("yyyy-MM-dd", en), Convert.ToDateTime(emp_end_date).ToString("yyyy-MM-dd", en), emp_salary, emp_stipend, Convert.ToDateTime(emp_action_start).ToString("yyyy-MM-dd",en), Convert.ToDateTime(emp_action_end).ToString("yyyy-MM-dd",en), "S" };

            data.insert(table, Columns, Value);
            
        }
        public void update_salary() {

            databaseClass db = new databaseClass();

            string table = "tab_emp_action";
            string[] Columns = { "emp_salary" };
            string[] Value = { emp_salary };
            string where = "emp_code = '"+emp_code+"'";
            
            db.update(table, Columns, Value, where);
        }
        public void update_stipend()
        {
            databaseClass db = new databaseClass();

            string table = "tab_emp_action";
            string[] Columns = { "emp_stipend" };
            string[] Value = { emp_stipend };
            string where = "emp_code = '" + emp_code + "'";

            db.update(table, Columns, Value, where);
        }
    }
}
