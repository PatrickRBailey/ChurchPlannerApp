using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchPlannerApp.Models;

namespace ChurchPlannerApp.Repositories
{
    public interface IInstrument
    {
        IQueryable<Instrument> GetAllInstruments();
        int Update(Instrument instrument);
        int Delete(Instrument instrument);
    }
}
