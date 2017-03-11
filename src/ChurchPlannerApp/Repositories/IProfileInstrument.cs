using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchPlannerApp.Models;

namespace ChurchPlannerApp.Repositories
{
    public interface IProfileInstrument
    {
        IQueryable<ProfileInstruments> GetAllProfileInstruments();
        int Update(ProfileInstruments ProfileInstrument);

    }
}
