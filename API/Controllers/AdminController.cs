using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AdminController(DataContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAdmins()
        {
            var admin = await context.Users
                    .Where(r => r.RoleId == 3)
                    .ToListAsync();

            return admin;
        }
    }
}