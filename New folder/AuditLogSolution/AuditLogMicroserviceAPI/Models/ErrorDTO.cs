namespace AuditLogMicroserviceAPI.Models
{
    public class ErrorDTO
    {
        public int ErrorNumber { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
