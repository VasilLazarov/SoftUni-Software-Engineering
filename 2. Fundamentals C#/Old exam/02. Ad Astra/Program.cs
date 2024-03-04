using System;
using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([|#]{1})(?<name>[A-Za-z ]+)\1(?<date>\d{2}/\d{2}/\d{2})\1(?<calories>\d+)\1";
            Regex myregex = new Regex(pattern);
            int calories = 0;
            string text = Console.ReadLine();
            MatchCollection matches = myregex.Matches(text);
            foreach (Match match in matches)
            {
                calories += int.Parse(match.Groups["calories"].Value);
            }
            int days = calories / 2000;
            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach (Match match in matches)
            {
                Console.WriteLine($"Item: {match.Groups["name"].Value}, Best before: {match.Groups["date"].Value}, Nutrition: {match.Groups["calories"].Value}");
            }

        }
    }
}
