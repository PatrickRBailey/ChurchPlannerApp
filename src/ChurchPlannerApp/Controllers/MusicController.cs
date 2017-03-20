using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChurchPlannerApp.Repositories;
using ChurchPlannerApp.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ChurchPlannerApp.Controllers
{
    public class MusicController : Controller
    {
        private ISong repository;

        public MusicController(ISong repo)
        {
            repository = repo;
        }
        // GET: /<controller>/
        public ViewResult AllSongs()
        {
            return View(repository.GetAllSongs().ToList());
        }

        [HttpGet]
        public ViewResult AddSong()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSong(Song s)
        {
            if (ModelState.IsValid)
            {
                var song = new Song
                {
                    Title = s.Title,
                    Url = s.Url
                };
                repository.Update(song);

                return RedirectToAction("AllSongs", "Music");
            }
            else
                return View();
        }


        public IActionResult RemoveSong(int id)
        {
            Song song = (from s in repository.GetAllSongs()
                         where s.SongID == id
                         select s).FirstOrDefault<Song>();
            repository.Delete(song);
            return RedirectToAction("AllSongs", "Music");
        }

        [HttpGet]
        public ViewResult EditSong(int id)
        {
            var song = (from s in repository.GetAllSongs()
                        where s.SongID == id
                        select s).FirstOrDefault<Song>();
            return View(song);
        }

        [HttpPost]
        public IActionResult EditSong(Song s)
        {
            
            repository.Update(s);

            return RedirectToAction("AllSongs", "Music");
        }

    }
}
