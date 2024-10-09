using Microsoft.EntityFrameworkCore;

namespace MovieSearchLogs.Models
{
    public class LogContext : DbContext
    {
        public LogContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Log> Logs { get; set; }
    }
}
