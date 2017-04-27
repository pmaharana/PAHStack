using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAHStack.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public bool ApprovedAnswer { get; set; }
        public DateTime DateAnswered { get; set; }

        public IEnumerable<PostVoteModel> Votes { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}