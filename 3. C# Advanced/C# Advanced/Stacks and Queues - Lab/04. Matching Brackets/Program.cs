using System;
using System.Collections.Generic;

namespace _04._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> operBracketIndexes = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    operBracketIndexes.Push(i);
                }
                else if(input[i] == ')')
                {
                    int startIndex = operBracketIndexes.Pop();
                    string forPrint = input.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(forPrint);
                }
            }
        }
    }
}
