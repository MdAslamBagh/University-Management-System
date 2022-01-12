using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using University_Management_System.Models;
using System.Text;

namespace University_Management_System.Controllers
{
    public class CourseController : Controller
    {
        private UniversityDBContext db = new UniversityDBContext();

        public CourseController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: Course
        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Department).Include(c => c.Semester);
            return View(courses.ToList());
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }



        // GET: Course/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Deparments, "Id", "DeptName");
            ViewBag.SemesterId = new SelectList(db.Semesters, "Id", "Semester_Name");
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Course_Code,Course_Name,Course_Credit,DepartmentId,SemesterId")] Course course)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Courses.Add(course);
        //        db.SaveChanges();
        //       // ViewBag.Message = "Course Saved Successfully.";
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.DepartmentId = new SelectList(db.Deparments, "Id", "DeptCode", course.DepartmentId);
        //    ViewBag.SemesterId = new SelectList(db.Semesters, "Id", "Semester_Name", course.SemesterId);
        //    return View(course);
        //}



        //web api call

        Uri baseAddress = new Uri("http://localhost:54213/student/create");
        HttpClient client;

        [HttpPost]
        public ActionResult Create(Course course)
        {
            string data = JsonConvert.SerializeObject(course);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/user", content).Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}
            db.Courses.Add(course);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Deparments, "Id", "DeptCode", course.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "Id", "Semester_Name", course.SemesterId);
            return View(course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Course_Code,Course_Name,Course_Credit,CourseAssignTo,DepartmentId,SemesterId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Deparments, "Id", "DeptCode", course.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "Id", "Semester_Name", course.SemesterId);
            return View(course);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
{
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
