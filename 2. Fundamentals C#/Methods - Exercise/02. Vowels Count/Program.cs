using System;

namespace _02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(CalculateTheNumberOfVowels(input));
        }

        static int CalculateTheNumberOfVowels(string input)
        {
            int count = 0;
            char[] inputText = input.ToLower().ToCharArray();
            char[] symbols = { 'a', 'e', 'u', 'y', 'o', 'i'};
            for (int i = 0; i < inputText.Length; i++)
            {
                for (int v = 0; v < symbols.Length; v++)
                {
                    if (inputText[i] == symbols[v])
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
