using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchPlannerApp.Models
{
    //TODO: Remove Instruments from profile Model
    //TODO: Migrate and Update Database
    //TODO: Make AllMembers View Use this ViewModel
    public class ProfileViewModel
    {
        public Profile profile { get; set; }
        public List <Instrument> Instruments { get; set; }
    }
}
