﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChurchPlannerApp.Repositories;
using ChurchPlannerApp.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ChurchPlannerApp.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private IProfile repository;
        public ProfileController(IProfile repo)
        {
            repository = repo;
        }
        // GET: /<controller>/
        [Authorize]
        public IActionResult AllMembers()
        {
            if (HttpContext.User.IsInRole("Leader"))
            {
                ViewBag.role = "Leader";
            }
            else if (HttpContext.User.IsInRole("Admin"))
                ViewBag.role = "Admin";

            else
            {
                return RedirectToAction("Login", "Account");
            }

            return View(repository.GetAllProfiles().ToList());

        }

        [HttpGet]

        //Add Code to attatch a MusicUser to a Profile
        public ViewResult AddProfile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProfile(Profile p)
        {
            var profile = new Profile {
                FName = p.FName,
                LName = p.LName,
                Type = p.Type,
                Email = p.Email,
                PhoneNum = p.PhoneNum,
                UserName = p.UserName,
                
            };

            repository.Update(profile);

            return RedirectToAction("AllMembers", "Profile");
        }
        public IActionResult RemoveProfile(int id)
        {
            Profile profile = (from p in repository.GetAllProfiles()
                               where p.ProfileID == id
                               select p).FirstOrDefault<Profile>();

            repository.Delete(profile);
            return RedirectToAction("AllMembers", "Profile");
        }

        [HttpGet]
        public ViewResult EditProfile(int id)
        {
            var profile = (from p in repository.GetAllProfiles()
                           where p.ProfileID == id
                           select p).FirstOrDefault<Profile>();
            return View(profile);
        }

        [HttpPost]
        public IActionResult EditProfile(Profile p)
        {

            repository.Update(p);

            return RedirectToAction("AllMembers", "Profile");
        }
    }
}
