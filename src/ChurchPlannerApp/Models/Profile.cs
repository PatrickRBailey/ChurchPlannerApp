using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchPlannerApp.Models
{
    public class Profile
    {
        public int ProfileID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string UserName { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public int Type { get; set; }
        public bool IsSelected { get; set; }
        public MusicUser User { get; set; }
        public List<ServiceRequest> ServiceRequests { get; set; }

    }
}
