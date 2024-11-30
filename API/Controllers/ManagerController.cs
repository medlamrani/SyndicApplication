using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ManagerController(DataContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetManagers()
        {
            var manager = await context.Users
                    .Where(r => r.RoleId == 3)
                    .ToListAsync();

            return manager;
        }
    }
}