using System;
using System.Security.Cryptography;

namespace _10._Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                bool check1 = CheckSumOfDigits(i);
                bool check2 = CheckHaveNumberOddDigit(i);
                if(check1 && check2)
                {
                    Console.WriteLine(i);
                }
            }
        }
        static bool CheckSumOfDigits(int i)
        {
            int sumOfDigits = 0;
            int constantI = i;
            for (int v = 0; v < constantI.ToString().Length; v++)
            {
                sumOfDigits += (i%10);
                i /= 10;
            }
            if(sumOfDigits % 8 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool CheckHaveNumberOddDigit(int i)
        {
            bool trueOrFalse = false;
            int constantI = i;
            foreach (char ch in constantI.ToString())
            {
                int digit = int.Parse(ch.ToString());
                if(digit % 2 != 0)
                {
                    trueOrFalse = true;
                    break;
                }
            }
            return trueOrFalse;
        }
    }
}
