using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController(DataContext context, IUserRepository userRepository) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await userRepository.GetUsersAsync();
            return Ok(users);
        }  

        [HttpGet("admins")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAdmins()
        {
            var admin = await context.Users
                    .Where(r => r.RoleId == 1)
                    .ToListAsync();

            return admin;
        }  

        [HttpGet("managers")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetManagers()
        {
            var manager = await context.Users
                    .Where(r => r.RoleId == 2)
                    .ToListAsync();

            return manager;
        } 

        
        [HttpGet("{email}")]
        public async Task<ActionResult<MemberDto>> GetUser(string email)
        {
            var user = await userRepository.GetMemberAsync(email);

            if (user == null) return NotFound();

            return user;
        }   
    }
}