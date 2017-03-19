using System.ComponentModel.DataAnnotations;

namespace ChurchPlannerApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="You must enter a username")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="You must enter a password")]
        public string Password { get; set; }

    }
}
