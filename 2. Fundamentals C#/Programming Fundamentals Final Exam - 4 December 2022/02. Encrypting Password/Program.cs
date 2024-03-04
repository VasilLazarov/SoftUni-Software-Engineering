using System;
using System.Text.RegularExpressions;

namespace _02._Encrypting_Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            string pattern = @"^(.+)>(?<gr1>\d{3})([|])(?<gr2>[a-z]{3})\2(?<gr3>[A-Z]{3})\2(?<gr4>[^<>]{3})<\1$";
            Regex myRegex = new Regex(pattern);
            for (int i = 0; i < numberOfInputs; i++)
            {
                string input = Console.ReadLine();
                Match myMatch = myRegex.Match(input);
                if (myMatch.Success)
                {
                    string gr1 = myMatch.Groups["gr1"].Value;
                    string gr2 = myMatch.Groups["gr2"].Value;
                    string gr3 = myMatch.Groups["gr3"].Value;
                    string gr4 = myMatch.Groups["gr4"].Value;
                    Console.WriteLine($"Password: {gr1}{gr2}{gr3}{gr4}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
