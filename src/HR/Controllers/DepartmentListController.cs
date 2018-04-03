using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class DepartmentListController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public string getSection(string comp) {

            department_listModel dept = new department_listModel();
            dept.selectSection(comp);

            return dept.section_name;
        }
        public string getDept(string comp, string sect)
        {

            department_listModel dept = new department_listModel();
            dept.selectDepartment(comp, sect);

            return dept.dept_name;
        }
    }
}
