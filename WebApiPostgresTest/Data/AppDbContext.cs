using Microsoft.EntityFrameworkCore;

namespace WebApiPostgresTest.Data
{
    public class AppDbContext: DbContext
    {
        protected readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Connect to postgres with connection string from app settings
            options.UseNpgsql(_configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
