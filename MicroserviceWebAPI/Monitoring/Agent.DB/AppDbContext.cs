using System;
using Agent.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agent.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            /*
             * Создает таблицы если их нету.
             * TODO: Убрать для Prod и оставить для Dev
             */
        }

        public DbSet<CpuMetric> CpuMetrics { get; set; }
        public DbSet<NetworkMetric> NetworkMetrics { get; set; }
        public DbSet<RamMetric> RamMetrics { get; set; }
        public DbSet<HddMetric> HddMetrics { get; set; }
        public DbSet<DotNetMetric> DotNetMetrics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            System.Console.WriteLine("Seed");
            
            modelBuilder.Entity<CpuMetric>().HasData(
                new CpuMetric { Id = 1, Time = DateTime.Now, Value = 100 },
                new CpuMetric { Id = 2, Time = DateTime.Now.AddMinutes(1), Value = 100 },
                new CpuMetric { Id = 3, Time = DateTime.Now.AddMinutes(2), Value = 101 },
                new CpuMetric { Id = 4, Time = DateTime.Now.AddMinutes(3), Value = 102 },
                new CpuMetric { Id = 5, Time = DateTime.Now.AddMinutes(4), Value = 103 }
            );
            
            modelBuilder.Entity<DotNetMetric>().HasData(
                new DotNetMetric { Id = 1, Time = DateTime.Now, Value = 100 },
                new DotNetMetric { Id = 2, Time = DateTime.Now.AddMinutes(1), Value = 100 },
                new DotNetMetric { Id = 3, Time = DateTime.Now.AddMinutes(2), Value = 101 },
                new DotNetMetric { Id = 4, Time = DateTime.Now.AddMinutes(3), Value = 102 },
                new DotNetMetric { Id = 5, Time = DateTime.Now.AddMinutes(4), Value = 103 }
            );
            
            modelBuilder.Entity<HddMetric>().HasData(
                new HddMetric { Id = 1, Time = DateTime.Now, Value = 100 },
                new HddMetric { Id = 2, Time = DateTime.Now.AddMinutes(1), Value = 100 },
                new HddMetric { Id = 3, Time = DateTime.Now.AddMinutes(2), Value = 101 },
                new HddMetric { Id = 4, Time = DateTime.Now.AddMinutes(3), Value = 102 },
                new HddMetric { Id = 5, Time = DateTime.Now.AddMinutes(4), Value = 103 }
            );
            
            modelBuilder.Entity<NetworkMetric>().HasData(
                new NetworkMetric { Id = 1, Time = DateTime.Now, Value = 100 },
                new NetworkMetric { Id = 2, Time = DateTime.Now.AddMinutes(1), Value = 100 },
                new NetworkMetric { Id = 3, Time = DateTime.Now.AddMinutes(2), Value = 101 },
                new NetworkMetric { Id = 4, Time = DateTime.Now.AddMinutes(3), Value = 102 },
                new NetworkMetric { Id = 5, Time = DateTime.Now.AddMinutes(4), Value = 103 }
            );
            
            modelBuilder.Entity<RamMetric>().HasData(
                new RamMetric { Id = 1, Time = DateTime.Now, Value = 100 },
                new RamMetric { Id = 2, Time = DateTime.Now.AddMinutes(1), Value = 100 },
                new RamMetric { Id = 3, Time = DateTime.Now.AddMinutes(2), Value = 101 },
                new RamMetric { Id = 4, Time = DateTime.Now.AddMinutes(3), Value = 102 },
                new RamMetric { Id = 5, Time = DateTime.Now.AddMinutes(4), Value = 103 }
            );
        }
    }
}