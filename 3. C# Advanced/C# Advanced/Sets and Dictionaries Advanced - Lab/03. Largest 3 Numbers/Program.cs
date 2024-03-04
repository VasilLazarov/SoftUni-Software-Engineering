using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            ints = ints.OrderByDescending(v => v).ToList();
            Console.WriteLine(String.Join(" ", ints.Take(3)));
        }
    }
}
