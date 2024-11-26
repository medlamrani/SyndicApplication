using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository(DataContext context, IMapper mapper) : IUserRepository
    {
        public async Task<MemberDto?> GetMemberAsync(string email)
        {
            return await context.Users
                .Where(e => e.Email == email)
                .ProjectTo<MemberDto>(mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<AppUser?> GetUserByEmailAsync(string email)
        {
            return await context.Users
                .Include(x => x.Role)
                .SingleOrDefaultAsync(e => e.Email == email);
        }

        public async Task<AppUser?> GetUserByIdAsync(int id)
        {
            return await context.Users.FindAsync(id);
        }
        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await context.Users
                    .ProjectTo<AppUser>(mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0; 
        }
    }
}