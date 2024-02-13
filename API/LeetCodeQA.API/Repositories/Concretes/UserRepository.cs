using LeetCodeQA.API.Contexts;
using LeetCodeQA.API.Entities;
using LeetCodeQA.API.Repositories.Abstracts;
using LeetCodeQA.API.Requests;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LeetCodeQA.API.Repositories.Concretes
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task CreateSingleUserAsync(User newUser) => await _context.Users.AddAsync(newUser);

        public async Task<bool> FindAnyByCondition(Expression<Func<User, bool>> condition) => await _context.Users.AnyAsync(condition);

        public async Task<List<User>> GetAllUsersAsync() => await _context.Users.ToListAsync();

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
