﻿using ShoppingAPI.Interfaces;
using ShoppingAPI.Models;
using ShoppingAPI.Repositories;

namespace ShoppingAPI.Services
{
    public class AutidLogServiceV2 : IAuditLogService
    {
        private readonly IRepository<AuditLog, int> _auditLogRepository;

        public AutidLogServiceV2(IRepository<AuditLog,int> auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }
        public AuditLog AddAuditLog(AuditLog auditLog)
        {
            var log = _auditLogRepository.Add(auditLog);
            return log;
        }

        public bool Delete(DateTime date)
        {
            var logs = _auditLogRepository.Get().Where(a => a.ModifiedAt.Date <= date.Date).ToList();
            if (logs.Count == 0)
            {
                return false;
            }
            foreach (var log in logs)
            {
                _auditLogRepository.Delete(log.LogId);
            }
            return true;
        }

        public ICollection<AuditLog> GetLog()
        {
            var logs = _auditLogRepository.Get();
            return logs;
        }
    }
}