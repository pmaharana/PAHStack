using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAHStack.Models
{
    public class TagModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<PostModel> Posts { get; set; }
    }
}