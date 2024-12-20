using AuditLogMicroserviceAPI.Contexts;
using AuditLogMicroserviceAPI.Models;

namespace AuditLogMicroserviceAPI.Repositories
{
    public class AuditLogRepository : Repository<AuditLog, int>
    {

        public AuditLogRepository(AuditContext shoppingContext)
        {
            _auditContext = shoppingContext;
        }
        public override ICollection<AuditLog> Get()
        {
            var auditLogs = _auditContext.AuditLogs.ToList();
            if (auditLogs.Count == 0)
            {
                throw new Exception("No logs found");
            }
            return auditLogs;
        }
        
    }

}
