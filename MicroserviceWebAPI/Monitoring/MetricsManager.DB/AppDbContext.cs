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
    }
}