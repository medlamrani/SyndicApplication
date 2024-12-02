namespace API.Entities
{
    public class Residence
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Immeuble> Immeubles { get; set; } = [];
        public int ManagerId { get; set; }
        public AppUser Manager { get; set; } = null!;
    }
}