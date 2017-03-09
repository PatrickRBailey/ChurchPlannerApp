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

        public int Delete(Service service)
        {
            context.Services.Remove(service);
            return context.SaveChanges();
        }

        public IQueryable<Service> GetAllServices()
        {
            return context.Services;
        }

        public int Update(Service service)
        {
            if (service.ServiceID == 0)
                context.Services.Add(service);
            else
                context.Services.Update(service);

            return context.SaveChanges();
        }
    }
}
