using System;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> numberOfLetters = new Dictionary<char, int>();
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                char currentSymbol = input[i];
                if(currentSymbol == ' ')
                {
                    continue;
                }
                if (!numberOfLetters.ContainsKey(currentSymbol))
                {
                    numberOfLetters.Add(currentSymbol, 0);
                }
                numberOfLetters[currentSymbol]++;
            }
            foreach (var currentLetter in numberOfLetters)
            {
                Console.WriteLine($"{currentLetter.Key} -> {currentLetter.Value}");
            }
        }
    }
}
