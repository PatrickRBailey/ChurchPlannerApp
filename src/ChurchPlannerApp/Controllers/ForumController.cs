using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChurchPlannerApp.Repositories;

namespace ChurchPlannerApp.Controllers
{
    public class ForumController : Controller
    {
        private IMessage repository;

        public ForumController(IMessage repo)
        {
            repository = repo;
        }
        // GET: /<controller>/
        public ViewResult AllMessages()
        {
            return View(repository.GetAllMessages().ToList());
        }
    }
}
