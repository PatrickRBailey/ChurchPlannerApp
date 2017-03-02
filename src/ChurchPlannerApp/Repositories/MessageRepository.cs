using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchPlannerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ChurchPlannerApp.Repositories
{
    public class MessageRepository : IMessage
    {
        private ApplicationDBContext context;
        public MessageRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Message> GetAllMessages()
        {
            return context.Messages.Include(m => m.From);
        }
    }
}
