using LeetCodeQA.API.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Testcontainers.PostgreSql;

namespace LeetCodeQA.Test
{
    public class CreateWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
            .WithImage("postgres:latest")
            .WithDatabase("LeetCodeQATest")
            .WithUsername("postgres")
            .WithPassword("admin")
            .WithCleanUp(true)
            .Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<ApplicationDbContext>));
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseNpgsql(_dbContainer.GetConnectionString());

                });
            });
        }

        public async Task InitializeAsync()
        {
            await _dbContainer.StartAsync();
            using var scope = Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await dbContext.Database.MigrateAsync();
        }

        public new Task DisposeAsync()
        {
            return _dbContainer.StopAsync();
        }

        /*
        public Mock<IUserRepository> UserRepositoryMock { get; }
        public Mock<UsersController> UsersController { get; }
        public CreateWebApplicationFactory()
        {
            UserRepositoryMock = new Mock<IUserRepository>();
        }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            builder.ConfigureTestServices(services =>
            {
                services.AddSingleton(UserRepositoryMock.Object);
            });
        }
        */
    }
}
