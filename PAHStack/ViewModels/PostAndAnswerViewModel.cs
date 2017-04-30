using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAHStack.Models;

namespace PAHStack.ViewModels
{
    public class PostAndAnswerViewModel
    {
        public PostModel Posts { get; set; }
        public ICollection<AnswerModel> AnswerCollection { get; set; }
    }
}