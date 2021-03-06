﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchPlannerApp.Models;

namespace ChurchPlannerApp.Repositories
{
    public interface IMessage
    {
        IQueryable<Message> GetAllMessages();
        int Update(Message message);
        int Delete(Message message);
    }
}
