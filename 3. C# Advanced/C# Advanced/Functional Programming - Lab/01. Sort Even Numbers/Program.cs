using System;
using System.Linq;

namespace _01._Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = v => int.Parse(v);
            Func<int, bool> evenOrNot = v => v % 2 == 0;
            int[] evenNumbers = Console.ReadLine()
                .Split(", ")
                .Select(parser)
                .Where(evenOrNot)
                .OrderBy(v => v)
                .ToArray();
            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
