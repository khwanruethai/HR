using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class AddressModel
    {
        public string address_id { get; set; }
        public string address_num { get; set; }
        public string address_moo { get; set; }
        public string address_type { get; set; }
        public string address_type_name { get; set; }
        public string address_name { get; set; }
        public string address_alley { get; set; }
        public string address_road { get; set; }
        public string address_district_id { get; set; }
        public string address_district_name { get; set; }
        public string address_amphur_id { get; set; }
        public string address_amphur_name { get; set; }
        public string address_province_id { get; set; }
        public string address_province_name { get; set; }
        public string address_postcode { get; set; }
        //
        public string address_id_call { get; set; }
        public string address_num_call { get; set; }
        public string address_moo_call { get; set; }
        public string address_type_call { get; set; }
        public string address_type_name_call { get; set; }
        public string address_name_call { get; set; }
        public string address_alley_call { get; set; }
        public string address_road_call { get; set; }
        public string address_district_id_call { get; set; }
        public string address_district_name_call { get; set; }
        public string address_amphur_id_call { get; set; }
        public string address_amphur_name_call { get; set; }
        public string address_province_id_call { get; set; }
        public string address_province_name_call { get; set; }
        public string address_postcode_call { get; set; }
        //
        public string address_ref_emp_id { get; set; }
        public string address_ref_admin_id { get; set; }
        public string address_submit_date { get; set; }
        public string check_address { get; set; }

        databaseClass db = new databaseClass();
        dbFile connect = new dbFile();

        public string connectionString() {

            return connect.sqlConnection;
        }
        public string checkAddress(string emp) {

            using (SqlConnection conn = new SqlConnection(connectionString())) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(address_ref_emp_id) AS numAddress FROM tab_emp_address WHERE address_ref_emp_id = '"+emp+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    check_address = rdr["numAddress"].ToString();

                }

                conn.Close();
            }

          return check_address;
        }
        public string data_address(string emp) {

            using (SqlConnection conn = new SqlConnection(connectionString())) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT address_id, address_num, address_moo, address_type, address_name, address_alley,address_road, address_amphur_id, a1.amphur_name AS amphur, address_district_id, d1.district_name AS district, address_province_id, p1.province_name AS province, address_postcode, "+
                                                " address_num_call, address_moo_call, address_type_call, address_name_call, address_alley_call,address_road_call, address_amphur_id_call, a2.amphur_name AS amphur_name, address_district_id_call, d2.district_name AS district_name, address_province_id_call, p2.province_name AS province_name, address_postcode_call," +
                                                " address_ref_emp_id, address_ref_admin_id, address_submit_date"+
                                                " FROM tab_emp_address"+
                                                " INNER JOIN tab_emp ON tab_emp.ep_ref_personal_id = tab_emp_address.address_ref_emp_id" +
                                                " INNER JOIN tab_province p1 ON p1.province_id = address_province_id"+
                                                " INNER JOIN tab_province p2 ON p2.province_id = address_province_id_call"+
                                                " INNER JOIN tab_amphur a1 ON a1.amphur_id = address_amphur_id"+
                                                " INNER JOIN tab_amphur a2 ON a2.amphur_id = address_amphur_id_call"+
                                                " INNER JOIN tab_district d1 ON d1.district_id = address_district_id"+
                                                " INNER JOIN tab_district d2 ON d2.district_id = address_district_id_call"+
                                                " WHERE tab_emp.ep_id = '" + emp+"'",conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    address_id = rdr["address_id"].ToString();
                    address_num = rdr["address_num"].ToString();
                    address_moo = rdr["address_moo"].ToString();
                    address_type = rdr["address_type"].ToString();

                    if (address_type == "home") {

                        address_type_name = "บ้าน";
                    }
                    else if (address_type == "dorm")
                    {
                        address_type_name = "หอพัก";
                    }
                    else if (address_type == "apartment")
                    {
                        address_type_name = "อพาร์ทเม้น";
                    }
                    else if (address_type == "etc")
                    {
                        address_type_name = "อื่นๆ";
                    }
                    address_name = rdr["address_name"].ToString();
                    address_alley = rdr["address_alley"].ToString();
                    address_road = rdr["address_road"].ToString();
                    address_district_id = rdr["address_district_id"].ToString();
                    address_district_name = rdr["district"].ToString();
                    address_amphur_id  = rdr["address_amphur_id"].ToString();
                    address_amphur_name  = rdr["amphur"].ToString();
                    address_province_id = rdr["address_province_id"].ToString();
                    address_province_name = rdr["province"].ToString();
                    address_postcode = rdr["address_postcode"].ToString();

                    address_num_call = rdr["address_num_call"].ToString();
                    address_moo_call = rdr["address_moo_call"].ToString();
                    address_type_call = rdr["address_type_call"].ToString();
                    if (address_type_call == "home")
                    {
                        address_type_name_call = "บ้าน";
                    }
                    else if (address_type_call == "dorm")
                    {
                        address_type_name_call = "หอพัก";
                    }
                    else if (address_type_call == "apartment")
                    {
                        address_type_name_call = "อพาร์ทเม้น";
                    }
                    else if (address_type_call == "etc")
                    {
                        address_type_name_call = "อื่นๆ";
                    }

                    address_name_call = rdr["address_name_call"].ToString();
                    address_alley_call = rdr["address_alley_call"].ToString();
                    address_road_call = rdr["address_road_call"].ToString();
                    address_district_id_call = rdr["address_district_id_call"].ToString();
                    address_district_name_call = rdr["district_name"].ToString();
                    address_amphur_id_call = rdr["address_amphur_id_call"].ToString();
                    address_amphur_name_call = rdr["amphur_name"].ToString();
                    address_province_id_call = rdr["address_province_id_call"].ToString();
                    address_province_name_call = rdr["province_name"].ToString();
                    address_postcode_call = rdr["address_postcode_call"].ToString();

                    address_ref_emp_id = rdr["address_ref_emp_id"].ToString();
                    address_ref_admin_id = rdr["address_ref_admin_id"].ToString();
                    address_submit_date  = rdr["address_submit_date"].ToString();

                }
                
                conn.Close();
            }

            string aa = address_num+"^" + address_moo + "^" + address_type + "^" + address_name + "^" + address_alley + "^" + address_road + "^" + address_district_id + "^" + address_amphur_id + "^" + address_province_id + "^" + address_postcode + "^" + address_num_call + "^" + address_moo_call + "^" + address_type_call + "^" + address_name_call + "^" + address_alley_call + "^" + address_road_call + "^" + address_district_id_call + "^" + address_amphur_id_call + "^" + address_province_id_call + "^" + address_postcode_call;

          return aa;

        }
        public void insertAddress() {

            string table = "tab_emp_address";
            string[] Columns = {
                "address_num",
                "address_moo",
                "address_type",
                "address_name",
                "address_alley",
                "address_road",
                "address_district_id",
                "address_amphur_id",
                "address_province_id",
                "address_postcode",
                "address_num_call",
                "address_moo_call",
                "address_type_call",
                "address_name_call",
                "address_alley_call",
                 "address_road_call",
                "address_district_id_call",
                "address_amphur_id_call",
                "address_province_id_call",
                "address_postcode_call",
                "address_ref_emp_id",
                "address_ref_admin_id",
                "address_submit_date"
            };
            string[] Value = {
                address_num,
                address_moo,
                address_type,
                address_name,
                address_alley,
                address_road,
                address_district_id,
                address_amphur_id,
                address_province_id,
                address_postcode,
                address_num_call,
                address_moo_call,
                address_type_call,
                address_name_call,
                address_alley_call,
                address_road_call,
                address_district_id_call,
                address_amphur_id_call,
                address_province_id_call,
                address_postcode_call,
                address_ref_emp_id,
                "1",
                DateTime.Now.ToString("yyyy-MM-dd")
            };
            db.insert(table, Columns, Value);
            
        }
        public void selectAddressPerson(string ps) {

            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT address_id, address_num, address_moo, address_type, address_name, address_alley,address_road, address_amphur_id, a1.amphur_name AS amphur, address_district_id, d1.district_name AS district, address_province_id, p1.province_name AS province, address_postcode, " +
                                                " address_num_call, address_moo_call, address_type_call, address_name_call, address_alley_call,address_road_call, address_amphur_id_call, a2.amphur_name AS amphur_name, address_district_id_call, d2.district_name AS district_name, address_province_id_call, p2.province_name AS province_name, address_postcode_call," +
                                                " address_ref_emp_id, address_ref_admin_id, address_submit_date" +
                                                " FROM tab_emp_address"
                                               +" INNER JOIN tab_province p1 ON p1.province_id = address_province_id"+
                                                " INNER JOIN tab_province p2 ON p2.province_id = address_province_id_call" +
                                                " INNER JOIN tab_amphur a1 ON a1.amphur_id = address_amphur_id" +
                                                " INNER JOIN tab_amphur a2 ON a2.amphur_id = address_amphur_id_call" +
                                                " INNER JOIN tab_district d1 ON d1.district_id = address_district_id" +
                                                " INNER JOIN tab_district d2 ON d2.district_id = address_district_id_call" +
                                                " WHERE address_ref_emp_id = '"+ps+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {



                    address_id = rdr["address_id"].ToString();
                    address_num = rdr["address_num"].ToString();
                    address_moo = rdr["address_moo"].ToString();
                    address_type = rdr["address_type"].ToString();

                    if (address_type == "home")
                    {

                        address_type_name = "บ้าน";
                    }
                    else if (address_type == "dorm")
                    {
                        address_type_name = "หอพัก";
                    }
                    else if (address_type == "apartment")
                    {
                        address_type_name = "อพาร์ทเม้น";
                    }
                    else if (address_type == "etc")
                    {
                        address_type_name = "อื่นๆ";
                    }
                    address_name = rdr["address_name"].ToString();
                    address_alley = rdr["address_alley"].ToString();
                    address_road = rdr["address_road"].ToString();
                    address_district_id = rdr["address_district_id"].ToString();
                    address_district_name = rdr["district"].ToString();
                    address_amphur_id = rdr["address_amphur_id"].ToString();
                    address_amphur_name = rdr["amphur"].ToString();
                    address_province_id = rdr["address_province_id"].ToString();
                    address_province_name = rdr["province"].ToString();
                    address_postcode = rdr["address_postcode"].ToString();
                    address_num_call = rdr["address_num_call"].ToString();
                    address_moo_call = rdr["address_moo_call"].ToString();
                    address_type_call = rdr["address_type_call"].ToString();

                    if (address_type_call == "home")
                    {
                        address_type_name_call = "บ้าน";
                    }
                    else if (address_type_call == "dorm")
                    {
                        address_type_name_call = "หอพัก";
                    }
                    else if (address_type_call == "apartment")
                    {
                        address_type_name_call = "อพาร์ทเม้น";
                    }
                    else if (address_type_call == "etc")
                    {
                        address_type_name_call = "อื่นๆ";
                    }

                    address_name_call = rdr["address_name_call"].ToString();
                    address_alley_call = rdr["address_alley_call"].ToString();
                    address_road_call = rdr["address_road_call"].ToString();
                    address_district_id_call = rdr["address_district_id_call"].ToString();
                    address_district_name_call = rdr["district_name"].ToString();
                    address_amphur_id_call = rdr["address_amphur_id_call"].ToString();
                    address_amphur_name_call = rdr["amphur_name"].ToString();
                    address_province_id_call = rdr["address_province_id_call"].ToString();
                    address_province_name_call = rdr["province_name"].ToString();
                    address_postcode_call = rdr["address_postcode_call"].ToString();

                    address_ref_emp_id = rdr["address_ref_emp_id"].ToString();
                    address_ref_admin_id = rdr["address_ref_admin_id"].ToString();
                    address_submit_date = rdr["address_submit_date"].ToString();


                }
                
                conn.Close();
            }

        }
        public void updateAddress() {

            databaseClass dbc = new databaseClass();
            string table = "tab_emp_address";
            string[] Columns = {
                "address_num",
                "address_moo",
                "address_type",
                "address_name",
                "address_alley",
                "address_road",
                "address_district_id",
                "address_amphur_id",
                "address_province_id",
                "address_postcode",
                "address_num_call",
                "address_moo_call",
                "address_type_call",
                "address_name_call",
                "address_alley_call",
                "address_road_call",
                "address_district_id_call",
                "address_amphur_id_call",
                "address_province_id_call",
                "address_postcode_call",
                "address_ref_admin_id",
                "address_submit_date"
            };
            string[] Value = {
                address_num,
                address_moo,
                address_type,
                address_name,
                address_alley,
                address_road,
                address_district_id,
                address_amphur_id,
                address_province_id,
                address_postcode,
                address_num_call,
                address_moo_call,
                address_type_call,
                address_name_call,
                address_alley_call,
                address_road_call,
                address_district_id_call,
                address_amphur_id_call,
                address_province_id_call,
                address_postcode_call,
                "1",
                DateTime.Now.ToString("yyyy-MM-dd")
            };
            string where = "address_ref_emp_id = '"+address_ref_emp_id+ "'";
            dbc.update(table, Columns, Value, where);
            
        }
        public void insertAddressLOG()
        {

            databaseClassLOG dbl = new databaseClassLOG();
            string table = "tab_emp_address";
            string[] Columns = {
                "address_id",
                "address_num",
                "address_moo",
                "address_type",
                "address_name",
                "address_alley",
                "address_road",
                "address_district_id",
                "address_amphur_id",
                "address_province_id",
                "address_postcode",
                "address_num_call",
                "address_moo_call",
                "address_type_call",
                "address_name_call",
                "address_alley_call",
                 "address_road_call",
                "address_district_id_call",
                "address_amphur_id_call",
                "address_province_id_call",
                "address_postcode_call",
                "address_ref_emp_id",
                "address_ref_admin_id",
                "address_submit_date"
            };
            string[] Value = {
                address_id,
                address_num,
                address_moo,
                address_type,
                address_name,
                address_alley,
                address_road,
                address_district_id,
                address_amphur_id,
                address_province_id,
                address_postcode,
                address_num_call,
                address_moo_call,
                address_type_call,
                address_name_call,
                address_alley_call,
                address_road_call,
                address_district_id_call,
                address_amphur_id_call,
                address_province_id_call,
                address_postcode_call,
                address_ref_emp_id,
                "1",
                DateTime.Now.ToString("yyyy-MM-dd")
            };
            dbl.insert(table, Columns, Value);

        }

    }
}
