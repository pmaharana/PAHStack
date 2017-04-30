using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAHStack.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime DatePosted { get; set; } = DateTime.Now;
        public string Img { get; set; }
        public bool Starred { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public IEnumerable<AnswerModel> Answers { get; set; }

        public IEnumerable<PostVoteModel> Votes { get; set; }

        public virtual IEnumerable<TagModel> Tags { get; set; }


    }
}