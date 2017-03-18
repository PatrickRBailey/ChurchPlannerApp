using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ChurchPlannerApp.Models;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ChurchPlannerApp.Repositories
{
    public static class SeedData
    {
        public static async Task EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDBContext context = app.ApplicationServices.GetRequiredService<ApplicationDBContext>();

            string firstName = "Patrick";
            string lastName = "Bailey";
            string username = "patrickb";
            string email = "patrickbailey13@gmail.com";
            string password = "Fancy123!";
            string role = "Admin";

            UserManager<MusicUser> userManager = app.ApplicationServices.GetRequiredService<UserManager<MusicUser>>();
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();


            if (!context.Messages.Any())
            {
                MusicUser user = await userManager.FindByNameAsync(username);
                if (user ==null)
                {
                    user = new MusicUser { UserName = username, Email = email };
                    IdentityResult result = await userManager.CreateAsync(user, password);

                    if (await roleManager.FindByNameAsync(role) == null)
                    {
                        await roleManager.CreateAsync(new IdentityRole("Admin"));
                        await roleManager.CreateAsync(new IdentityRole("Musician"));
                        await roleManager.CreateAsync(new IdentityRole("Leader"));

                        if(result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, role);
                        }
                    }
                    
                }
                Profile profile = new Profile { FName = firstName, LName = lastName, UserName = username, Email = email, User = user };
                context.Profiles.Add(profile);

                Service service = new Models.Service
                {
                    Title = "Sunday Morning",
                    PracticeDate = DateTime.Parse("3/7/2017")
                ,
                    ServiceDate = DateTime.Parse("3/9/2017")
                    
                };
                context.Services.Add(service);

                service = new Models.Service
                {
                    Title = "Saturday Night",
                    PracticeDate = DateTime.Parse("3/11/2017")
                ,
                    ServiceDate = DateTime.Parse("3/15/2017")

                };

                context.Services.Add(service);

                Message message = new Message { Body = "Is there practice this week?", From = profile };
                Comment comment = new Comment { Body = "Yep", From = profile };
                message.Comments.Add(comment);
                context.Messages.Add(message);


                Song song = new Song { Title = "How Great Is Our God", Url = "https://youtu.be/KBD18rsVJHk" };
                context.Songs.Add(song);

                song = new Song { Title = "From The Day", Url = "https://youtu.be/TUjuRFwwvaw" };
                context.Songs.Add(song);

                song = new Song { Title = "Lift Your Head Weary Sinners", Url = "https://youtu.be/xPpEOUVpxrM" };
                context.Songs.Add(song);

                song = new Song { Title = "How He Loves", Url = "https://youtu.be/Plngh8SkkA4" };
                context.Songs.Add(song);

                
                


                context.SaveChanges();

            }
        }
    }
}
