using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PAHStack.Models;

namespace PAHStack.Controllers
{
    public class AnswerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Answer
        public ActionResult Index()
        {
            return View(db.Answers.ToList());
        }

        // GET: Answer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswerModel answerModel = db.Answers.Find(id);
            if (answerModel == null)
            {
                return HttpNotFound();
            }
            return View(answerModel);
        }

        // GET: Answer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Answer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Body,ApprovedAnswer,DateAnswered,UserId,PostId")] AnswerModel answerModel)
        {
            if (ModelState.IsValid)
            {
                db.Answers.Add(answerModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(answerModel);
        }

        // GET: Answer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswerModel answerModel = db.Answers.Find(id);
            if (answerModel == null)
            {
                return HttpNotFound();
            }
            return View(answerModel);
        }

        // POST: Answer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Body,ApprovedAnswer,DateAnswered,UserId,PostId")] AnswerModel answerModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answerModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(answerModel);
        }

        // GET: Answer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswerModel answerModel = db.Answers.Find(id);
            if (answerModel == null)
            {
                return HttpNotFound();
            }
            return View(answerModel);
        }

        // POST: Answer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnswerModel answerModel = db.Answers.Find(id);
            db.Answers.Remove(answerModel);
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
