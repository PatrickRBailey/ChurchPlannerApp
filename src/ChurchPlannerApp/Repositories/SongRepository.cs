using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchPlannerApp.Models;

namespace ChurchPlannerApp.Repositories
{
    public class SongRepository : ISong
    {
        private ApplicationDBContext context;
        public SongRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Song> GetAllSongs()
        {
            return context.Songs;
        }
    }
}
