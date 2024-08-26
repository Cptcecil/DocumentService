using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentService.Domain.Entities
{
    public class Document
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Size { get; set; }
        public required string StoragePath { get; set; }
        public Guid ExternalId { get; set; }
        public int CreatedBy { get; set; }
    }
}
