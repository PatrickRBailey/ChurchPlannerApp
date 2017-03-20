using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchPlannerApp.Models
{
    public class Service
    {
        public int ServiceID { get; set; }
        [Required(ErrorMessage ="You must have a service date")]
        public DateTime ServiceDate { get; set; }
        [Required(ErrorMessage = "You must have a service Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "You must have a service practice date")]
        public DateTime PracticeDate { get; set; }
        public bool IsSelected { get; set;}
        public List<ServiceRequest> ServiceRequests { get; set; }




    }
}
