using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using student_score_lite.Models;

namespace student_score_lite.Controllers
{
    public class ScoresController : Controller
    {
        private StudentScoreDBContext db = new StudentScoreDBContext();

        // GET: Scores
        public ActionResult Index()
        {
            List<Test> testList = db.Test.ToList();
            List<Student> studentList = db.Student.ToList();
            List<Score> scoreList = db.Score.ToList();

            List<ScoreListItem> itemList = new List<ScoreListItem>();
            ScoreListItem item;

            foreach(Score score in scoreList)
            {
                item = new ScoreListItem();
                item.id = score.id;
                item.grade = score.grade;
                item.studentName = studentList.Where(s => s.id.Equals(score.idStudent)).First().name;
                item.testName = testList.Where(t => t.id.Equals(score.idTest)).First().name;

                itemList.Add(item);
            }

            ViewBag.scoreList = itemList;
            return View();
        }

        // GET: Scores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = db.Score.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        // GET: Scores/Create
        public ActionResult Create()
        {
            ViewBag.testList = db.Test.ToList();
            ViewBag.studentList = db.Student.ToList();
            return View();
        }

        // POST: Scores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,grade,idTest,idStudent")] Score score)
        {
            if (ModelState.IsValid)
            {
                db.Score.Add(score);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(score);
        }

        // GET: Scores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = db.Score.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        // POST: Scores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,grade,idTest,idStudent")] Score score)
        {
            if (ModelState.IsValid)
            {
                db.Entry(score).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(score);
        }

        // GET: Scores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = db.Score.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        // POST: Scores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Score score = db.Score.Find(id);
            db.Score.Remove(score);
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
