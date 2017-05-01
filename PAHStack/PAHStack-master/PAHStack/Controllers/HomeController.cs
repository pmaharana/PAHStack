﻿using Microsoft.AspNet.Identity;
using PAHStack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PAHStack.Controllers
{
    public class HomeController : Controller
    {

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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}