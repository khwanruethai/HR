using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class department_listModel
    {
        public string dept_list_id { get; set; }
        public string comp_id { get; set; }
        public string comp_name { get; set; }
        public string section_id { get; set; }
        public string section_name { get; set; }
        public string dept_id { get; set; }
        public string dept_name { get; set; }

        public object dp_id { get; set; }
        public object dp_name { get; set; }

        databaseClass db = new databaseClass();
        dbFile connect = new dbFile();
        
        public List<SelectListItem> selectSection(string comp) {

            string result = "<option text='เลือกฝ่าย' value='0'>เลือกฝ่าย</option>";
            List<SelectListItem> item = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT tab_section.section_id, tab_section.Section_name, tab_department_list.comp_id, tab_department_list.section_id"
                                                    +" FROM tab_section"
                                                    +" INNER JOIN tab_department_list ON tab_department_list.section_id = tab_section.section_id"
                                                    +" WHERE  tab_department_list.comp_id = '"+comp+"'"
                                                    +" GROUP BY tab_section.section_id, tab_section.Section_name, tab_department_list.comp_id, tab_department_list.section_id", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    item.Add(new SelectListItem { Text=rdr["Section_name"].ToString(), Value=rdr["section_id"].ToString()});
                   result  += "<option text='"+ rdr["Section_name"] + "' value='"+ rdr["section_id"] + "'>" + rdr["Section_name"] + "</option>";
                }


                conn.Close();
            }


            section_name = result;

            return item;
        }
        public List<SelectListItem> selectDepartment(string comp, string sect) {

            string result = "<option text='เลือกแผนก' value='0'>เลือกแผนก</option>";
            List<SelectListItem> item = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(connect.sqlConnection)) {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT tab_department.dept_id, tab_department.dept_name, tab_department_list.dept_id, tab_department_list.section_id, tab_department_list.comp_id FROM tab_department_list "+
                                                    " INNER JOIN tab_department ON tab_department.dept_id = tab_department_list.dept_id "+
                                                    " WHERE tab_department_list.comp_id = '"+comp+"' AND tab_department_list.section_id = '"+sect+"' "+
                                                    " GROUP BY tab_department.dept_id, tab_department.dept_name, tab_department_list.dept_id, tab_department_list.section_id, tab_department_list.comp_id", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
           
                while (rdr.Read()) {

                    item.Add(new SelectListItem { Text=rdr["dept_name"].ToString(), Value=rdr["dept_id"].ToString()});
                    result += "<option text='"+ rdr["dept_name"] + "' value='"+ rdr["dept_id"] + "'>" + rdr["dept_name"] + "</option>";
                }


               // conn.Close();

            }

                dept_name = result;
                return item;
        }
     

    }
}
