﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchPlannerApp.Models;

namespace ChurchPlannerApp.Repositories
{
    public interface ISong
    {
        IQueryable<Song> GetAllSongs();
        int Update(Song song);

        int Delete(Song song);

    }
}
