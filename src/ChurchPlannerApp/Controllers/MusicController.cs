using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChurchPlannerApp.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ChurchPlannerApp.Controllers
{
    public class MusicController : Controller
    {
        private ISong repository;

        public MusicController(ISong repo)
        {
            repository = repo;
        }
        // GET: /<controller>/
        public ViewResult AllSongs()
        {
            return View(repository.GetAllSongs().ToList());
        }
    }
}
