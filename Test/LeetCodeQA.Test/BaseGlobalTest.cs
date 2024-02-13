using LeetCodeQA.API.Controllers;
using LeetCodeQA.API.Entities;
using Moq;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http.Json;

namespace LeetCodeQA.Test
{
    public class BaseGlobalTest(CreateWebApplicationFactory factory) : IClassFixture<CreateWebApplicationFactory>
    {
        protected HttpClient HttpClient { get; init; } = factory.CreateClient();
    }
    /*
    public class GlobalTests : IDisposable
    {
        private CreateWebApplicationFactory _factory;
        private HttpClient _client;
        public GlobalTests()
        {
            _factory = new CreateWebApplicationFactory();
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetAllUsersIntegrationTest()
        {
            var mockUsers = new List<User>()
            {
                new(){ Id=Guid.NewGuid(), Username="test1", Email="test1@gmail.com" },
                new(){ Id=Guid.NewGuid(), Username="test2", Email="test2@gmail.com" },
                new(){ Id=Guid.NewGuid(), Username = "test3", Email = "test3@gmail.com" }
            };

            _factory.UserRepositoryMock.Setup(u => u.GetAllUsersAsync()).ReturnsAsync(mockUsers);
            var response = await _client.GetAsync("api/users/get-all-users");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var deserializedResponse = JsonConvert.DeserializeObject<List<User>>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(deserializedResponse);
            Assert.NotEmpty(deserializedResponse);
            Assert.Collection(
                deserializedResponse,
                r =>
                {
                    Assert.Equal("test1", r.Username);
                    Assert.Equal("test1@gmail.com", r.Email);
                },
                r =>
                {
                    Assert.Equal("test2", r.Username);
                    Assert.Equal("test2@gmail.com", r.Email);
                },
                r =>
                {
                    Assert.Equal("test3", r.Username);
                    Assert.Equal("test3@gmail.com", r.Email);
                }
            );
            _factory.UserRepositoryMock.VerifyAll();
        }

        [Fact]
        public async Task CreateSingleUserIntegrationTest()
        {
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                Username = "test1",
                Email = "test1@gmail.com"
            };
            _factory.UserRepositoryMock.Setup(u => u.CreateSingleUserAsync(It.Is<User>(u => u.Username == newUser.Username && u.Email == newUser.Email))).Verifiable();

            _factory.UserRepositoryMock.Setup(r => r.SaveChangesAsync()).Verifiable();
            var response = await _client.PostAsync("api/users/create-single-user", JsonContent.Create(newUser));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var stringResponse = await response.Content.ReadAsStringAsync();
            Assert.NotNull(stringResponse);
            _factory.UserRepositoryMock.VerifyAll();
        }

        [Fact]
        public async Task GetAllUsersUnitTest()
        {
            var mockUsers = new List<User>()
            {
                new(){ Id=Guid.NewGuid(), Username="test1", Email="test1@gmail.com" },
                new(){ Id=Guid.NewGuid(), Username="test2", Email="test2@gmail.com" },
                new(){ Id=Guid.NewGuid(), Username = "test3", Email = "test3@gmail.com" }
            };
            _factory.UserRepositoryMock.Setup(u => u.GetAllUsersAsync()).ReturnsAsync(mockUsers);
            var controller = new UsersController(_factory.UserRepositoryMock.Object);
            var handlerResponse = controller.GetAllUsers();
            var results = handlerResponse.Result;
            Assert.NotNull(results);
            Assert.NotEmpty(results);
            Assert.Collection(
                results,
                r =>
                {
                    Assert.Equal("test1", r.Username);
                    Assert.Equal("test1@gmail.com", r.Email);
                },
                r =>
                {
                    Assert.Equal("test2", r.Username);
                    Assert.Equal("test2@gmail.com", r.Email);
                },
                r =>
                {
                    Assert.Equal("test3", r.Username);
                    Assert.Equal("test3@gmail.com", r.Email);
                }
            );
            _factory.UserRepositoryMock.VerifyAll();
        }
        public void Dispose()
        {
            _client.Dispose();
            _factory.Dispose();
        }
    }
    */
}