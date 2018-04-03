using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class ContactController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult insertContact(string email, string phone_table, string phone, string mobile1, string mobile2, string emp_id) {

            emp_contactModel contact = new emp_contactModel();
            contact.contact_email = email;
            contact.contact_table = phone_table;
            contact.contact_phone = phone;
            contact.contact_mobile1 = mobile1;
            contact.contact_mobile2 = mobile2;
            contact.contact_emp_id = emp_id;
            contact.insert_contact();

            return RedirectToAction("emp","Employee",new {code=emp_id });
        }
        //[HttpPost]
        //public IActionResult update_contact(string email_update, string phone_table_update, string phone_update, string mobile1_update, string mobile2_update, string emp_id) {

        //    emp_contactModel contact = new emp_contactModel();
        //    contact.contact_email = email_update;
        //    contact.contact_table = phone_table_update;
        //    contact.contact_phone = phone_update;
        //    contact.contact_mobile1 = mobile1_update;
        //    contact.contact_mobile2 = mobile2_update;
        //    contact.contact_emp_id = emp_id;
        //   // contact.insert_contact();

        //    return RedirectToAction("employee", "Employee", new { code = emp_id });
        //}
        public string selectContact(string emp_id) {

            emp_contactModel cont = new emp_contactModel();
            cont.contact_emp_id = emp_id;

            return cont.select_contact();
        }
        [HttpPost]
        public IActionResult update_contact(string emp_id, string email_edit, string table_edit, string phone_edit, string mobile1_edit, string mobile2_edit) {

            emp_contactModel ct = new emp_contactModel();
            ct.selectContact_emp(emp_id);
            ct.insert_contact_log();

            ct.contact_email = email_edit;
            ct.contact_table = table_edit;
            ct.contact_phone = phone_edit;
            ct.contact_mobile1 = mobile1_edit;
            ct.contact_mobile2 = mobile2_edit;

            ct.update_contact();

            return RedirectToAction("emp", "Employee", new { code = emp_id });
        }
        [HttpPost]
        public IActionResult editContact(string person_id, string ct_mail, string ct_phone, string ct_table, string ct_mobile1, string ct_mobile2) {

            emp_contactModel ct = new emp_contactModel();
            ct.selectContact_Person(person_id);
            ct.insert_contact_log();

            ct.contact_emp_id = person_id;
            ct.contact_email = ct_mail;
            ct.contact_phone = ct_phone;
            ct.contact_table = ct_table;
            ct.contact_mobile1 = ct_mobile1;
            ct.contact_mobile2 = ct_mobile2;

            ct.update_contact();

            return RedirectToAction("editPersonal","Personal",new { person=person_id});
        }
    }
}
