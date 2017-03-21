using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchPlannerApp.Models
{
    public class Song
    {
        public int SongID { get; set; }
        [Required (ErrorMessage ="You must enter the name of a song")]
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
