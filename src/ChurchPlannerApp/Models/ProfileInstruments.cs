using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchPlannerApp.Models;

namespace ChurchPlannerApp.Models
{
    public class ProfileInstruments
    {
        public int ProfileID { get; set; }
        public Profile Profile { get; set; }

        public int InstrumentID { get; set; }
        public Instrument Instrument { get; set; }
    }
}
