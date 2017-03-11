using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchPlannerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ChurchPlannerApp.Repositories
{
    public class ProfileInstrumentRepository : IProfileInstrument
    {
        private ApplicationDBContext context;
        public ProfileInstrumentRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }

        public IQueryable<ProfileInstruments> GetAllProfileInstruments()
        {
            throw new NotImplementedException();
        }

        public List<Profile> GetAllProfiles()
        {
            return context.Profiles.ToList();
        }

        public int Update(ProfileInstruments ProfileInstrument)
        {
            throw new NotImplementedException();
        }

        public int Update(Profile profile)
        {
            if (profile.ProfileID == 0)
            {
                context.Profiles.Add(profile);
            }
            else
                context.Profiles.Update(profile);

            return context.SaveChanges();

        }
    }
}
