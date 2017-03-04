using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchPlannerApp.Models
{
    public class Service
    {
        public int ServiceID { get; set; }
        public DateTime ServiceDate { get; set; }
        public string Title { get; set; }
        public DateTime PracticeDate { get; set; }

        private List<Profile> team = new List<Profile>();
        public List<Profile> Team { get { return team; } }
    }
}
