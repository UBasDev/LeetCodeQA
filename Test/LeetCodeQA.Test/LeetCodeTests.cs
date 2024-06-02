using FluentAssertions;
using LeetCodeQA.API.Requests;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeQA.Test
{
    public class LeetCodeTests(CreateWebApplicationFactory factory) : BaseGlobalTest(factory)
    {
        [Fact]
        public async Task TwoSum1()
        {
            var request = new int[] { 2, 7, 11, 15 }; //Numbers
            var target = 9; //Target
            var response = await HttpClient.PostAsJsonAsync($"api/leetcode/two-sum1?target={target}", request);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var responseToString = await response.Content.ReadAsStringAsync();
            responseToString.Should().NotBeNullOrEmpty();
            responseToString.Should().Be("[0,1]");
        }

        [Fact]
        public async Task TwoSum2()
        {
            var request = new int[] { 2, 7, 11, 15 }; //Numbers
            var target = 9; //Target
            var response = await HttpClient.PostAsJsonAsync($"api/leetcode/two-sum2?target={target}", request);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var responseToString = await response.Content.ReadAsStringAsync();
            responseToString.Should().NotBeNullOrEmpty();
            responseToString.Should().Be("[0,1]");
        }

        [Fact]
        public async Task PalindromeNumber1()
        {
            var request = -121; //Palingdrom number
            var response = await HttpClient.PostAsJsonAsync("api/leetcode/palindrome-number1", request);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var responseToString = await response.Content.ReadAsStringAsync();
            responseToString.Should().NotBeNullOrEmpty();
            responseToString.Should().Be("true");
        }

        [Fact]
        public async Task RomanToInteger1()
        {
            var romanString = "MCMXCIV"; //Roman string
            var response = await HttpClient.GetAsync($"api/leetcode/roman-to-integer1?romanString={romanString}");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var responseToString = await response.Content.ReadAsStringAsync();
            responseToString.Should().NotBeNullOrEmpty();
            responseToString.Should().Be("1994");
        }

        [Fact]
        public async Task LongestCommonPrefix1()
        {
            var wordArray = new string[] { "flower", "fluid", "flood" };
            var response = await HttpClient.PostAsJsonAsync($"api/leetcode/longest-common-prefix1", wordArray);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var responseToString = await response.Content.ReadAsStringAsync();
            responseToString.Should().NotBeNullOrEmpty();
            responseToString.Should().Be("fl");
        }

        [Fact]
        public async Task ValidParanthesis1()
        {
            var word = "({[]})";
            var response = await HttpClient.PostAsJsonAsync($"api/leetcode/valid-paranthesis1", word);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var responseToString = await response.Content.ReadAsStringAsync();
            responseToString.Should().NotBeNullOrEmpty();
            responseToString.Should().Be("true");
        }

        [Fact]
        public async Task MergeTwoSortedLists()
        {
            var requestBody = new MergeTwoListsRequest()
            {
                List1 = new int[] { 1, 2, 4 },
                List2 = new int[] { 1, 3, 4 }
            };
            var response = await HttpClient.PostAsJsonAsync($"api/leetcode/merge-two-sorted-list1", requestBody);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var responseToString = await response.Content.ReadAsStringAsync();
            responseToString.Should().NotBeNullOrEmpty();
            responseToString.Should().Be("{}");
        }

        [Fact]
        public async Task FindFirstOccurrence1()
        {
            var haystack = "sadbutsad";
            var needle = "but";
            var response = await HttpClient.GetAsync($"api/leetcode/find-first-occurrence1?haystack={haystack}&needle={needle}");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var responseToString = await response.Content.ReadAsStringAsync();
            responseToString.Should().NotBeNullOrEmpty();
            responseToString.Should().Be("3");
        }

        [Fact]
        public async Task FindFirstOccurrence2()
        {
            var haystack = "sadbutsad";
            var needle = "but";
            var response = await HttpClient.GetAsync($"api/leetcode/find-first-occurrence2?haystack={haystack}&needle={needle}");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var responseToString = await response.Content.ReadAsStringAsync();
            responseToString.Should().NotBeNullOrEmpty();
            responseToString.Should().Be("3");
        }

        [Fact]
        public async Task SearchInsertPosition()
        {
            var nums = new int[] { 1, 3, 5, 6 };
            var target = 7;
            var response = await HttpClient.PostAsJsonAsync($"api/leetcode/search-insert-position?target={target}", nums);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var responseToString = await response.Content.ReadAsStringAsync();
            responseToString.Should().NotBeNullOrEmpty();
            responseToString.Should().Be("4");
        }

        [Fact]
        public async Task LengthOfLastWord()
        {
            var text = "   fly me   to   the moon  ";
            var response = await HttpClient.GetAsync($"api/leetcode/length-of-last-word?s={text}");

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var responseToString = await response.Content.ReadAsStringAsync();
            responseToString.Should().NotBeNullOrEmpty();
            responseToString.Should().Be("4");
        }

        [Fact]
        public async Task Sqrt()
        {
            var number = "8";
            var response = await HttpClient.GetAsync($"api/leetcode/sqrt?x={number}");

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var responseToString = await response.Content.ReadAsStringAsync();
            responseToString.Should().NotBeNullOrEmpty();
            responseToString.Should().Be("2");
        }
    }
}