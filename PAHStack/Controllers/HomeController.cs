using Microsoft.AspNet.Identity;
using PAHStack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PAHStack.ViewModels;

namespace PAHStack.Controllers
{
    public class HomeController : Controller
    {
        private PostModel Post = new PostModel();
        private AnswerModel Answer = new AnswerModel();
        private ApplicationUser Uzer = new ApplicationUser();
        

        public ActionResult Index()
        {
            ViewBag.Title = "What's Hot";
            var db = new ApplicationDbContext();
            var posts = db.Posts.Include(i => i.User).ToList();

            //// get a users posts via the post table
            //var usersPosts = db.Posts.Where(w => w.UserId == User.Identity.GetUserId());

            //// get all posts for a user by querying the user
            //var user = db.Users.First(f => User.Identity.GetUserId() == f.Id);
            //var userPosts = user.Posts;

            if (User.Identity.IsAuthenticated)
            {
                ViewBag.UserId = User.Identity.GetUserId();
            }
            return View(posts);
        }

        [Authorize(Roles = "admin")]
        public ActionResult About()
        {
            var db = new ApplicationDbContext();
            var posts = db.Posts.ToList();
            var answers = db.Answers.ToList();
            var users = db.Users.ToList();
            var adminvm = new AdminViewModel(posts, answers, users);

            return View(adminvm);
        }


        [Authorize]
        public ActionResult Contact()
        {
            var db = new ApplicationDbContext();
            var currentUser = User.Identity.GetUserId();
            var posts = db.Posts.Where(w => w.UserId == currentUser).ToList();
            var user = db.Users.First(f => f.Id == currentUser);
            var answers = db.Answers.Where(w => w.UserId == currentUser).ToList();
            var vm = new ProfileViewModel(user, posts, answers);
            return View(vm);
        }

        [HttpPost]
        public ActionResult Search(SearchParams param)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var results = db.Posts
                .Include(i => i.User)
                .Where(w => w.Body.Contains(param.Keyword) ||
                w.Title.Contains(param.Keyword))
                .ToList();
            return PartialView("_SearchFormPartial", results);
        }
    }
}
    
