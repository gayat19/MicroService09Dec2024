﻿using ShoppingAPI.Exceptions;
using ShoppingAPI.Interfaces;
using ShoppingAPI.Models;

namespace ShoppingAPI.Services
{
    public class AuditLogService : IAuditLogService
    {
        static List<AuditLog> auditLogs = new List<AuditLog>();

        private int GenerateId()
        {
            if (auditLogs.Count == 0)
            {
                return 1;
            }
            return auditLogs.Max(a => a.Id) + 1;
        }
        public AuditLog AddAuditLog(AuditLog auditLog)
        {
            int aid = GenerateId();
            auditLog.Id = aid;
            auditLogs.Add(auditLog);
            return auditLog;
        }

        public bool Delete(DateTime date)
        {
            var logs = auditLogs.Where(a => a.ModifiedAt.Date < date.Date).ToList();
            if (logs.Count == 0)
            {
                return false;
            }
            auditLogs = auditLogs.Except(logs).ToList();
            return true;
        }

        public ICollection<AuditLog> GetLog()
        {
            if(auditLogs.Count == 0)
            {
                throw new RepositoryEmptyException("No logs found");
            }
            return auditLogs;
        }
    }
}