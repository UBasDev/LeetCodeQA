using LeetCodeQA.API.Contexts;
using LeetCodeQA.API.Entities;
using LeetCodeQA.API.Repositories.Abstracts;
using LeetCodeQA.API.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeetCodeQA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserRepository userRepository) : ControllerBase
    {
        private readonly IUserRepository _userRepository = userRepository;
        [HttpPost("create-single-user")]
        public async Task<string> CreateSingleUser([FromBody] CreateSingleUserRequest requestBody)
        {
            try
            {
                if (string.IsNullOrEmpty(requestBody.Username))
                {
                    Response.StatusCode = 400;
                    return "Kullanıcı adı zorunludur!";
                }
                if (string.IsNullOrEmpty(requestBody.Email))
                {
                    Response.StatusCode = 400;
                    return "Email zorunludur!";
                }
                var isUsernameAlreadyExist = await _userRepository.FindAnyByCondition(u => u.Username == requestBody.Username);
                if (isUsernameAlreadyExist)
                {
                    Response.StatusCode = 400;
                    return "Bu username zaten mevcut";
                };
                var isEmailAlreadyExist = await _userRepository.FindAnyByCondition(u => u.Email == requestBody.Email);
                if (isEmailAlreadyExist)
                {
                    Response.StatusCode = 400;
                    return "Bu email zaten mevcut";
                }
                var userToCreate = new User()
                {
                    Email = requestBody.Email,
                    Username = requestBody.Username,
                };
                await _userRepository.CreateSingleUserAsync(userToCreate);
                await _userRepository.SaveChangesAsync();
                Response.StatusCode = 201;
                return $"Eklenen kullanıcı id: {userToCreate.Id}";
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return ex.Message;
            }
        }
        [HttpGet("get-all-users")]
        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsersAsync();
        }
    }
}
