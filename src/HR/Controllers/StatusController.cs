using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class StatusController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public string getStatus(string status) {

            info_statusModel st = new info_statusModel();
            st.selectStatusbyId(status);


            return st.status_name;
        }
        [HttpPost]
        public IActionResult editStatus(string status_edit, string status_id) {

            info_statusModel st = new info_statusModel();

            st.selectStatusbyId(status_id);
            st.insertStatusLOG();

            st.status_name = status_edit;
            st.status_id = status_id;
            st.event_status = "U";

            st.update_Status();

            return RedirectToAction("status","Information");
        }
        public void del_status(string id) {


            info_statusModel st = new info_statusModel();

            st.selectStatusbyId(id);
            st.insertStatusLOG();

            st.event_status = "D";
            st.status_id = id;

            st.update_Status();
            
        }
    }
}
