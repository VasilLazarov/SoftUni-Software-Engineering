using System;
using System.Collections.Generic;

namespace _02._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .ToLower()
                .Split();
            Dictionary<string, int> words = new Dictionary<string, int>();
            for (int i = 0; i < input.Length; i++)
            {
                string currentWord = input[i];
                if (!words.ContainsKey(currentWord))
                {
                    words.Add(currentWord, 1);
                }
                else
                {
                    words[currentWord]++;
                }
            }
            List<string> oddWords = new List<string>();
            foreach (var word in words)
            {
                if(word.Value % 2 != 0)
                {
                    oddWords.Add(word.Key);
                }
            }
            Console.WriteLine(string.Join(" ", oddWords));
        }
    }
}
