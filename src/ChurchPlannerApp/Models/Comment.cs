using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ChurchPlannerApp.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        [Required(ErrorMessage = "You can't submit a blank comment")]
        public string Body { get; set; }
        public Profile From { get; set; }
        public DateTime Date { get; set; }

    }
}