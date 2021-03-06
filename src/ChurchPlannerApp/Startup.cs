﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using ChurchPlannerApp.Repositories;
using Microsoft.EntityFrameworkCore;
using ChurchPlannerApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ChurchPlannerApp
{
    public class Startup
    {
        IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
            .Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDBContext>(opts =>
                opts.UseSqlServer(
                    Configuration["Data:ChurchPlanner:ConnectionString"]));

            services.AddDbContext<AppIdentityDBContext>(options => options.UseSqlServer(
                Configuration["Data:ChurchPlannerIdentity:ConnectionString"]));

            services.AddIdentity<MusicUser, IdentityRole>(options =>
            { options.Cookies.ApplicationCookie.LoginPath = "/Account/Login"; })
                .AddEntityFrameworkStores<AppIdentityDBContext>();




            //TODO Add Code here to connect to LocalDB
            services.AddMvc();

            services.AddTransient<IMessage, MessageRepository>();
            services.AddTransient<IProfile, ProfileRepository>();
            services.AddTransient<ISong, SongRepository>();
            services.AddTransient<IService, ServiceRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseIdentity();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            SeedData.EnsurePopulated(app);
        }
    }
}
