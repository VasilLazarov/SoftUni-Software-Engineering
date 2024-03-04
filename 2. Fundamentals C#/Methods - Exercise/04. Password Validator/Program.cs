using System;

namespace _04._Password_Validator
{
    internal class Program
    {
        static bool correctPass = true;
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            
            CheckLenght(password);
            CheckOnlyLettersAndDigits(password);
            CheckContainsAtLeastTwoDigits(password);
            if (correctPass)
            {
                Console.WriteLine("Password is valid");
            }

        }

        static bool CheckLenght(string password)
        {
            if(password.Length < 6 || password.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                correctPass = false;
                return false;
            }
            return true;
        }
        static bool CheckOnlyLettersAndDigits(string password)
        {
            foreach(char ch in password)
            {
                if (!char.IsLetterOrDigit(ch))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                    correctPass = false;
                    return false;
                }
            }
            return true;
        }
        static bool CheckContainsAtLeastTwoDigits(string password)
        {
            int digitCount = 0;
            foreach (char ch in password)
            {
                if (char.IsDigit(ch))
                {
                    digitCount++;
                }
            }
            if (digitCount >= 2)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Password must have at least 2 digits");
                correctPass = false;
                return false;
            }
        }
    }
}
