using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntranceMonitoring.Models;
using Microsoft.EntityFrameworkCore;

namespace EntranceMonitoring.Data
{
    public class MonitoringContext : DbContext
    {
        public MonitoringContext(DbContextOptions<MonitoringContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Registry> Registries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Building>().ToTable("Building");
            modelBuilder.Entity<Registry>().ToTable("Registry");
        }

    }
}
