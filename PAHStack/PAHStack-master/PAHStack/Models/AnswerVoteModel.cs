using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAHStack.Models
{
    public class AnswerVoteModel
    {
        public int Id { get; set; }
        public int AnswerVoteValue { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int AnswerId { get; set; }
        public AnswerModel Answer { get; set; }
    }
}