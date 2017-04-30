using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAHStack.Models
{
    public class PostVoteModel
    {
        public int Id { get; set; }
        public int PostVoteValue { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int PostId { get; set; }
        public PostModel Post { get; set; }

    }
}