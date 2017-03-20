using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchPlannerApp.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        [Required(ErrorMessage ="You must enter text into the body")]
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public Profile From { get; set; }
        private List<Comment> comments = new List<Comment>();
        public List<Comment> Comments { get { return comments; } }

    }
}
