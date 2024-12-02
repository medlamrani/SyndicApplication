using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class AppartementDto
    {
        public required string Number { get; set; }
        public required int ImmeubleId { get; set; }
    }
}