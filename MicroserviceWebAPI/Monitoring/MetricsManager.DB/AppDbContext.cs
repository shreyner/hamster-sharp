using MetricsManager.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetricsManager.DB
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            /*
             * Создает таблицы если их нету.
             * TODO: Убрать для Prod и оставить для Dev
             */
            // Database.EnsureCreated();
        }
        
        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}