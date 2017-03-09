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
    public class ServicePlanController : Controller
    {
        private IService repository;

        public ServicePlanController(IService repo)
        {
            repository = repo;
        }
        // GET: /<controller>/
        public ViewResult AllServices()
        {
            return View(repository.GetAllServices().ToList());
        }

        [HttpGet]
        public ViewResult AddService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service s)
        {
            var service = new Service
            {
                Title = s.Title,
                PracticeDate = s.PracticeDate,
                ServiceDate = s.ServiceDate
            };
            repository.Update(service);

            return RedirectToAction("AllServices", "ServicePlan");
        }

        public IActionResult RemoveService(int id)
        {
            Service service = (from s in repository.GetAllServices()
                               where s.ServiceID == id
                               select s).FirstOrDefault<Service>();

            repository.Delete(service);
            return RedirectToAction("AllServices", "ServicePlan");
        }

        [HttpGet]
        public ViewResult EditService(int id)
        {
            var service = (from s in repository.GetAllServices()
                           where s.ServiceID == id
                           select s).FirstOrDefault<Service>();

            return View(service);
        }

        [HttpPost]
        public IActionResult EditService(Service s)
        {

            repository.Update(s);

            return RedirectToAction("AllServices", "ServicePlan");
        }
    }
}
