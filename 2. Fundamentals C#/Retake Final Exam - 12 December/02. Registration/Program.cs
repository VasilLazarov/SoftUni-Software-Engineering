using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace _02._Registration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string pattern = @"(U\$)(?<name>[A-Z]{1}[a-z]{2,})\1(P@\$)(?<password>[A-Za-z]{5,}\d+)\2";
            Regex myRegex = new Regex(pattern);
            int countOfSuccessReg = 0;
            for (int i = 1; i <= number; i++)
            {
                string input = Console.ReadLine();
                Match match = myRegex.Match(input);
                if (match.Success)
                {
                    Console.WriteLine("Registration was successful");
                    string username = match.Groups["name"].Value;
                    string password = match.Groups["password"].Value;
                    Console.WriteLine($"Username: {username}, Password: {password}");
                    countOfSuccessReg++;
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
            Console.WriteLine($"Successful registrations: {countOfSuccessReg}");
        }
    }
}
