using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration.Models.Client
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options) : base (options)
        {

        }

        public DbSet<table1> table1 { get; set; }
        public DbSet<table2> table2 { get; set; }

        
    }
}
