using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchPlannerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ChurchPlannerApp.Repositories
{
    public class ProfileRepository : IProfile
    {
        private ApplicationDBContext context;
        public ProfileRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }

        public int Delete(Profile profile)
        {
            context.Profiles.Remove(profile);
            return context.SaveChanges();
        }

        public List<Profile> GetAllProfiles()
        {
            return context.Profiles.Include(p => p.ServiceRequests).ToList();
        }

        
        public int Update(Profile profile)
        {
            if (profile.ProfileID == 0)
                context.Profiles.Add(profile);
            else
                context.Profiles.Update(profile);

            return context.SaveChanges();

        }
    }
}
