using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Solsr.domains.Entities;

namespace Solsr.domains
{
    public class AppDB : DbContext
    {
        public AppDB(DbContextOptions<AppDB> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }

    }
}
