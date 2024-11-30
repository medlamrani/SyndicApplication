using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Immeuble
    {       
        public int Id { get; set; }
        public string Name { get; set; }
        public int ResidenceId { get; set; }

        // Navigation Properties
        public Residence Residence { get; set; }
        public ICollection<Appartement> Appartements { get; set; }

    }
}