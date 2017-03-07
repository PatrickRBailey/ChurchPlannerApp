using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchPlannerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ChurchPlannerApp.Repositories
{
    public class ServiceRequestRepository : IServiceRequest
    {
        private ApplicationDBContext context;
        public ServiceRequestRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }

        public IQueryable<ServiceRequest> GetAcceptedRequests()
        {
            return context.Requests.Include(s => s.ServiceR).Include(p => p.ProfileR).Where(r => r.Is_Accepted == true);
        }

        public IQueryable<ServiceRequest> GetAllRequests()
        {
            return context.Requests.Include(s => s.ServiceR).Include(p => p.ProfileR);
        }

        public IQueryable<ServiceRequest> GetPendingRequests()
        {
            return context.Requests.Include(s => s.ServiceR).Include(p => p.ProfileR).Where(r => r.Is_Accepted == false);
        }
    }
}
