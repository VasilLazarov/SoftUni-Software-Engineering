using System;
using System.Linq;

namespace _04._Word_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] wordsWithEverLetters = Console.ReadLine()
                .Split(" ")
                .Where(v => v.Length % 2 == 0)
                .ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, wordsWithEverLetters));


        }
    }
}
