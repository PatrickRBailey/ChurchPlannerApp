﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchPlannerApp.Models
{
    public class ProfileServiceViewModel
    {
        public Profile Profile { get; set; }
        public List<Service> Services { get; set; }
    }
}
