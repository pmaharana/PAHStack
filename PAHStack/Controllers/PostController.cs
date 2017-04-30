using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAHStack.Models;
using Microsoft.AspNet.Identity;
using System.Net;
using System.Data.Entity;
using PAHStack.ViewModels;

namespace PAHStack.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        

        // GET: Post
        public ActionResult Index()
        {
            ViewBag.Title = "What's Hot";
            //var db = new ApplicationDbContext();
            var posts = db.Posts.ToList();
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.UserId = User.Identity.GetUserId();
            }
            return View(posts);
        }

        // GET: Post/Details/5
        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PostModel post = db.Posts.Include(i => i.User).Where(w => w.Id == Id).First();
            var answers = db.Answers.Include(i => i.User).Where(w => w.PostId == Id).ToList();
            var vm = new PostAndAnswerViewModel(post, answers);

            if (post == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // GET: Post/Create
        public ActionResult Create(int? id)
        {

            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Body,Img,DatePosted")] PostModel post)
        {
            if (ModelState.IsValid)
            {
                post.UserId = HttpContext.User.Identity.GetUserId();
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(post);
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostModel posts = db.Posts.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="Id,Title,Body,DatePosted,Img")] PostModel post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostModel posts = db.Posts.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }

        // POST: Post/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            PostModel posts = db.Posts.Find(id);
            db.Posts.Remove(posts);
            db.SaveChanges();
            return RedirectToAction("Index");

            
        }
    }
}
