namespace API.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public required string RoleName { get; set; }
        public List<AppUser> Users { get; set; } = [];
    }
}