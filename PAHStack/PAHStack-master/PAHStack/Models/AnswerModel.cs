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
        public bool? ApprovedAnswer { get; set; }
        public DateTime DateAnswered { get; set; } = DateTime.Now;

        public IEnumerable<AnswerVoteModel> AnswerVotes { get; set; }

        //multiple answers per user 
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }


        //multiple answers per post
        public int PostId { get; set; }
        public PostModel Post { get; set; }


    }
}