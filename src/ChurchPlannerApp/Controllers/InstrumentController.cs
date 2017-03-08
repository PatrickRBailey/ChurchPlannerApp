using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchPlannerApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using ChurchPlannerApp.Models;

namespace ChurchPlannerApp.Controllers
{
    public class InstrumentController : Controller
    {
        private IInstrument repository;

        public InstrumentController(IInstrument repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return View(repository.GetAllInstruments().ToList());
        }

        public IActionResult RemoveInstrument(int id)
        {
            Instrument instrument = (from i in repository.GetAllInstruments()
                         where i.InstrumentID == id
                         select i).FirstOrDefault<Instrument>();
            repository.Delete(instrument);
            return RedirectToAction("Index", "Instrument");
        }
    }
}
