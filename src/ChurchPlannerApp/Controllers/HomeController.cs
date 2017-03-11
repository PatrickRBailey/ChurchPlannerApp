using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChurchPlannerApp.Repositories;
using ChurchPlannerApp.Models;



namespace ChurchPlannerApp.Controllers
{
    public class HomeController : Controller
    {
        private IProfile Prepository;
        private IService Srepository;

        public HomeController(IProfile Prepo, IService Srepo)
        {
            Prepository = Prepo;
            Srepository = Srepo;
        }
        // GET: /<controller>/
        public ViewResult Index()
        {
            var vm = new ProfileServiceViewModel();
            vm.Profiles = Prepository.GetAllProfiles().ToList();
            vm.Services = Srepository.GetAllServices().ToList();
            return View(vm);
        }
        
        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
