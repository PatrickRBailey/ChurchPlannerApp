﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchPlannerApp.Models;

namespace ChurchPlannerApp.Repositories
{
    public interface IServiceRequest
    {
        IQueryable<ServiceRequest> GetAllRequests();
        IQueryable<ServiceRequest> GetAcceptedRequests();
        IQueryable<ServiceRequest> GetPendingRequests();
        int Update(ServiceRequest serviceRequest);
    }
}
