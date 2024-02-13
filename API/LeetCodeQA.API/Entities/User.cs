using System.ComponentModel.DataAnnotations;

namespace LeetCodeQA.API.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
