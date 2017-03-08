using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchPlannerApp.Models;

namespace ChurchPlannerApp.Repositories
{
    public class ProfileInstrumentRepository: IProfileInstrument
    {
        private ApplicationDBContext context;
        public ProfileInstrumentRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Profile_Instruments> GetAllProfilesAndInstruments()
        {
            return context.ProfileInstruments;
        }
        public int Update(Profile_Instruments profileI)
        {
            if (profileI.ID == 0)
                context.ProfileInstruments.Add(profileI);
            else
                context.ProfileInstruments.Update(profileI);

            return context.SaveChanges();

        }
    }
}
