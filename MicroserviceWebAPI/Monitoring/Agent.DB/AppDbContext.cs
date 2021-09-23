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
    }
}