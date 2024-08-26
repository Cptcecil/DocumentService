using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentService.Application.DTOs
{
    public class CreateUserDto
    {
        public required string Email { get; set; }
        public required int OrganizationId { get; set; }
    }
}
