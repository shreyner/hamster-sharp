using MetricsManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetricsManager.DB
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<CpuMetric> CpuMetrics { get; set; }
        public DbSet<DotNetMetric> DotNetMetrics { get; set; }
        public DbSet<HddMetric> HddMetrics { get; set; }
        public DbSet<NetworkMetric> NetworkMetrics { get; set; }
        public DbSet<RamMetric> RamMetrics { get; set; }
    }
}