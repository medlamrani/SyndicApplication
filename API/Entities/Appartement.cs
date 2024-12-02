namespace API.Entities
{
    public class Appartement
    {
        public int Id { get; set; }
        public required string Number { get; set; }
        public int ImmeubleId { get; set; }
        public Immeuble Immeuble { get; set; } = null!;
    }
}