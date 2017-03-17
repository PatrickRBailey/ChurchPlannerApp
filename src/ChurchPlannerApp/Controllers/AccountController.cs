using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ChurchPlannerApp.Models;
using ChurchPlannerApp.Repositories;
using System.Linq;

namespace ChurchPlannerApp.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<MusicUser> userManager;
        private SignInManager<MusicUser> signInManager;
        private ApplicationDBContext context;

        public AccountController(UserManager<MusicUser> userMgr,
            SignInManager<MusicUser> signInMgr, ApplicationDBContext ctx)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            context = ctx;
        }

        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                MusicUser user = new MusicUser
                {
                    UserName = vm.UserName,
                    Email = vm.Email,
                    PhoneNumber = vm.PhoneNum
                    
                };
                IdentityResult result = await userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    var profile = new Profile
                    {
                        FName = vm.FirstName,
                        LName = vm.LastName,
                        Email = user.Email,
                        PhoneNum = user.PhoneNumber,
                        UserName = user.UserName,
                        User = user
                    };
                    context.Profiles.Add(profile);
                    context.SaveChanges();
                    //await userManager.AddToRoleAsync(user, "Member");
                    //if (result.Succeeded)
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(vm);
        }


    }
}
