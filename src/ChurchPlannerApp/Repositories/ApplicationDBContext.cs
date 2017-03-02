using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChurchPlannerApp.Models;


namespace ChurchPlannerApp.Repositories
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> opts)
        : base(opts) { }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Profile> Profiles { get; set; }
    }
}
