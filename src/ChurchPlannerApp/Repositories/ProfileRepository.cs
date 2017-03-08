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
        public List<Profile> GetAllProfiles()
        {
            return context.Profiles.ToList();
        }
        public int Update(Profile profile)
        {
            if (profile.ProfileID == 0)
            {
                foreach (var i in profile.Instruments)
                {
                    context.Instruments.Update(i);
                }
                context.Profiles.Add(profile);
            }
            else
                context.Profiles.Update(profile);

            return context.SaveChanges();

        }
    }
}
