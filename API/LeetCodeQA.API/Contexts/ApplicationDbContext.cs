using LeetCodeQA.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeetCodeQA.API.Contexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
    }
}
