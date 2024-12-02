namespace API.Entities
{
    public class Immeuble
    {       
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ResidenceId { get; set; }
        public Residence Residence { get; set; } = null!;
        public ICollection<Appartement> Appartements { get; set; } = [];

    }
}