using LeetCodeQA.API.Entities;
using LeetCodeQA.API.Requests;
using System.Linq.Expressions;

namespace LeetCodeQA.API.Repositories.Abstracts
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task CreateSingleUserAsync(User newUser);
        Task<bool> FindAnyByCondition(Expression<Func<User, bool>> condition);
        Task SaveChangesAsync();
    }
}
