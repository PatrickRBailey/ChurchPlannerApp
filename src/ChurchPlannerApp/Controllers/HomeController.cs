using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChurchPlannerApp.Repositories;
using ChurchPlannerApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace ChurchPlannerApp.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<MusicUser> userManager;
        private SignInManager<MusicUser> signInManager;
        private IProfile Prepository;
        private IService Srepository;
         
        

        public HomeController(IProfile Prepo, IService Srepo, UserManager<MusicUser>usrMgr, SignInManager<MusicUser>signInMgr)

        {
            Prepository = Prepo;
            Srepository = Srepo;
            userManager = usrMgr;
            signInManager = signInMgr;
        }
        [Authorize]
        public ViewResult Index()
        {
            var user = HttpContext.User.Identity.Name;
            var vm = new ProfileServiceViewModel();
            Profile profile = (from p in Prepository.GetAllProfiles()
                               where p.UserName == user
                               select p).FirstOrDefault<Profile>();

            vm.Profile = profile;
            vm.Services = Srepository.GetAllServices().ToList();

            return View(vm);
        }
        

    }
}
