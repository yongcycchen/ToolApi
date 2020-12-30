using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToolApi.Entities;

namespace ToolApi.Data
{
    public class RoutineDbContext:DbContext
    {
        public RoutineDbContext(DbContextOptions<RoutineDbContext> options):base(options)
        {

        }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<ToolNotification> ToolNotifications { get; set; }
        public DbSet<ToolOwner> ToolOwners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tool>().Property(x => x.name).IsRequired();

            modelBuilder.Entity<Employee>().Property(x => x.FSID).IsRequired();

            modelBuilder.Entity<Employee>().HasKey(x => x.FSID);

            modelBuilder.Entity<ToolOwner>().HasKey(x => new { x.FSID, x.ToolID });

            modelBuilder.Entity<ToolNotification>().HasKey(x => new { x.FSID, x.ToolID });

            modelBuilder.Entity<ToolNotification>().Property(x => x.Email).IsRequired();

            //modelBuilder.Entity<Tool>().HasData();
        }
        
    }
}
