using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class AddressController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult insertAddress(string num, string moo, string name, string alley, string road, string select_province, string select_amphur, string select_district, string type, string postcode, string num_call, string moo_call, string name_call, string alley_call, string road_call, string select_province1, string select_amphur1, string select_district1, string type_call, string postcode_call, string emp_id) {

            AddressModel add = new AddressModel();
            add.address_num = num;
            add.address_moo = moo;
            add.address_type = type;
            add.address_name = name;
            add.address_alley = alley;
            add.address_road = road;
            add.address_district_id = select_district;
            add.address_amphur_id = select_amphur;
            add.address_province_id = select_province;
            add.address_postcode = postcode;
            //
            add.address_num_call = num_call;
            add.address_moo_call = moo_call;
            add.address_type_call = type_call;
            add.address_name_call = name_call;
            add.address_alley_call = alley_call;
            add.address_road_call = road_call;
            add.address_district_id_call = select_district1;
            add.address_amphur_id_call = select_amphur1;
            add.address_province_id_call = select_province1;
            add.address_postcode_call = postcode_call;

            add.address_ref_emp_id = emp_id;

         //   string aa = "1>" + num + "2>" + moo + "3>" + type + "4>" + name + "5>" + alley + "6>" + road + "7>" + select_district + "8>" + select_amphur + "9>" + select_province + "10>" + postcode;
            add.insertAddress();

            return RedirectToAction("employee", "Employee", new { code = emp_id });
        }

        public string dataAddress(string emp)
        {

            AddressModel add = new AddressModel();
            return add.data_address(emp);

        }
        [HttpPost]
        public IActionResult editAddress(string person_id, string add_num, string add_moo, string add_type, string add_name, string add_alley, string add_road, string add_district, string add_amphur, string add_province, string add_code, string add_num1, string add_moo1, string call_type, string add_name1, string add_alley1, string add_road1, string add_district1, string add_amphur1, string add_province1, string add_code1) {

            AddressModel add = new AddressModel();
            add.selectAddressPerson(person_id);
            add.insertAddressLOG();

            add.address_ref_emp_id = person_id;
            add.address_num = add_num;
            add.address_moo = add_moo;
            add.address_type = add_type;
            add.address_name = add_name;
            add.address_alley = add_alley;
            add.address_road = add_road;
            add.address_district_id = add_district;
            add.address_amphur_id = add_amphur;
            add.address_province_id = add_province;
            add.address_postcode = add_code;

            add.address_num_call = add_num1;
            add.address_moo_call = add_moo1;
            add.address_type_call = call_type;
            add.address_name_call = add_name1;
            add.address_alley_call = add_alley1;
            add.address_road_call = add_road1;
            add.address_district_id_call = add_district1;
            add.address_amphur_id_call = add_amphur1;
            add.address_province_id_call = add_province1;
            add.address_postcode_call = add_code1;

            add.updateAddress();
            return RedirectToAction("editPersonal","Personal",new { person = person_id});

        }
       
    }
   
}
