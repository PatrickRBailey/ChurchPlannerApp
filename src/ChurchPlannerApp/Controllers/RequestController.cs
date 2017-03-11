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
    public class RequestController : Controller
    {
        private IProfile repository;
        private IService sRepository;

        public RequestController(IProfile repo, IService sRepo)
        {
            repository = repo;
            sRepository = sRepo;
        }
        // GET: /<controller>/
        public ViewResult AllRequests()
        {
            var vm = new ProfileServiceViewModel();
            vm.Profiles = repository.GetAllProfiles().ToList();
            vm.Services = sRepository.GetAllServices().ToList();
            return View(vm);
        }

     
    }
}
