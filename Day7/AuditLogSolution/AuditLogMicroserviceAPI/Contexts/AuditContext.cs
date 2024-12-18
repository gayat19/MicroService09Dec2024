using Microsoft.EntityFrameworkCore;

namespace AuditLogMicroserviceAPI.Contexts
{
    public class AuditContext : DbContext
    {
        public AuditContext(DbContextOptions<AuditContext> options) : base(options)
        {
        }

        public DbSet<AuditLogMicroserviceAPI.Models.AuditLog> AuditLogs { get; set; }
    }
}
