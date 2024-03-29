﻿using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
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
    }
}
