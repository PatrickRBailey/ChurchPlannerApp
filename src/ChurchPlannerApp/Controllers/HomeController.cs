﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


// TODO: Create Nav functionality
namespace ChurchPlannerApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
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
