using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = "user";

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();        
    }
}