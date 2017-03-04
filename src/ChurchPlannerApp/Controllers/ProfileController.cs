using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChurchPlannerApp.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ChurchPlannerApp.Controllers
{
    public class ProfileController : Controller
    {
        private IProfile repository;
        public ProfileController(IProfile repo)
        {
            repository = repo;
        }
        // GET: /<controller>/
        public ViewResult AllMembers()
        {
            return View(repository.GetAllProfiles().ToList());
        }
    }
}
