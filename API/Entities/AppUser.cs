namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required byte[] PasswordHash { get; set; }
        public required byte[] PasswordSalt { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
    }
}