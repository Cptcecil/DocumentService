using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentService.Application.DTOs
{
    public class CreateDocumentDto
    {
        public required string Name { get; set; }
        public int Size { get; set; }
        public required string StoragePath { get; set; }
        public int CreatedBy { get; set; }
    }
}
