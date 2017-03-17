using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ChurchPlannerApp.Models
{
    public class MusicUser : IdentityUser
    {
        public int MusicUserID { get; set; }
    }
}
