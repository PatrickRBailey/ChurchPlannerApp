using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChurchPlannerApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using ChurchPlannerApp.Models;
using Microsoft.AspNetCore.Identity;

namespace ChurchPlannerApp.Controllers
{
    public class ForumController : Controller
    {
        private IMessage repository;
        private UserManager<MusicUser> userManager;

        public ForumController(IMessage repo, UserManager<MusicUser>userMgr)
        {
            repository = repo;
            userManager = userMgr;
        }
        // GET: /<controller>/
        public ViewResult AllMessages()
        {
            return View(repository.GetAllMessages().ToList());
        }

        [HttpGet]
        public ViewResult NewMessageForm()
        {
            var message = new Models.Message();
            return View(message);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> NewMessageForm(Message m)
        {
            if (ModelState.IsValid)
            {
                var message = new Message();
                message.MessageID = m.MessageID;
                message.Body = m.Body;
                message.Date = DateTime.Now;

                string name = HttpContext.User.Identity.Name;
                message.From = await userManager.FindByNameAsync(name);
                repository.Update(message);

                return RedirectToAction("AllMessages", "Forum");
            }
            else
                return View();
        }
    }
}
