using LeetCodeQA.API.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace LeetCodeQA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeetCodeController : ControllerBase
    {
        [HttpPost("two-sum1")]
        public int[]? TwoSum1(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var total = nums[i] + nums[j];
                    if (total == target) return new int[] { i, j };
                }
            }
            return null;
        }

        [HttpPost("two-sum2")]
        public int[]? TwoSum2(int[] nums, int target)
        {
            var matched = new Dictionary<int, int>(); //Number-Indice
            for (int i = 0; i < nums.Length; i++)
            {
                if (matched.ContainsKey(target - nums[i])) return new int[] { matched[target - nums[i]], i };
                else matched.TryAdd(nums[i], i);
            }
            return null;
        }

        [HttpPost("palindrome-number1")]
        public bool PalindromeNumber1(int number)
        {
            var convertToCharArray = Math.Abs(number).ToString().ToCharArray();
            var reversedCharArray = new char[convertToCharArray.Length];
            for (int i = convertToCharArray.Length - 1, j = 0; i >= 0; i--, j++)
            {
                reversedCharArray[j] = convertToCharArray[i];
            }
            return convertToCharArray.SequenceEqual(reversedCharArray);
        }

        [HttpGet("roman-to-integer1")]
        public int RomanToInteger1(string romanString)
        {
            var romanDictionary = new Dictionary<char, int>()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 },
            };
            var totalValue = 0;
            for (int i = 0; i < romanString.Length - 1; i++)
            {
                var currentValue = romanDictionary[romanString[i]];
                totalValue += (currentValue >= romanDictionary[romanString[i + 1]] ? 1 : -1) * currentValue;
            }
            return totalValue + romanDictionary[romanString[romanString.Length - 1]];
        }

        [HttpPost("longest-common-prefix1")]
        public string LongestCommonPrefix(string[] strs)
        {
            Array.Sort(strs, (x, y) => x.Length.CompareTo(y.Length));

            var shortestWord = strs[0];

            var currentPrefix = string.Empty;
            for (int i = 0; i < shortestWord.Length; i++)
            {
                var isExistForAll = true;
                for (int j = 1; j < strs.Length; j++)
                {
                    if (shortestWord[i] != strs[j][i])
                    {
                        isExistForAll = false;
                        break;
                    }
                }
                if (!isExistForAll) break;
                else currentPrefix += shortestWord[i];
            }

            return currentPrefix;
        }
    }
}