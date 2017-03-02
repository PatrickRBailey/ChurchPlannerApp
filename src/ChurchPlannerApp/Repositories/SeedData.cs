using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ChurchPlannerApp.Models;

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

                context.SaveChanges();

            }
        }
    }
}
