using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ChurchPlannerApp.Models;
using System;

namespace ChurchPlannerApp.Repositories
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDBContext context = app.ApplicationServices.GetRequiredService<ApplicationDBContext>();

            if (!context.Messages.Any())
            {
                //TODO Create appsettings.json and add connection string
                Profile profile = new Profile { FName = "Johnny", LName = "Rocket" };
                context.Profiles.Add(profile);

                Service service = new Models.Service
                {
                    Title = "Sunday Morning",
                    PracticeDate = DateTime.Parse("3/7/2017")
                ,
                    ServiceDate = DateTime.Parse("3/9/2017")
                };
                service.Team.Add(profile);
                context.Services.Add(service);

                Message message = new Message { Body = "How is everyone doing today?", From = profile };
                context.Messages.Add(message);
                message = new Message {Body = "Is there practice this week?", From = profile };
                context.Messages.Add(message);

                profile = new Profile { FName = "Bob", LName = "Loblaw" };
                context.Profiles.Add(profile);

                message = new Message {Body = "Can anyone play this week?", From = profile };
                context.Messages.Add(message);
                message = new Message { Body = "This site is so fun!!", From = profile };
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
