using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\+\b(359)([' '-])(2)\2(\d{3})\2(\d{4})\b";
            string input = Console.ReadLine();
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            string[] matchesForPrint = matches
                .Cast<Match>()
                .Select(v => v.Value)
                .ToArray();
            Console.WriteLine(string.Join(", ", matchesForPrint));
        }
    }
}
