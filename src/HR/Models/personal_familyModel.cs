using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class personal_familyModel
    {
        public string fam_id { get; set; }

        public string fam_name_dad { get; set; }
        public string fam_lastname_dad { get; set; }
        public string fam_age_dad { get; set; }
        public string fam_num_dad { get; set; }
        public string fam_moo_dad { get; set; }
        public string fam_province_dad { get; set; }
        public string fam_amphur_dad { get; set; }
        public string fam_district_dad { get; set; }
        public string fam_postcode_dad { get; set; }
        public string fam_tel_dad { get; set; }
        public string fam_mobile_dad { get; set; }
        public string district_name_dad { get; set; }
        public string amphur_name_dad { get; set; }
        public string province_name_dad { get; set; }
        //
        public string fam_name_mom { get; set; }
        public string fam_lastname_mom { get; set; }
        public string fam_age_mom { get; set; }
        public string fam_num_mom { get; set; }
        public string fam_moo_mom { get; set; }
        public string fam_province_mom { get; set; }
        public string fam_amphur_mom { get; set; }
        public string fam_district_mom { get; set; }
        public string fam_postcode_mom { get; set; }
        public string fam_tel_mom { get; set; }
        public string fam_mobile_mom { get; set; }
        public string district_name_mom { get; set; }
        public string amphur_name_mom { get; set; }
        public string province_name_mom { get; set; }
        //
        public string fam_name_marry { get; set; }
        public string fam_lastname_marry { get; set; }
        public string fam_age_marry { get; set; }
        public string fam_num_marry { get; set; }
        public string fam_moo_marry { get; set; }
        public string fam_province_marry { get; set; }
        public string fam_amphur_marry { get; set; }
        public string fam_district_marry { get; set; }
        public string fam_postcode_marry { get; set; }
        public string fam_tel_marry { get; set; }
        public string fam_mobile_marry { get; set; }
        public string district_name_marry { get; set; }
        public string amphur_name_marry { get; set; }
        public string province_name_marry { get; set; }

        public string person_id { get; set; }
        public string fam_submit_date { get; set; }
        public string fam_ref_admin_id { get; set; }

        dbFile db = new dbFile();

        public void insertFamily() {

            databaseClass dbClass = new databaseClass();


            if (fam_age_dad == null || fam_age_dad == "") {

                fam_age_dad = "0";

            }

            if (fam_age_mom == null || fam_age_mom == "")
            {

                fam_age_mom = "0";

            }

            if (fam_age_marry == null || fam_age_marry == "")
            {

                fam_age_marry = "0";

            }

            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {

                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO tab_personal_family ("+ 
                "fam_name_dad"+
                ",fam_lastname_dad"+
                ",fam_age_dad"+
                ",fam_num_dad"+
                ",fam_moo_dad"+
                ",fam_province_dad"+
                ",fam_amphur_dad"+
                ",fam_district_dad"+
                ",fam_postcode_dad"+
                ",fam_tel_dad"+
                ",fam_mobile_dad"+
                ",fam_name_mom"+
                ",fam_lastname_mom"+
                ",fam_age_mom"+
                ",fam_num_mom"+
                ",fam_moo_mom"+
                ",fam_province_mom"+
                ",fam_amphur_mom"+
                ",fam_district_mom"+
                ",fam_postcode_mom"+
                ",fam_tel_mom"+
                ",fam_mobile_mom"+
                ",fam_name_marry"+
                ",fam_lastname_marry"+
                ",fam_age_marry"+
                ",fam_num_marry"+
                ",fam_moo_marry"+
                ",fam_province_marry"+
                ",fam_amphur_marry"+
                ",fam_district_marry"+
                ",fam_postcode_marry"+
                ",fam_tel_marry"+
                ",fam_mobile_marry"+
                ",fam_ref_person_id"+
                ",fam_submit_date"+
                ",fam_ref_admin_id" + ") VALUES("+
                "@fam_name_dad"+
                ",@fam_lastname_dad" +
                ",@fam_age_dad" +
                ",@fam_num_dad" +
                ",@fam_moo_dad" +
                ",@fam_province_dad" +
                ",@fam_amphur_dad" +
                ",@fam_district_dad" +
                ",@fam_postcode_dad" +
                ",@fam_tel_dad" +
                ",@fam_mobile_dad" +
                ",@fam_name_mom" +
                ",@fam_lastname_mom" +
                ",@fam_age_mom" +
                ",@fam_num_mom" +
                ",@fam_moo_mom" +
                ",@fam_province_mom" +
                ",@fam_amphur_mom" +
                ",@fam_district_mom" +
                ",@fam_postcode_mom" +
                ",@fam_tel_mom" +
                ",@fam_mobile_mom" +
                ",@fam_name_marry" +
                ",@fam_lastname_marry" +
                ",@fam_age_marry" +
                ",@fam_num_marry" +
                ",@fam_moo_marry" +
                ",@fam_province_marry" +
                ",@fam_amphur_marry" +
                ",@fam_district_marry" +
                ",@fam_postcode_marry" +
                ",@fam_tel_marry" +
                ",@fam_mobile_marry" +
                ",@fam_ref_person_id" +
                ",@fam_submit_date" +
                ",@fam_ref_admin_id" + ")", conn);
                cmd.Parameters.AddWithValue("@fam_name_dad", fam_name_dad);
                cmd.Parameters.AddWithValue("@fam_lastname_dad", fam_lastname_dad);
                cmd.Parameters.AddWithValue("@fam_age_dad", fam_age_dad);
                cmd.Parameters.AddWithValue("@fam_num_dad", fam_num_dad);
                cmd.Parameters.AddWithValue("@fam_moo_dad", fam_moo_dad);
                cmd.Parameters.AddWithValue("@fam_province_dad", fam_province_dad);
                cmd.Parameters.AddWithValue("@fam_amphur_dad",fam_amphur_dad);
                cmd.Parameters.AddWithValue("@fam_district_dad",fam_district_dad);
                cmd.Parameters.AddWithValue("@fam_postcode_dad", fam_postcode_dad);
                cmd.Parameters.AddWithValue("@fam_tel_dad", fam_tel_dad);
                cmd.Parameters.AddWithValue("@fam_mobile_dad", fam_mobile_dad);
                cmd.Parameters.AddWithValue("@fam_name_mom", fam_name_mom);
                cmd.Parameters.AddWithValue("@fam_lastname_mom", fam_lastname_mom);
                cmd.Parameters.AddWithValue("@fam_age_mom", fam_age_mom);
                cmd.Parameters.AddWithValue("@fam_num_mom", fam_num_mom);
                cmd.Parameters.AddWithValue("@fam_moo_mom", fam_moo_mom);
                cmd.Parameters.AddWithValue("@fam_province_mom", fam_province_mom);
                cmd.Parameters.AddWithValue("@fam_amphur_mom", fam_amphur_mom);
                cmd.Parameters.AddWithValue("@fam_district_mom", fam_district_mom);
                cmd.Parameters.AddWithValue("@fam_postcode_mom", fam_postcode_mom);
                cmd.Parameters.AddWithValue("@fam_tel_mom", fam_tel_mom);
                cmd.Parameters.AddWithValue("@fam_mobile_mom", fam_mobile_mom);
                cmd.Parameters.AddWithValue("@fam_name_marry", fam_name_marry);
                cmd.Parameters.AddWithValue("@fam_lastname_marry", fam_lastname_marry);
                cmd.Parameters.AddWithValue("@fam_age_marry", fam_age_marry);
                cmd.Parameters.AddWithValue("@fam_num_marry", fam_num_marry);
                cmd.Parameters.AddWithValue("@fam_moo_marry", fam_moo_marry);
                cmd.Parameters.AddWithValue("@fam_province_marry", fam_province_marry);
                cmd.Parameters.AddWithValue("@fam_amphur_marry", fam_amphur_marry);
                cmd.Parameters.AddWithValue("@fam_district_marry", fam_district_marry);
                cmd.Parameters.AddWithValue("@fam_postcode_marry", fam_postcode_marry);
                cmd.Parameters.AddWithValue("@fam_tel_marry", fam_tel_marry);
                cmd.Parameters.AddWithValue("@fam_mobile_marry", fam_mobile_marry);
                cmd.Parameters.AddWithValue("@fam_ref_person_id", person_id);
                cmd.Parameters.AddWithValue("@fam_submit_date", DateTime.Now);
                cmd.Parameters.AddWithValue("@fam_ref_admin_id", "1");
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                conn.Close();

            }
            

        }
        public void get_family(string id) {

            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tab_personal_family INNER JOIN tab_emp ON tab_emp.ep_ref_personal_id = tab_personal_family.fam_ref_person_id WHERE tab_emp.ep_id = '" + id + "'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    fam_name_dad = rdr["fam_name_dad"].ToString();
                    fam_lastname_dad = rdr["fam_lastname_dad"].ToString();
                    fam_age_dad = rdr["fam_age_dad"].ToString();
                    fam_num_dad= rdr["fam_num_dad"].ToString();
                    fam_moo_dad = rdr["fam_moo_dad"].ToString();
                    fam_province_dad = rdr["fam_province_dad"].ToString();
                    fam_amphur_dad = rdr["fam_amphur_dad"].ToString();
                    fam_district_dad = rdr["fam_district_dad"].ToString();
                    fam_postcode_dad = rdr["fam_postcode_dad"].ToString();
                    fam_tel_dad = rdr["fam_tel_dad"].ToString();
                    fam_mobile_dad = rdr["fam_mobile_dad"].ToString();

                    fam_name_mom = rdr["fam_name_mom"].ToString();
                    fam_lastname_mom = rdr["fam_lastname_mom"].ToString();
                    fam_age_mom = rdr["fam_age_mom"].ToString();
                    fam_num_mom = rdr["fam_num_mom"].ToString();
                    fam_moo_mom = rdr["fam_moo_mom"].ToString();
                    fam_province_mom = rdr["fam_province_mom"].ToString();
                    fam_amphur_mom = rdr["fam_amphur_mom"].ToString();
                    fam_district_mom = rdr["fam_district_mom"].ToString();
                    fam_postcode_mom = rdr["fam_postcode_mom"].ToString();
                    fam_tel_mom = rdr["fam_tel_mom"].ToString();
                    fam_mobile_mom = rdr["fam_mobile_mom"].ToString();


                    fam_name_marry = rdr["fam_name_marry"].ToString();
                    fam_lastname_marry = rdr["fam_lastname_marry"].ToString();
                    fam_age_marry = rdr["fam_age_marry"].ToString();
                    fam_num_marry = rdr["fam_num_marry"].ToString();
                    fam_moo_marry = rdr["fam_moo_marry"].ToString();
                    fam_province_marry = rdr["fam_province_marry"].ToString();
                    fam_amphur_marry = rdr["fam_amphur_marry"].ToString();
                    fam_district_marry = rdr["fam_district_marry"].ToString();
                    fam_postcode_marry = rdr["fam_postcode_marry"].ToString();
                    fam_tel_marry = rdr["fam_tel_marry"].ToString();
                    fam_mobile_marry = rdr["fam_mobile_marry"].ToString();

                    
                }


                conn.Close();

            }

        }
        public void selectFamilyPerson(string person)
        {

            using (SqlConnection conn = new SqlConnection(db.sqlConnection))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT *,d1.district_name AS district_name_dad, a1.amphur_name AS amphur_name_dad, p1.province_name AS province_name_dad,"+
                                                 " d2.district_name AS district_name_mom, a2.amphur_name AS amphur_name_mom, p2.province_name AS province_name_mom,"+
                                                 " d3.district_name AS district_name_marry, a3.amphur_name AS amphur_name_marry, p3.province_name AS province_name_marry"+
                                                 " FROM tab_personal_family"+
                                                 " LEFT JOIN tab_province p1 ON p1.province_id = fam_province_dad"+
                                                 " LEFT JOIN tab_province p2 ON p2.province_id = fam_province_mom"+
                                                 " LEFT JOIN tab_province p3 ON p3.province_id = fam_province_marry"+
                                                 " LEFT JOIN tab_amphur a1 ON a1.amphur_id = fam_amphur_dad"+
                                                 " LEFT JOIN tab_amphur a2 ON a2.amphur_id = fam_amphur_mom"+
                                                 " LEFT JOIN tab_amphur a3 ON a3.amphur_id = fam_province_marry"+
                                                 " LEFT JOIN tab_district d1 ON d1.district_id = fam_district_dad"+
                                                 " LEFT JOIN tab_district d2 ON d2.district_id = fam_district_mom"+
                                                 " LEFT JOIN tab_district d3 ON d3.district_id = fam_district_marry"+
                                                 " WHERE fam_ref_person_id = '"+person+"'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    fam_id = rdr["fam_id"].ToString();
                    person_id = rdr["fam_ref_person_id"].ToString();
                    fam_submit_date = rdr["fam_submit_date"].ToString();
                    fam_ref_admin_id = rdr["fam_ref_admin_id"].ToString();

                    fam_name_dad = rdr["fam_name_dad"].ToString();
                    fam_lastname_dad = rdr["fam_lastname_dad"].ToString();
                    fam_age_dad = rdr["fam_age_dad"].ToString();
                    fam_num_dad = rdr["fam_num_dad"].ToString();
                    fam_moo_dad = rdr["fam_moo_dad"].ToString();
                    fam_province_dad = rdr["fam_province_dad"].ToString();
                    fam_amphur_dad = rdr["fam_amphur_dad"].ToString();
                    fam_district_dad = rdr["fam_district_dad"].ToString();
                    fam_postcode_dad = rdr["fam_postcode_dad"].ToString();
                    fam_tel_dad = rdr["fam_tel_dad"].ToString();
                    fam_mobile_dad = rdr["fam_mobile_dad"].ToString();
                    if (string.IsNullOrEmpty(rdr["district_name_dad"].ToString()))
                    {
                        district_name_dad = "-";

                    }
                    else {

                        district_name_dad = rdr["district_name_dad"].ToString();
                    }

                    if (string.IsNullOrEmpty(rdr["amphur_name_dad"].ToString()))
                    {
                        amphur_name_dad = "-";

                    }
                    else
                    {

                        amphur_name_dad = rdr["amphur_name_dad"].ToString();
                    }

                    if (string.IsNullOrEmpty(rdr["province_name_dad"].ToString()))
                    {
                        province_name_dad = "-";

                    }
                    else
                    {

                        province_name_dad = rdr["province_name_dad"].ToString();
                    }


                    fam_name_mom = rdr["fam_name_mom"].ToString();
                    fam_lastname_mom = rdr["fam_lastname_mom"].ToString();
                    fam_age_mom = rdr["fam_age_mom"].ToString();
                    fam_num_mom = rdr["fam_num_mom"].ToString();
                    fam_moo_mom = rdr["fam_moo_mom"].ToString();
                    fam_province_mom = rdr["fam_province_mom"].ToString();
                    fam_amphur_mom = rdr["fam_amphur_mom"].ToString();
                    fam_district_mom = rdr["fam_district_mom"].ToString();
                    fam_postcode_mom = rdr["fam_postcode_mom"].ToString();
                    fam_tel_mom = rdr["fam_tel_mom"].ToString();
                    fam_mobile_mom = rdr["fam_mobile_mom"].ToString();
                    if (string.IsNullOrEmpty(rdr["district_name_mom"].ToString()))
                    {
                        district_name_mom = "-";

                    }
                    else
                    {

                        district_name_mom = rdr["district_name_mom"].ToString();
                    }

                    if (string.IsNullOrEmpty(rdr["amphur_name_mom"].ToString()))
                    {
                        amphur_name_mom = "-";

                    }
                    else
                    {

                        amphur_name_mom = rdr["amphur_name_mom"].ToString();
                    }

                    if (string.IsNullOrEmpty(rdr["province_name_mom"].ToString()))
                    {
                        province_name_mom = "-";

                    }
                    else
                    {

                        province_name_mom = rdr["province_name_mom"].ToString();
                    }





                    fam_name_marry = rdr["fam_name_marry"].ToString();
                    fam_lastname_marry = rdr["fam_lastname_marry"].ToString();
                    fam_age_marry = rdr["fam_age_marry"].ToString();
                    fam_num_marry = rdr["fam_num_marry"].ToString();
                    fam_moo_marry = rdr["fam_moo_marry"].ToString();
                    fam_province_marry = rdr["fam_province_marry"].ToString();
                    fam_amphur_marry = rdr["fam_amphur_marry"].ToString();
                    fam_district_marry = rdr["fam_district_marry"].ToString();
                    fam_postcode_marry = rdr["fam_postcode_marry"].ToString();
                    fam_tel_marry = rdr["fam_tel_marry"].ToString();
                    fam_mobile_marry = rdr["fam_mobile_marry"].ToString();

                    if (string.IsNullOrEmpty(rdr["district_name_marry"].ToString()))
                    {
                        district_name_marry = "-";

                    }
                    else
                    {

                        district_name_marry = rdr["district_name_marry"].ToString();
                    }

                    if (string.IsNullOrEmpty(rdr["amphur_name_marry"].ToString()))
                    {
                        amphur_name_marry = "-";

                    }
                    else
                    {

                        amphur_name_marry = rdr["amphur_name_marry"].ToString();
                    }

                    if (string.IsNullOrEmpty(rdr["province_name_marry"].ToString()))
                    {
                        province_name_marry = "-";

                    }
                    else
                    {

                        province_name_marry = rdr["province_name_marry"].ToString();
                    }


                }


                conn.Close();

            }

        }
        public void insertFamilyLOG() {


            databaseClassLOG dbl = new databaseClassLOG();

            string table = "tab_personal_family";
            string[] Columns = {
                "fam_id",
                "fam_name_dad",
                "fam_lastname_dad",
                "fam_age_dad",
                "fam_num_dad",
                "fam_moo_dad",
                "fam_province_dad",
                "fam_amphur_dad",
                "fam_district_dad",
                "fam_postcode_dad",
                "fam_tel_dad",
                "fam_mobile_dad",
                "fam_name_mom",
                "fam_lastname_mom",
                "fam_age_mom",
                "fam_num_mom",
                "fam_moo_mom",
                "fam_province_mom",
                "fam_amphur_mom",
                "fam_district_mom",
                "fam_postcode_mom",
                "fam_tel_mom",
                "fam_mobile_mom",
                "fam_name_marry",
                "fam_lastname_marry",
                "fam_age_marry",
                "fam_num_marry",
                "fam_moo_marry",
                "fam_province_marry",
                "fam_amphur_marry",
                "fam_district_marry",
                "fam_postcode_marry",
                "fam_tel_marry",
                "fam_mobile_marry",
                "fam_ref_person_id",
                "fam_submit_date",
                "fam_ref_admin_id"
            };

            string[] Value = {

                fam_id,
                fam_name_dad,
                fam_lastname_dad,
                fam_age_dad,
                fam_num_dad,
                fam_moo_dad,
                fam_province_dad,
                fam_amphur_dad,
                fam_district_dad,
                fam_postcode_dad,
                fam_tel_dad,
                fam_mobile_dad,
                fam_name_mom,
                fam_lastname_mom,
                fam_age_mom,
                fam_num_mom,
                fam_moo_mom,
                fam_province_mom,
                fam_amphur_mom,
                fam_district_mom,
                fam_postcode_mom,
                fam_tel_mom,
                fam_mobile_mom,
                fam_name_marry,
                fam_lastname_marry,
                fam_age_marry,
                fam_num_marry,
                fam_moo_marry,
                fam_province_marry,
                fam_amphur_marry,
                fam_district_marry,
                fam_postcode_marry,
                fam_tel_marry,
                fam_mobile_marry,
                person_id,
                Convert.ToDateTime(fam_submit_date).ToString("yyyy-MM-dd HH:mm:ss"),
                fam_ref_admin_id

            };

            dbl.insert(table, Columns, Value);


        }
        public void updateFamily() {

            databaseClass dbc = new databaseClass();

            string table = "tab_personal_family";
            string[] Columns = {
                "fam_name_dad",
                "fam_lastname_dad",
                "fam_age_dad",
                "fam_num_dad",
                "fam_moo_dad",
                "fam_province_dad",
                "fam_amphur_dad",
                "fam_district_dad",
                "fam_postcode_dad",
                "fam_tel_dad",
                "fam_mobile_dad",
                "fam_name_mom",
                "fam_lastname_mom",
                "fam_age_mom",
                "fam_num_mom",
                "fam_moo_mom",
                "fam_province_mom",
                "fam_amphur_mom",
                "fam_district_mom",
                "fam_postcode_mom",
                "fam_tel_mom",
                "fam_mobile_mom",
                "fam_name_marry",
                "fam_lastname_marry",
                "fam_age_marry",
                "fam_num_marry",
                "fam_moo_marry",
                "fam_province_marry",
                "fam_amphur_marry",
                "fam_district_marry",
                "fam_postcode_marry",
                "fam_tel_marry",
                "fam_mobile_marry",
                "fam_ref_person_id",
                "fam_submit_date",
                "fam_ref_admin_id"
            };

            string[] Value = {

                fam_name_dad,
                fam_lastname_dad,
                fam_age_dad,
                fam_num_dad,
                fam_moo_dad,
                fam_province_dad,
                fam_amphur_dad,
                fam_district_dad,
                fam_postcode_dad,
                fam_tel_dad,
                fam_mobile_dad,
                fam_name_mom,
                fam_lastname_mom,
                fam_age_mom,
                fam_num_mom,
                fam_moo_mom,
                fam_province_mom,
                fam_amphur_mom,
                fam_district_mom,
                fam_postcode_mom,
                fam_tel_mom,
                fam_mobile_mom,
                fam_name_marry,
                fam_lastname_marry,
                fam_age_marry,
                fam_num_marry,
                fam_moo_marry,
                fam_province_marry,
                fam_amphur_marry,
                fam_district_marry,
                fam_postcode_marry,
                fam_tel_marry,
                fam_mobile_marry,
                person_id,
               Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"),
                fam_ref_admin_id

            };

            string where = "fam_id = '"+fam_id+"'";

            dbc.update(table, Columns, Value, where);

        }

    }
}
