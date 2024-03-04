using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> checker = v => v[0] == v.ToUpper()[0];
            string[] wordsWithUpperFirstLetter = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(v => checker(v))
                .ToArray();
            Console.WriteLine(string.Join(System.Environment.NewLine, wordsWithUpperFirstLetter));

        }
    }
}
