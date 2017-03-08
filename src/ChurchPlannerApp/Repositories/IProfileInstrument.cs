using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchPlannerApp.Models;

namespace ChurchPlannerApp.Repositories
{
    public interface IProfileInstrument
    {
        IQueryable<Profile_Instruments> GetAllProfilesAndInstruments();
        int Update(Profile_Instruments profileI);
    }
}
