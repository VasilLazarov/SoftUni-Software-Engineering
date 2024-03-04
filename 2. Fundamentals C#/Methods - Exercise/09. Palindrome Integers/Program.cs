using System;
using System.Linq;

namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                string reversInput = string.Join("", input.Reverse());
                CheckIsNumPalindrome(input, reversInput);
                input = Console.ReadLine();
            }
        }
        static void CheckIsNumPalindrome(string input, string reversInput)
        {
            if (input == reversInput)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
