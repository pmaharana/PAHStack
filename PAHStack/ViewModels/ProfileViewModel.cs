using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAHStack.Models;

namespace PAHStack.ViewModels
{
    public class ProfileViewModel
    {
        public ApplicationUser CurrentUser { get; set; }
        public IEnumerable<PostModel> Posts { get; set; }
        public IEnumerable<AnswerModel> Answers { get; set; }

        public ProfileViewModel(ApplicationUser user, IEnumerable<PostModel> posts, IEnumerable<AnswerModel> answers)
        {
            this.CurrentUser = user;
            this.Posts = posts;
            this.Answers = answers;
        }

    }
}