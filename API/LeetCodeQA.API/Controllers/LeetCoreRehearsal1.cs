using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace LeetCodeQA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeetCoreRehearsal1 : ControllerBase
    {
        [HttpPost("two-sum")]
        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target) return new int[] { i, j };
                }
            }
            return new int[] { };
        }

        [HttpPost("palindrome")]
        public bool Palindrome(int x)
        {
            if (x < 0) return false;

            var asString = x.ToString().ToArray();

            var reversedString = new char[asString.Length];

            for (int i = asString.Length - 1, j = 0; i >= 0; i--, j++)
            {
                reversedString[j] = asString[i];
            }
            if (asString.SequenceEqual(reversedString)) return true;
            var x1 = reversedString.ToArray();
            return false;
        }

        [HttpPost("roman-to-integer")]
        public int RomanToInteger(string s)
        {
            var dictionary = new Dictionary<char, int>() {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };
            var totalValue = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                totalValue += dictionary[s[i]] < dictionary[s[i + 1]] ? -dictionary[s[i]] : dictionary[s[i]];
            }
            return totalValue + dictionary[s[s.Length - 1]];
        }
    }
}