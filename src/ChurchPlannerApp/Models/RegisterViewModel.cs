using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchPlannerApp.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="You must enter a first name")] 
        public string FirstName { get; set; }
        [Required(ErrorMessage = "You must enter a last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "You must enter an email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "You must enter a user name")]
        public string UserName { get; set; }
        public string PhoneNum { get; set; }
        [Required(ErrorMessage = "You must enter a password")]
        public string Password { get; set; }
        public string UserRole { get; set; }

    }
}
