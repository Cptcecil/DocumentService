﻿using DocumentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentService.Application.Interfaces
{
    public interface IAuditLogService
    {
        Task LogAsync(AuditLog auditLog);
    }
}
