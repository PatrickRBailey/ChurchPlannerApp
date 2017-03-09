using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchPlannerApp.Models
{
    public class Instrument
    {
        public int InstrumentID { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
        private List<Profile> profiles = new List<Profile>();
        public List<Profile> Profiles { get { return profiles; } }
    }

}

