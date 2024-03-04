using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split("|")
                .ToArray();
            List<int> result = new List<int>();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                char[] separator = { ' ' };
                List<int> sepNums = input[i]
                    .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
                result.AddRange(sepNums);
            }
            Console.WriteLine(String.Join(" ", result));
        }
    }
}
