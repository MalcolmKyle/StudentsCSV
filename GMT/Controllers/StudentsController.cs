using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GMT.Models;
using PagedList;

namespace GMT.Controllers
{
    public class StudentsController : Controller
    {
        private StudentContext db = new StudentContext();

        // GET: Students
        public ActionResult Index(string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IdSortParam = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.SchoolSortParam = sortOrder == "school" ? "school_desc" : "school";
            ViewBag.FinalGradeSortParam = sortOrder == "final" ? "final_desc" : "final";
            
            var students = from s in db.Students select s;
     
            switch (sortOrder)
            {
                case "id_desc":
                    students = students.OrderByDescending(s => s.Id);
                    break;
                case "school":
                    students = students.OrderBy(s => s.School);
                    break;
                case "school_desc":
                    students = students.OrderByDescending(s => s.School);
                    break;
                case "final":
                    students = students.OrderBy(s => s.G3);
                    break;
                case "final_desc":
                    students = students.OrderByDescending(s => s.G3);
                    break;
                default:
                    students = students.OrderBy(s => s.Id);
                    break;
            }

            // Number of items listed on each page
            int pageSize = 50;
            // return value of page number if it has a value, or just 1 if not
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber,pageSize));
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Sex,Age,Address,FamSize,Pstatus,MEdu,FEdu,Reason,Guardian,TravelTime,StudyTime,Failures,SchoolSupport,FamSupport,Paid,Activities,Nursery,Higher,Internet,Romantic,FamilyRel,FreeTime,GoOut,DailyAlc,WeekAlc,Health,Absences,G1,G2,G3")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Sex,Age,Address,FamSize,Pstatus,MEdu,FEdu,Reason,Guardian,TravelTime,StudyTime,Failures,SchoolSupport,FamSupport,Paid,Activities,Nursery,Higher,Internet,Romantic,FamilyRel,FreeTime,GoOut,DailyAlc,WeekAlc,Health,Absences,G1,G2,G3")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
