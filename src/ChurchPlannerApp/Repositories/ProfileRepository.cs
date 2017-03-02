using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchPlannerApp.Models;

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
    }
}
