using System;
using System.Linq;

namespace Test_last_ex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] condenced = new int[nums.Length - 1];

            while (nums.Length > 1)
            {
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    condenced[i] = nums[i] + nums[i + 1];
                    if (i == condenced.Length - 1)
                    {
                        nums = condenced;
                        condenced = new int[nums.Length - 1];
                    }
                }
            }
            Console.WriteLine(nums[0]);
        }
    }
}
