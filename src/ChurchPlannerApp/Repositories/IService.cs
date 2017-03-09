using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchPlannerApp.Models;

namespace ChurchPlannerApp.Repositories
{
    public interface IService
    {
        IQueryable<Service> GetAllServices();
        int Update(Service service);
        int Delete(Service service);
    }
}
