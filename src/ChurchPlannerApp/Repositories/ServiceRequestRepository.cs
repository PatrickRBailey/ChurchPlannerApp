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
        public IQueryable<ServiceRequest> GetAllRequests()
        {
            return context.Requests;
        }
    }
}
