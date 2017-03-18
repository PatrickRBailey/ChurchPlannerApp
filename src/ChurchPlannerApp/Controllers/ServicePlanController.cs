﻿using System;
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
        private IProfile pRepository;


        public ServicePlanController(IService repo, IProfile pRepo)
        {
            repository = repo;
            pRepository = pRepo;
        }
        // GET: /<controller>/
        public ViewResult AllServices()
        {
            var vm = new ProfileServiceViewModel();
            //vm.Profiles = pRepository.GetAllProfiles().ToList();
            vm.Services = repository.GetAllServices().ToList();
            return View(vm);
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

        [HttpGet]
        public ViewResult AddMembers(int serviceID)
        {
            var service = (from s in repository.GetAllServices()
                           where s.ServiceID == serviceID
                           select s).FirstOrDefault<Service>();

            var vm = new AddMembersVM();
            vm.Service = (service);
            vm.Profiles = pRepository.GetAllProfiles().ToList();
            return View(vm);
        }

        [HttpPost]
        public IActionResult AddMembers(AddMembersVM vm)
        {
            //vm.Profiles = pRepository.GetAllProfiles().ToList();
            var service = vm.Service;

            
            var selectedProfiles = vm.Profiles.Where(p => p.IsSelected == true);
            foreach (var profile in selectedProfiles)
            {
                var request = new ServiceRequest();
                request.ProfileID = profile.ProfileID;
                request.ServiceID = service.ServiceID;

                var Getservice = (from s in repository.GetAllServices()
                                 where s.ServiceID == request.ServiceID
                                 select s).FirstOrDefault<Service>();

                var GetProfile = (from p in pRepository.GetAllProfiles()
                                  where p.ProfileID == request.ProfileID
                                  select p).FirstOrDefault<Profile>();

                request.ProfileR = GetProfile;
                
                request.ServiceR = Getservice;
                

                
                GetProfile.ServiceRequests.Add(request);
                pRepository.Update(GetProfile);
            }
            


            return RedirectToAction("AllServices", "ServicePlan");
        }
    }
}
