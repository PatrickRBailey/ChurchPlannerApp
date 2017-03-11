using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchPlannerApp.Models
{
    public class AddMembersVM
    {
        public Service Service { get; set; }
        public List <Profile> Profiles { get; set; }
    }
}
