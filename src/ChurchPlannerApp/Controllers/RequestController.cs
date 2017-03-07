using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChurchPlannerApp.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ChurchPlannerApp.Controllers
{
    public class RequestController : Controller
    {
        private IServiceRequest repository;

        public RequestController(IServiceRequest repo)
        {
            repository = repo;
        }
        // GET: /<controller>/
        public ViewResult AllRequests()
        {
            return View(repository.GetPendingRequests().ToList());
        }
    }
}
