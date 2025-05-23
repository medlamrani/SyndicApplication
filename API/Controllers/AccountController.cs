using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController(DataContext context, ITokenService tokenService) : BaseApiController
    {
        [HttpPost("register")]//account/register
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Email)) return BadRequest("This email is already associed with an account!");
            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                FullName = registerDto.Fullname,
                Email = registerDto.Email.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,
                RoleId = registerDto.Role,
            };


            context.Users.Add(user);
            await context.SaveChangesAsync();

            return new UserDto {
                FullName = user.FullName,
                Email = user.Email,
                Token = tokenService.CreateToken(user),
                RoleId = user.RoleId
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => 
                    x.Email == loginDto.Email.ToLower());
            if (user == null) return Unauthorized("invalid Email");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if(computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return new UserDto 
            {
                FullName = user.FullName,
                Email = user.Email,
                Token = tokenService.CreateToken(user),
                RoleId = user.RoleId
            };
        }

        private async Task<bool> UserExists(string email)
        {
            return await context.Users.AnyAsync(x => x.Email.ToLower() == email.ToLower());
        }
    }
}