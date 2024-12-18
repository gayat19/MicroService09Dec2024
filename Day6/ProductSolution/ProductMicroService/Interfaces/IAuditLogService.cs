using ProductMicroService.Models.DTOs;

namespace ProductMicroService.Interfaces
{
    public interface IAuditLogService
    {
        public Task<AuditLogDTO> LogAudit(AuditLogDTO auditLog);
    }
}
