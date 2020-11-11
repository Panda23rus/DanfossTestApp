using DanfossTestApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanfossTestApplication.Data
{
    public class TestApplicationDataContext : DbContext
    {
        public TestApplicationDataContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Link> Links { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>().ToTable("Equipments");
            modelBuilder.Entity<Note>().ToTable("Notes");
            modelBuilder.Entity<Link>().ToTable("Links");
        }
    }
}
