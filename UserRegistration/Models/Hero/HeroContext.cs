﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration.Models
{
    public class HeroContext :DbContext
    {
        public HeroContext(DbContextOptions<HeroContext> options) : base(options)
        {
            
    }

        public DbSet<Heros> Heros { get; set; }
    }
}
