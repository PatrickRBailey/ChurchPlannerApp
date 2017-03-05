using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchPlannerApp.Models
{
    public class ServiceRequest
    {
        public int ServiceRequestID { get; set; }
        public Service ServiceR { get; set; }
        public Profile ProfileR { get; set; }
        public bool Is_Accepted { get; set; }

    }
}
