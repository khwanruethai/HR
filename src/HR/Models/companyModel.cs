using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class companyModel
    {
        public string comp_id { get; set; }
        public string code_comp { get; set; }
        public string T_Company { get; set; }
        public string E_Company { get; set; }
        public string Address { get; set; }
        public string addr_no { get; set; }
        public string addr_moo { get; set; }
        public string addr_lane { get; set; }
        public string addr_road { get; set; }
        public string addr_district { get; set; }
        public string addr_amphur { get; set; }
        public string addr_province { get; set; }
        public string Tel { get; set; }
        public string Code_Bank { get; set; }
        public string No_Bank { get; set; }
        public string No_Tax { get; set; }
        public string No_Social { get; set; }
        public string Name_Board { get; set; }
        public string Post_Board { get; set; }

        databaseClass db = new databaseClass();
        dbFile connect = new dbFile();
        public List<SelectListItem> drop_company() {

            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_company", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    items.Add(new SelectListItem { Text = rdr["T_Company"].ToString(), Value = rdr["comp_id"].ToString() });

                }

                items.Insert(0,new SelectListItem { Text="เลือกบริษัท", Value="0"});

                conn.Close();
            }

           return items;
        }
        public string compList() {


            string txt = "";

            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_company", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {


                    txt += "<option>"+rdr["T_Company"] +"</option>";

                }


                conn.Close();

            }


                return txt;
        }
        public List<companyModel> list_comp() {

            List<companyModel> obj = new List<companyModel>();

            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_company", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    companyModel cp = new companyModel();
                    cp.T_Company = rdr["T_company"].ToString();
                    cp.Address = rdr["Address"].ToString();
                    cp.addr_no = rdr["addr_no"].ToString();
                    cp.addr_moo = rdr["addr_no"].ToString();
                    cp.addr_lane = rdr["addr_lane"].ToString();
                    cp.addr_road = rdr["addr_road"].ToString();
                    cp.addr_district = rdr["addr_district"].ToString();
                    cp.addr_amphur = rdr["addr_amphur"].ToString();
                    cp.addr_province = rdr["addr_province"].ToString();
                    cp.Tel = rdr["Tel"].ToString();

                    obj.Add(cp);
                }


                conn.Close();
            }


                return obj;

        }
    }
}
