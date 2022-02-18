using Microsoft.EntityFrameworkCore;
using Timesheets.DB.Entities;

namespace Timesheets.DB;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }
}
