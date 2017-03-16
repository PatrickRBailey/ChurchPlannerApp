using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChurchPlannerApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ChurchPlannerApp.Repositories
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> opts)
        : base(opts) { }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceRequest>()
                .HasKey(s => new { s.ServiceID, s.ProfileID });

            modelBuilder.Entity<ServiceRequest>()
                .HasOne(sr => sr.ProfileR)
                .WithMany(p => p.ServiceRequests)
                .HasForeignKey(sr => sr.ProfileID);

            modelBuilder.Entity<ServiceRequest>()
                .HasOne(sr => sr.ServiceR)
                .WithMany(s => s.ServiceRequests)
                .HasForeignKey(sr => sr.ServiceID);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityUser<string>>();
        }

    }
}
