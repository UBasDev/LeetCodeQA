using FluentAssertions;
using LeetCodeQA.API.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeQA.Test
{
    public class UserTests(CreateWebApplicationFactory factory) : BaseGlobalTest(factory)
    {
        [Fact]
        public async Task Should_Return_Bad_Request_When_Username_Is_Missing()
        {
            var request = new CreateSingleUserRequest()
            {
                Username = "",
                Email = "u1@gmail.com"
            };
            var response = await HttpClient.PostAsJsonAsync("api/users/create-single-user", request);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var responseToString = await response.Content.ReadAsStringAsync();
            //var responseAsJson = await response.Content.ReadFromJsonAsync<BaseResponse>();
            Assert.NotEmpty(responseToString);
            Assert.NotNull(responseToString);
        }

        [Fact]
        public async Task Should_Return_Bad_Request_When_Email_Is_Missing()
        {
            var request = new CreateSingleUserRequest()
            {
                Username = "u1",
                Email = ""
            };
            var response = await HttpClient.PostAsJsonAsync("api/users/create-single-user", request);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var responseToString = await response.Content.ReadAsStringAsync();

            Assert.NotEmpty(responseToString);
            Assert.NotNull(responseToString);
        }

        [Fact]
        public async Task Should_Return_Created_When_User_Is_Created()
        {
            var request = new CreateSingleUserRequest()
            {
                Username = "u1",
                Email = "u1@gmail.com"
            };
            var response = await HttpClient.PostAsJsonAsync("api/users/create-single-user", request);
            var responseToString = await response.Content.ReadAsStringAsync();

            responseToString.Should().NotBeEmpty();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

    }
}
