using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day13.Models;
using Microsoft.EntityFrameworkCore;

namespace Day13.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
