using PAHStack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAHStack.ViewModel
{
    public class VoteButtonVM
    {
        public PostModel Post { get; set; }
        public int VoteValue { get; set; } = 0; 
        public bool IsAllowedToVote { get; set; } = false;
    }
}