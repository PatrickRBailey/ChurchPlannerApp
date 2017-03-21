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
    [Authorize]
    public class ForumController : Controller
    {
        private IMessage repository;
        private UserManager<MusicUser> userManager;
        private IProfile pRepository;

        public ForumController(IMessage repo, IProfile prepo, UserManager<MusicUser>userMgr)
        {
            repository = repo;
            pRepository = prepo;
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
        public IActionResult NewMessageForm(Message m)
        {
            //TODO: Test this
            if (ModelState.IsValid)
            {
                var user = HttpContext.User.Identity.Name;
                Profile profile = (from p in pRepository.GetAllProfiles()
                                   where p.UserName == user
                                   select p).FirstOrDefault<Profile>();

                var message = new Message();
                message.MessageID = m.MessageID;
                message.Body = m.Body;
                message.Date = DateTime.Now;
                message.From = profile;


                repository.Update(message);

                return RedirectToAction("AllMessages", "Forum");
            }
            else
                return View();
        }

        [HttpGet]
        public ViewResult CommentForm(int id)
        {
            var commentVm = new CommentViewModel();
            commentVm.MessageID = id;
            commentVm.Comment = new Models.Comment();

            return View(commentVm);
        }

        [HttpPost]
        public IActionResult CommentForm(CommentViewModel commentVm)
        {
            //TODO: Test this

            if (ModelState.IsValid)
            {
                var user = HttpContext.User.Identity.Name;
                Profile profile = (from p in pRepository.GetAllProfiles()
                                   where p.UserName == user
                                   select p).FirstOrDefault<Profile>();

                Message message = (from m in repository.GetAllMessages()
                                   where m.MessageID == commentVm.MessageID
                                   select m).FirstOrDefault<Message>();

                Comment comment = new Comment();
                comment.Body = commentVm.Comment.Body;
                comment.Date = DateTime.Now;
                comment.From = profile;

                message.Comments.Add(comment);

                
                repository.Update(message);

                return RedirectToAction("AllMessages", "Forum");
            }
            else
                return View();
        }
        public IActionResult RemoveMessage(int id)
        {
            Message message = (from m in repository.GetAllMessages()
                               where m.MessageID == id
                               select m).FirstOrDefault<Message>(); 

            repository.Delete(message);
            return RedirectToAction("AllMessages", "Forum");
        }
    }
}
