using ShoppingAPI.Models;

namespace ShoppingAPI.Interfaces
{
    public interface IAuditLogService
    {
        public AuditLog AddAuditLog(AuditLog auditLog);
        public ICollection<AuditLog> GetLog();
        public bool Delete(DateTime date);
    }
}
