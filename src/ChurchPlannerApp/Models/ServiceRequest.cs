using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchPlannerApp.Models
{
    public class ServiceRequest
    {
        public int ServiceRequestID { get; set; }
        public Service Service { get; set; }
        public Profile Profile { get; set; }

    }
}
