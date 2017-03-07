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
        public int Update(Song song)
        {
            if (song.SongID == 0)
                context.Songs.Add(song);
            else
                context.Songs.Update(song);

            return context.SaveChanges();

        }

        public int Delete(Song s)
        {
            context.Songs.Remove(s);
            return context.SaveChanges();
        }

    }
}
