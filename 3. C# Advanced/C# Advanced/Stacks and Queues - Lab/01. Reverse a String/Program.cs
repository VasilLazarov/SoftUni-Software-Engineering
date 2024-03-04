using System;
using System.Collections.Generic;

namespace _01._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> reversString = new Stack<char>();
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                reversString.Push(input[i]);
            }
            for (int i = 1; i <= input.Length; i++)
            {
                Console.Write(reversString.Pop());
            }
        }
    }
}
