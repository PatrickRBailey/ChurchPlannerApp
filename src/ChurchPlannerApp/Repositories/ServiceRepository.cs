using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchPlannerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ChurchPlannerApp.Repositories
{
    public class ServiceRepository : IService
    {
        private ApplicationDBContext context;
        public ServiceRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Service> GetAllServices()
        {
            return context.Services;
        }
    }
}
