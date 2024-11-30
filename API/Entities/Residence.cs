using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Residence
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int MangerId { get; set; }
        public required AppUser ManagerUser { get; set; }
    }
}