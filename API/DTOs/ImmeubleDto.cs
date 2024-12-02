using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ImmeubleDto
    {
        public required string Name { get; set; }
        public required int ResidenceId { get; set; }
    }
}