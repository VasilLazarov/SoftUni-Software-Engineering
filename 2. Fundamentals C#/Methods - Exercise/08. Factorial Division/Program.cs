using System;

namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            Console.WriteLine($"{FactorialFromNum(num1) / FactorialFromNum(num2):f2}");
        }

        static double FactorialFromNum(double num)
        {
            double factorial = 1;
            for (int i = 2; i <= num; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
