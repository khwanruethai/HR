using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using HR.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class PersonChangeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        private IHostingEnvironment _hostingEnvironment;

        public PersonChangeController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }
        [HttpPost]
        public async Task<IActionResult> insert_change_name(IList<IFormFile> file, string prefix_th, string name_th, string lastname_th, string prefix_en, string name_en, string lastname_en, string person_id) {

            DateTime dt = new DateTime(3000,01,01);

            personalModel ps = new personalModel();
            ps.select_personal(person_id); //person

            //
            personalChangeModel pc = new personalChangeModel();
            pc.ch_ref_person_id = person_id;
            pc.select_max_id();
            //
            if (pc.max_id != "N")
            {
                pc.ch_name_id = pc.max_id;
                pc.select_data_id();
                pc.ch_end_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                pc.event_status = "U";
                pc.update_person_change();
               
            }

            //

            pc.ch_ref_prefix_id_old = ps.prefix_th;
            pc.ch_name_th_old = ps.name_th;
            pc.ch_lastname_th_old = ps.lastname_th;
            pc.ch_name_en_old = ps.name_en;
            pc.ch_lastname_en_old = ps.lastname_en;
            pc.ch_ref_prefix_id = prefix_th;
            pc.ch_name_th = name_th;
            pc.ch_lastname_th = lastname_th;
            pc.ch_name_en = name_en;
            pc.ch_lastname_en = lastname_en;
            pc.ch_ref_person_id = person_id;
            pc.ch_start_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            pc.ch_end_date = Convert.ToDateTime(dt).ToString("yyyy-MM-dd HH:mm:ss");
            //change
            pc.insert_person_change();
            //
            ps.event_status = "U";
            ps.insertPersonalLOG();
            //person
            ps.personal_id = person_id;
            ps.prefix_th = prefix_th;
            ps.name_th = name_th;
            ps.lastname_th = lastname_th;
            ps.prefix_en = prefix_en;
            ps.name_en = name_en;
            ps.lastname_en = lastname_en;
            //person
            ps.updatePerson();
            //
            personFileModel pf = new personFileModel();
            

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "profile");
            foreach (var fl in file)
            {
                if (fl.Length > 0)
                {
                    pf.ch_file_ref_person_id = person_id;
                    pf.ch_file_name = fl.FileName;
                    pf.ch_ref_change_name_id = pc.turn_id;
                    pf.insert_file();

                    var filePath = Path.Combine(uploads, fl.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await fl.CopyToAsync(fileStream);

                    }
                    
                }
            }


            return RedirectToAction("editPersonal", "Personal", new { person = person_id});
            
        }
        [HttpPost]
        public async Task<IActionResult> upload_file(IList<IFormFile> file, string person_id, string change_name_id) {


            personFileModel pf = new personFileModel();


            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "profile");
            foreach (var fl in file)
            {
                if (fl.Length > 0)
                {
                    pf.ch_file_ref_person_id = person_id;
                    pf.ch_file_name = fl.FileName;
                    pf.ch_ref_change_name_id = change_name_id;
                    pf.insert_file();

                    var filePath = Path.Combine(uploads, fl.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await fl.CopyToAsync(fileStream);

                    }

                }
            }

            return RedirectToAction("editPersonal", "Personal", new { person = person_id });
        }
        public void del_personChange(string id) {


            personalChangeModel ps = new personalChangeModel();
            ps.ch_name_id = id;
            ps.select_data_id();

            ps.insert_person_change_LOG();
            ps.event_status = "D";
            ps.update_person_change();
        }
    }
}
