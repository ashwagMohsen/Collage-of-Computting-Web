

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using CollageOfComputting.Models;
using System.IO;

namespace CollageOfComputting.Controllers
{
    public class ComputtingController : Controller
    {

        private WebProgDBEntities1 db = new WebProgDBEntities1();

        // GET: Computting
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Course(string name)
        {
            
            IQueryable <Courses> dbList = db.Courses.Where(a => a.Name == name);


            return View(dbList.ToList());
        }
        public ActionResult IT(string dept, string dept2)
        {
            IQueryable<Courses> dbList = db.Courses.Where(a => a.Department == dept || a.Department == dept2);
            return View(dbList.ToList());
        }
        public ActionResult CS(string dept, string dept2)
        {
            IQueryable<Courses> dbList = db.Courses.Where(a => a.Department == dept || a.Department == dept2);
            return View(dbList.ToList());
        }
        public JsonResult getLecture1(string teacherName, string getCoursename)
        {

            IQueryable<Courses> dbList = db.Courses.Where(a => a.Name == getCoursename && a.Teacher_Name == teacherName);

            return Json(dbList.ToList(), JsonRequestBehavior.AllowGet);
        }

        public FileContentResult DownloadFile(string file)
        {
            string path = Server.MapPath(file);
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            string fileName =Path.GetFileName(file).TrimEnd(); ;
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}
