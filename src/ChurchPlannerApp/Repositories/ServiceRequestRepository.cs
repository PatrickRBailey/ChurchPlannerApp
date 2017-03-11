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
            throw new NotImplementedException();
        }

        public IQueryable<ServiceRequest> GetAllRequests()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ServiceRequest> GetPendingRequests()
        {
            throw new NotImplementedException();
        }

        public int Update(ServiceRequest serviceRequest)
        {
            throw new NotImplementedException();
        }

        //public IQueryable<ServiceRequest> GetAcceptedRequests()
        //{
        //    return context.Requests.Include(s => s.ServiceR).Include(p => p.ProfileR).Where(r => r.Is_Accepted == true);
        //}

        //public IQueryable<ServiceRequest> GetAllRequests()
        //{
        //    return context.Requests.Include(s => s.ServiceR).Include(p => p.ProfileR);
        //}

        //public IQueryable<ServiceRequest> GetPendingRequests()
        //{
        //    return context.Requests.Include(s => s.ServiceR).Include(p => p.ProfileR).Where(r => r.Is_Accepted == false);
        //}

        //public int Update(ServiceRequest sr)
        //{
        //    if (sr.ServiceRequestID == 0)
        //        context.Requests.Add(sr);
        //    else
        //        context.Requests.Update(sr);
        //    return context.SaveChanges();
        //}
    }
}
