using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchPlannerApp.Models;

namespace ChurchPlannerApp.Repositories
{
    public interface IProfile
    {
        List<Profile> GetAllProfiles();
        int Update(Profile profile);
    }
}
