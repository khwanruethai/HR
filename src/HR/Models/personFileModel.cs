using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class personFileModel
    {
        public string ch_file_id { get; set; }
        public string   ch_file_name { get; set; }
        public string   ch_file_ref_person_id { get; set; }
        public string   ch_file_create_date { get; set; }
        public string   ch_file_ref_admin_id { get; set; }
        public string   event_status { get; set; }
        public string ch_ref_change_name_id { get; set; }

        dbFile db = new dbFile();
        CultureInfo en = new CultureInfo("EN");

        public void insert_file() {

            databaseClass dbc = new databaseClass();

            string table = "tab_person_file";
            string[] Columns = { "ch_file_name", "ch_file_ref_person_id", "ch_file_create_date", "ch_file_ref_admin_id", "event_status", "ch_ref_change_name_id" };
            string[] Value = { ch_file_name , ch_file_ref_person_id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "1", "S", ch_ref_change_name_id };

            dbc.insert(table, Columns, Value);

        }
       
    }
}
