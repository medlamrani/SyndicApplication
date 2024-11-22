using System.Net.Http.Headers;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class RoleController(DataContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRole()
        {
            var roles = await context.Roles.Include(x => x.Users).ToListAsync();
            return roles;
        }

        [HttpPost("addrole")]
        public async Task<ActionResult<Role>> AddRole(string roleName)
        {
            var roleExist = await context.Roles.FirstOrDefaultAsync(x => x.RoleName == roleName);

            if (roleExist != null) return BadRequest("This Role already exist");

            var role = new Role 
            {
                RoleName = roleName
            };

            context.Roles.Add(role);
            await context.SaveChangesAsync();

            return role;
        }
    }
}