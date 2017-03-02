using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchPlannerApp.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public Profile From { get; set; }

    }
}
