using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChurchPlannerApp.Repositories;



namespace ChurchPlannerApp.Controllers
{
    public class HomeController : Controller
    {
        private IServiceRequest repository;

        public HomeController(IServiceRequest repo)
        {
            repository = repo;
        }
        // GET: /<controller>/
        public ViewResult Index()
        {
            return View();
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
