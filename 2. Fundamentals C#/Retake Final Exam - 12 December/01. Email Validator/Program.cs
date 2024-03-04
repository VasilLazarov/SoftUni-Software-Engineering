using System;

namespace _01._Email_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Complete")
            {
                string[] inputElements = input.Split(" ");
                string command = inputElements[0];
                if (command == "Make")
                {
                    string upOrLow = inputElements[1];
                    if (upOrLow == "Upper")
                    {
                        email = email.ToUpper();
                        Console.WriteLine(email);
                    }
                    else if (upOrLow == "Lower")
                    {
                        email = email.ToLower();
                        Console.WriteLine(email);
                    }
                }
                else if (command == "GetDomain")
                {
                    int countOfSymbols = int.Parse(inputElements[1]);
                    string domain = email.Substring(email.Length - countOfSymbols);
                    Console.WriteLine(domain);
                }
                else if (command == "GetUsername")
                {
                    if (email.Contains("@"))
                    {
                        string[] emailElements = email.Split('@');
                        string username = emailElements[0];
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                }
                else if (command == "Replace")
                {
                    char symbol = char.Parse(inputElements[1]);
                    email = email.Replace(symbol, '-');
                    Console.WriteLine(email);
                }
                else if (command == "Encrypt")
                {
                    char[] lettersOfEmail = email.ToCharArray();
                    int valueOfSymbol = lettersOfEmail[0];
                    string encrypt = valueOfSymbol.ToString();
                    for (int i = 1; i < lettersOfEmail.Length; i++)
                    {
                        valueOfSymbol = lettersOfEmail[i];
                        encrypt += $" {valueOfSymbol}";
                    }
                    Console.WriteLine(encrypt);
                }
            }
        }
    }
}