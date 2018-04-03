using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Models;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace HR.Models
{
    public class info_prefixModels
    {
        public string prefix_id { get; set; }
        public string name_th { get; set; }
        public string name_en { get; set; }
        public string submit_date { get; set; }
        public string  admin_id { get; set; }
        public string where { get; set; }
        public string result { get; set; }
        public string event_status { get; set; }

        databaseClass db = new databaseClass();
        dbFile connect = new dbFile();
        CultureInfo en = new CultureInfo("EN");
        public List<info_prefixModels> select_prefix()
        {
            List<info_prefixModels> objSt = new List<info_prefixModels>();
            dbFile db = new dbFile();
            using (SqlConnection conn = new SqlConnection(db.sqlConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_info_prefix WHERE event_status != 'D'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    info_prefixModels pf = new info_prefixModels();

                    pf.name_th = rdr["prefix_name_th"].ToString();
                    pf.name_en = rdr["prefix_name_en"].ToString();
                    pf.prefix_id = rdr["prefix_id"].ToString();

                    objSt.Add(pf);

                }
                conn.Close();
            }

            return objSt;
        }
        public void insert_prefix() {

            string table = "tab_info_prefix";
            string[] Columns = { "prefix_name_th", "prefix_name_en", "prefix_submit_date", "prefix_admin_id" , "event_status"};
            string [] Value = {name_th, name_en,DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss",en), "1", "S" };
            db.insert(table, Columns, Value);

        }
        public void update_prefix() {

            //using (SqlConnection conn = new SqlConnection(connect.sqlConnection))
            //{
            //    conn.Open();
                 string table = "tab_info_prefix";
                 string[] Columns = { "prefix_name_th", "prefix_name_en", "prefix_submit_date", "prefix_admin_id", "event_status" };
                 string[] Value = { name_th, name_en, Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss",en), "1", event_status };
                 string where = "prefix_id = '"+prefix_id+"'";
                db.update(table, Columns, Value, where);
            //}
        }
        public List<SelectListItem> select_prefixTH() {

            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT prefix_id, prefix_name_th FROM tab_info_prefix WHERE event_status != 'D'",conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    items.Add(new SelectListItem { Text=rdr["prefix_name_th"].ToString(), Value = rdr["prefix_id"].ToString()});

                }
                conn.Close();
            }

                return items;
        }
        public List<SelectListItem> select_prefixEN()
        {

            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(connect.sqlConnection))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT prefix_id, prefix_name_en FROM tab_info_prefix WHERE event_status != 'D'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    items.Add(new SelectListItem { Text = rdr["prefix_name_en"].ToString(), Value = rdr["prefix_id"].ToString() });

                }
                conn.Close();
            }

            return items;
        }
         public List<SelectListItem> select_prefixTH_for_edit(string prefix) {

            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT prefix_id, prefix_name_th FROM tab_info_prefix WHERE event_status != 'D'",conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {


                    if (rdr["prefix_id"].ToString() == prefix)
                    {
                        items.Insert(0, new SelectListItem { Text = rdr["prefix_name_th"].ToString(), Value = rdr["prefix_id"].ToString() });
                    }
                    else
                    {
                        items.Add(new SelectListItem { Text = rdr["prefix_name_th"].ToString(), Value = rdr["prefix_id"].ToString() });
                    }

                }
                conn.Close();
            }

                return items;
        }
        public List<SelectListItem> select_prefixEN_for_edit(string prefix)
        {

            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(connect.sqlConnection))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT prefix_id, prefix_name_en FROM tab_info_prefix WHERE event_status != 'D'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {


                    if (rdr["prefix_id"].ToString() == prefix)
                    {
                        items.Insert(0, new SelectListItem { Text = rdr["prefix_name_en"].ToString(), Value = rdr["prefix_id"].ToString() });
                    }
                    else
                    {
                        items.Add(new SelectListItem { Text = rdr["prefix_name_en"].ToString(), Value = rdr["prefix_id"].ToString() });
                    }

                }
                conn.Close();
            }

            return items;
        }
        public void selectPerfixbyId(string prefix) {

            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_info_prefix WHERE prefix_id= '"+prefix+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    prefix_id = rdr["prefix_id"].ToString();
                    name_th = rdr["prefix_name_th"].ToString();
                    name_en = rdr["prefix_name_en"].ToString();
                    submit_date = rdr["prefix_submit_date"].ToString();
                    admin_id = rdr["prefix_admin_id"].ToString();
                    event_status = rdr["event_status"].ToString();

                }

                conn.Close();

            }

        }
        public void insertPrefixLOG() {

            databaseClassLOG dbl = new databaseClassLOG();

            string table = "tab_info_prefix";
            string[] Columns = { "prefix_id","prefix_name_th", "prefix_name_en", "prefix_submit_date", "prefix_admin_id" , "event_status"};
            string[] Value = { prefix_id,name_th, name_en, Convert.ToDateTime(submit_date).ToString("yyyy/MM/dd HH:mm:ss",en), admin_id , event_status};

            dbl.insert(table, Columns, Value);
            
        }
      
    }
}
