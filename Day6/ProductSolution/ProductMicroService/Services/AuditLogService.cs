using Newtonsoft.Json;
using ProductMicroService.Interfaces;
using ProductMicroService.Models.DTOs;

namespace ProductMicroService.Services
{
    public class AuditLogService : IAuditLogService
    {
        HttpClient _httpClient;
        public AuditLogService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<AuditLogDTO> LogAudit(AuditLogDTO auditLog)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5227/api/Audit", auditLog);
            if (response.IsSuccessStatusCode)
            {
                var responsedata = await response.Content.ReadAsStringAsync();
                var auditLogData = JsonConvert.DeserializeObject<AuditLogDTO>(responsedata);
                return auditLogData;
            }
            throw new Exception("Error while adding modification to auditlog");
        }
    }
}
