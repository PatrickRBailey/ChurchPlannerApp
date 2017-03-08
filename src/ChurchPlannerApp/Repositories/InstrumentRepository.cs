using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchPlannerApp.Models;

namespace ChurchPlannerApp.Repositories
{
    public class InstrumentRepository : IInstrument
    {
        private ApplicationDBContext context;
        public InstrumentRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Instrument> GetAllInstruments()
        {
            return context.Instruments;
        }

        public int Update(Instrument instrument)
        {
            if (instrument.InstrumentID == 0)
                context.Instruments.Add(instrument);
            else
                context.Instruments.Update(instrument);

            return context.SaveChanges();

        }
        public int Delete(Instrument i)
        {
            context.Instruments.Remove(i);
            return context.SaveChanges();
        }
    }
}
