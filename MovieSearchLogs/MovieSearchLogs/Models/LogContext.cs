using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MovieSearchLogs.Models
{
    public class LogContext : DbContext
    {
        readonly string _connectionString;
        public LogContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DbCon");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        public DbSet<Log> Logs { get; set; }
    }
}
