using System;
using System.Collections.Generic;
using System.Security;

namespace _03._Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> synonyms 
                = new Dictionary<string, List<string>>();
            int numberOfWords = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberOfWords; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();
                if (!synonyms.ContainsKey(word))
                {
                    synonyms.Add(word, new List<string>());
                }
                synonyms[word].Add(synonym);
            }
            foreach (var word in synonyms)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
            }
        }
    }
}
