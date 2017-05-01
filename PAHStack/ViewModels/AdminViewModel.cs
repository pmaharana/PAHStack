using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAHStack.Models;

namespace PAHStack.ViewModels
{
    public class AdminViewModel
    {
        public ICollection<PostModel> ListOfPosts { get; set; }
        public ICollection<AnswerModel> ListOfAnswers { get; set; }
        public ICollection<ApplicationUser> ListOfUsers { get; set; }

        public AdminViewModel(ICollection<PostModel> posts, ICollection<AnswerModel> answers, ICollection<ApplicationUser> users)
        {
            this.ListOfPosts = posts;
            this.ListOfAnswers = answers;
            this.ListOfUsers = users;
        }
        public AdminViewModel()
        {

        }
    }
}