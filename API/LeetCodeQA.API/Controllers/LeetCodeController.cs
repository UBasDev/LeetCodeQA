using LeetCodeQA.API.Models;
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
        public string LongestCommonPrefix1(string[] strs)
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

        [HttpPost("valid-paranthesis1")]
        public bool ValidParanthesis1([FromBody] string s)
        {
            if (s.Length <= 1) return false;

            var stack = new Stack<char>() { };

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '{' || s[i] == '[')
                {
                    stack.Push(s[i]);
                }
                else if (stack.Count == 0) return false;
                else if (s[i] == ')' && stack.Pop() != '(')
                {
                    return false;
                }
                else if (s[i] == '}' && stack.Pop() != '{')
                {
                    return false;
                }
                else if (s[i] == ']' && stack.Pop() != '[')
                {
                    return false;
                }
            }
            return stack.Count == 0;
        }

        [HttpPost("merge-two-sorted-list1")]
        public ListNode MergeTwoSortedLists([FromBody] MergeTwoListsRequest requestBody)
        {
            var list1 = new ListNode();
            var list2 = new ListNode();

            list1.val = requestBody.List1[0];

            for (int i = 1; i < requestBody.List1.Length; i++)
            {
                list1 = new ListNode(requestBody.List1[i], list1);
            }

            list2.val = requestBody.List2[0];

            for (int i = 1; i < requestBody.List2.Length; i++)
            {
                list2 = new ListNode(requestBody.List2[i], list2);
            }
            return MergeTwoLists(list1, list2);
        }

        private static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null) return list2;
            if (list2 == null) return list1;

            var currentNode = new ListNode();

            var allValues = new List<int>();

            allValues.Add(list1.val);
            currentNode = list1.next;

            while (true)
            {
                if (currentNode == null) break;
                allValues.Add(currentNode.val);

                if (currentNode.next == null) break;

                currentNode = currentNode.next;
            }

            allValues.Add(list2.val);
            currentNode = list2.next;

            while (true)
            {
                if (currentNode == null) break;
                allValues.Add(currentNode.val);

                if (currentNode.next == null) break;

                currentNode = currentNode.next;
            }

            allValues.Sort((x, y) => y.CompareTo(x));

            var newListNode = new ListNode();

            for (int i = 0; i < allValues.Count; i++)
            {
                if (i == 0)
                {
                    newListNode.val = allValues[0];
                    continue;
                }
                newListNode = new ListNode(allValues[i], newListNode);
            }

            return newListNode;
        }

        [HttpGet("find-first-occurrence1")]
        public int FindFirstOccurrence1(string haystack, string needle)
        {
            if (haystack.Length < needle.Length) return -1;
            return haystack.IndexOf(needle);
        }

        [HttpGet("find-first-occurrence2")]
        public int FindFirstOccurrence2(string haystack, string needle)
        {
            if (haystack.Length < needle.Length) return -1;
            for (int i = 0; i < haystack.Length; i++)
            {
                if (i + needle.Length > haystack.Length) return -1;
                else if (haystack[i..(i + needle.Length)] == needle) return i;
            }
            return -1;
        }

        [HttpPost("search-insert-position")]
        public int SearchInsertPosition(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (target <= nums[i]) return i;
            }
            return nums.Length;
        }

        [HttpGet("length-of-last-word")]
        public int LengthOfLastWord(string s)
        {
            var trimmed = s.TrimEnd();
            if (trimmed.Length == 1) return 1;
            for (int i = trimmed.Length - 1; i >= 0; i--)
            {
                if (i == 0 || s[i - 1] == ' ') return trimmed.Length - i;
            }
            return 0;
        }

        [HttpGet("sqrt")]
        public int Sqrt1(int x)
        {
            if (x == 0 || x == 1) return x;
            for (double i = 2, j = x / 2; i <= x / 2 || j >= 0; i++, j--)
            {
                if (i * i > x) return Convert.ToInt32(i - 1);
                else if (j * j < x) return Convert.ToInt32(j);
            }
            return 0;
        }

        [HttpGet("climb-stairs")]
        public int ClimbStairs(int n)
        {
            if (n == 0 || n==1 || n==2) return n;
            var stairs = new int[n + 1];
            stairs[1] = 1;
            stairs[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                stairs[i] = stairs[i - 1] + stairs[i - 2];
            }
            return stairs[^1];
        }
    }
}