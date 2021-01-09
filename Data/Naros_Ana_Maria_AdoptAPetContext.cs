using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Naros_Ana_Maria_AdoptAPet.Models;

namespace Naros_Ana_Maria_AdoptAPet.Data
{
    public class Naros_Ana_Maria_AdoptAPetContext : DbContext
    {
        public Naros_Ana_Maria_AdoptAPetContext (DbContextOptions<Naros_Ana_Maria_AdoptAPetContext> options)
            : base(options)
        {
        }

        public DbSet<Naros_Ana_Maria_AdoptAPet.Models.Pet> Pet { get; set; }

        public DbSet<Naros_Ana_Maria_AdoptAPet.Models.Location> Location { get; set; }

        public DbSet<Naros_Ana_Maria_AdoptAPet.Models.Category> Category { get; set; }
    }
}
