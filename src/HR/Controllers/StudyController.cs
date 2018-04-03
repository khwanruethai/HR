using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Models;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    public class StudyController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult insertStudy(IEnumerable<string> study_year, IEnumerable<string> study_education, IEnumerable<string> study_academy, IEnumerable<string> study_gpa, string emp_id)
        {
            int count = study_year.Count();
            List<string> year = new List<string>();
            List<string> education = new List<string>();
            List<string> academy = new List<string>();
            List<string> gpa = new List<string>();
            

            foreach (string y in study_year)
            {
                year.Add(y);
            }
            foreach (string edu in study_education ) {

                education.Add(edu);
            }
            foreach (string ac in study_academy) {

                academy.Add(ac);
            }
            foreach (string grade in study_gpa) {

                gpa.Add(grade);
            }
            string result = "";

            emp_studyModel study = new emp_studyModel();

            for (int num = 0; num < year.Count; num++)
            {
                study.study_year = year[num];
                
                study.insertStudy();

            }
            
            return RedirectToAction("employee","Employee",new { code="32", test = result });
        }
        [HttpPost]
        public IActionResult addStudy(string person_id, IEnumerable<string> study_year, IEnumerable<string> study_degree, IEnumerable<string> study_branch, IEnumerable<string> study_academy, IEnumerable<string> study_gpa) {

            int len = study_year.Count();
            List<string> year = new List<string>();
            List<string> degree = new List<string>();
            List<string> branch = new List<string>();
            List<string> aca = new List<string>();
            List<string> gpa = new List<string>();

            string txt_ = "";


            foreach (var txt in study_year) {

                year.Add(txt);
            }

            foreach (var txt in study_degree) {

                degree.Add(txt);
            }

            foreach (var txt in study_branch) {

                branch.Add(txt);
            }

            foreach (var txt in study_academy) {

                aca.Add(txt);
            }

            foreach (var txt in study_gpa) {

                gpa.Add(txt);
            }


            personal_studyModel st = new personal_studyModel();

            for (int i = 0; i < len; i++) {

                st.study_ref_personal_id = person_id;
                st.study_year = year[i];
                st.study_degree = degree[i];
                st.study_branch = branch[i];
                st.study_academy = aca[i];
                st.study_gpa = gpa[i];
                
                st.insertStudy();
            }


            return RedirectToAction("editPersonal","Personal",new { person = person_id});

        }
        [HttpPost]
        public IActionResult editStudy(string person_id, string study_id, string s_year, string s_degree, string s_branch, string s_academy, string s_gpa) {

            personal_studyModel st = new personal_studyModel();

            st.select_study_person(study_id);
            st.insertStudyLOG();

            st.study_year = s_year;
            st.study_degree = s_degree;
            st.study_branch = s_branch;
            st.study_academy = s_academy;
            st.study_gpa = s_gpa;

            
            st.updateStudy();

            return RedirectToAction("editPersonal","Personal",new { person = person_id});
        }
    }
}
