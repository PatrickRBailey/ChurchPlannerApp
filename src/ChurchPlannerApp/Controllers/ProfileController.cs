using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChurchPlannerApp.Repositories;
using ChurchPlannerApp.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ChurchPlannerApp.Controllers
{
    public class ProfileController : Controller
    {
        private IProfileInstrument testRepository;
        private IProfile repository;
        private IInstrument InstrumentRepository;
        public ProfileController(IProfile repo, IInstrument repo2, IProfileInstrument repo3)
        {
            repository = repo;
            InstrumentRepository = repo2;
            testRepository = repo3;
        }
        // GET: /<controller>/
        public ViewResult AllMembers()
        {
            return View(repository.GetAllProfiles().ToList());
            

        }

        [HttpGet]
        public ViewResult AddProfile()
        {
            var profileVM = new ProfileViewModel();
            profileVM.profile = new Models.Profile();
            profileVM.Instruments = InstrumentRepository.GetAllInstruments().ToList();
            return View(profileVM);
        }

        [HttpPost]
        public IActionResult AddProfile(ProfileViewModel profileVM)
        {
            repository.Update(profileVM.profile);
            var instruments = profileVM.Instruments.Where(i => i.Selected == true).ToList();
            foreach (var i in instruments)
            {
                var profileInstrument = new Profile_Instruments();
                profileInstrument.ProfileID = profileVM.profile.ProfileID;
                profileInstrument.InstrumentID = i.InstrumentID;
                testRepository.Update(profileInstrument);
                //profileVM.Instruments.Add(i);
                //InstrumentRepository.Update(i);
                //profileVM.profile.Instruments.Add(i);

            }

            
            


            return RedirectToAction("AllMembers", "Profile");
        }
    }
}
