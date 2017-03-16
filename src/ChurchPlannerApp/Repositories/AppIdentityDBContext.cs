using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ChurchPlannerApp.Models;

namespace ChurchPlannerApp.Repositories
{
    public class AppIdentityDBContext : IdentityDbContext<MusicUser>
    {
        public AppIdentityDBContext(DbContextOptions<AppIdentityDBContext> options)
            : base(options) { }
    }
}
