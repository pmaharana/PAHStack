using Microsoft.AspNet.Identity;
using PAHStack.Models;
using PAHStack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAHStack.Controllers
{
    public class VoteController : Controller
    {
        // GET: Vote
        [HttpPost]
        public ActionResult Up(int postId)
        {
            var db = new ApplicationDbContext();
            var voteTicket = new PostVoteModel {
                PostVoteValue = 1,
                PostId = postId,
                UserId = User.Identity.GetUserId()
            };
            db.PostVotes.Add(voteTicket);
            db.SaveChanges();

            var vm = db.Posts.Find(postId);
            return PartialView("_PartialVoteDisplay", vm);
        }
        // GET: Vote
        [HttpPost]
        public ActionResult Down(int postId)
        {
            var db = new ApplicationDbContext();
            var voteTicket = new PostVoteModel
            {
                PostVoteValue = -1,
                PostId = postId,
                UserId = User.Identity.GetUserId()
            };
            db.PostVotes.Add(voteTicket);
            db.SaveChanges();

            var vm = db.Posts.Find(postId);
            return PartialView("_PartialVoteDisplay", vm);
        }
    }
}