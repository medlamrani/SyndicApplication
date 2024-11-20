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
            var roles = await context.Roles.ToListAsync();
            return roles;
        }
    }
}