using LeetCodeQA.API.Models;

namespace LeetCodeQA.API.Requests
{
    public class MergeTwoListsRequest
    {
        public MergeTwoListsRequest()
        {
            List1 = new int[] { };
            List2 = new int[] { };
        }

        public int[] List1 { get; set; }
        public int[] List2 { get; set; }
    }
}