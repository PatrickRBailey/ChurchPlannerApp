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
        private AppIdentityDBContext IDContext;

        public AccountController(UserManager<MusicUser> userMgr,
            SignInManager<MusicUser> signInMgr, ApplicationDBContext ctx, AppIdentityDBContext Ictx)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            context = ctx;
            IDContext = Ictx;
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
                    PhoneNumber = vm.PhoneNum,
                    
                    
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
                        Type = "Musician",
                        User = user
                    };
                    context.Profiles.Add(profile);
                    context.SaveChanges();
                    await userManager.AddToRoleAsync(user, "Musician");
                    if (result.Succeeded)
                    
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

        [Authorize(Roles = "Admin")]
        public IActionResult AdminRegister()
        {
            var vm = new RegisterViewModel();
            ViewBag.roles = IDContext.Roles.ToList();

            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminRegister(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                MusicUser user = new MusicUser
                {
                    UserName = vm.UserName,
                    Email = vm.Email,
                    PhoneNumber = vm.PhoneNum,


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
                        Type = vm.UserRole,
                        User = user
                    };
                    context.Profiles.Add(profile);
                    context.SaveChanges();
                    await userManager.AddToRoleAsync(user, vm.UserRole);
                    if (result.Succeeded)

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
            ViewBag.roles = IDContext.Roles.ToList();
            return View(vm);
        }


        [AllowAnonymous]
        public ViewResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                MusicUser user =
                    await userManager.FindByNameAsync(vm.UserName);
                if (user != null)
                {
                    await signInManager.SignOutAsync();

                    Microsoft.AspNetCore.Identity.SignInResult result =
                        await signInManager.PasswordSignInAsync(
                            user, vm.Password, false, false);
                    if (result.Succeeded)

                    {
                        
                        return RedirectToAction("Index", "Home");
  
                    }

                }
                ModelState.AddModelError("", "Invalid name or password");
            }

            return View(vm);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }


    }
}
