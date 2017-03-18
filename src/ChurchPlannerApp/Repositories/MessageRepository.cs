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
            return context.Messages.Include(m => m.From).Include(c => c.Comments);
        }
        public int Update(Message message)
        {
            if (message.MessageID == 0)
                context.Messages.Add(message);
            else
                context.Messages.Update(message);

            return context.SaveChanges();

        }
    }
}
