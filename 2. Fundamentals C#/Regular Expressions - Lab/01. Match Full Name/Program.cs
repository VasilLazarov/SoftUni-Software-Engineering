using System;
using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b([A-Z]{1}[a-z]{1,})+[' ']([A-Z]{1}[a-z]{1,})\b";
            string input = Console.ReadLine();
            Regex regex = new Regex(pattern);
            MatchCollection names = regex.Matches(input);
            foreach (Match name in names)
            {
                Console.Write(name.Value + " ");
            }


        }
    }
}
