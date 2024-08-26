using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentService.Domain.Entities
{
    public class AuditLog
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Action { get; set; } // "Create" or "Update"
        public string EntityName { get; set; } // Name of the entity being modified
        public string EntityId { get; set; } // ID of the entity
        public string Username { get; set; } // User who performed the action
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string Changes { get; set; } // JSON string of the changes
    }
}
