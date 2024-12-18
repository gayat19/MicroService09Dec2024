using AuditLogMicroserviceAPI.Models;

namespace AuditLogMicroserviceAPI.Interfaces
{
    public interface IAuditLogService
    {
        public AuditLog AddAuditLog(AuditLog auditLog);
        public ICollection<AuditLog> GetLog();
        public bool Delete(DateTime date);
    }

}
