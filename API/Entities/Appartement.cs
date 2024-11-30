using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Appartement
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int ImmeubleId { get; set; }

        // Navigation Property
        public Immeuble Immeuble { get; set; }
    }
}