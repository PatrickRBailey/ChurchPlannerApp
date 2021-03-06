﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChurchPlannerApp.Repositories;
using ChurchPlannerApp.Models;
using Microsoft.AspNetCore.Authorization;


namespace ChurchPlannerApp.Controllers
{
    [Authorize]
    
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
        [Authorize]
        public IActionResult AllServices()
        {
            if (HttpContext.User.IsInRole("Musician"))
            {
               return RedirectToAction("Login", "Account");
            }
            var vm = new AllServicesViewModel();
            vm.Profiles = pRepository.GetAllProfiles().ToList();
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
            if (ModelState.IsValid)
            {
                var service = new Service
                {
                    Title = s.Title,
                    PracticeDate = DateTime.Parse(s.PracticeDate.ToString()),
                    ServiceDate = DateTime.Parse(s.ServiceDate.ToString())
                };
                repository.Update(service);

                return RedirectToAction("AllServices", "ServicePlan");
            }
            else
                return View();
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
            //TODO: Test this
            var service = (from s in repository.GetAllServices()
                           where s.ServiceID == serviceID
                           select s).FirstOrDefault<Service>();
            var profiles = pRepository.GetAllProfiles().ToList();
            var filteredProfiles = new List<Profile>();
            bool test = false;
            foreach (var p in profiles)
            {
                if (p.ServiceRequests.Count == 0)
                {
                    filteredProfiles.Add(p);
                    continue;
                }
                
                

                foreach (var sr in p.ServiceRequests)
                {
                    if (sr.ServiceID != serviceID)
                        test = true;
                    else if (sr.ServiceID == serviceID && sr.ProfileID == p.ProfileID)
                    {
                        test = false;
                        break;
                    }   
                }
                if (test == true)
                    filteredProfiles.Add(p);
            }
            var vm = new AddMembersVM();
            vm.Service = (service);
            vm.Profiles = filteredProfiles;
            return View(vm);
        }

        [HttpPost]
        public IActionResult AddMembers(AddMembersVM vm)
        {
            //TODO: Test this
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
