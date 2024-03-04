using System;

namespace _6._Operations_Between_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            string evenOrOdd = "even";
            double result = 0;
            switch (operation)
            {
                case '+':
                    result = num1 + num2;
                    if(result % 2 != 0)
                    {
                        evenOrOdd = "odd";
                    }
                    Console.WriteLine($"{num1} + {num2} = {result} - {evenOrOdd}");
                    break;
                case '-':
                    result = num1 - num2;
                    if (result % 2 != 0)
                    {
                        evenOrOdd = "odd";
                    }
                    Console.WriteLine($"{num1} - {num2} = {result} - {evenOrOdd}");
                    break;
                case '*':
                    result = num1 * num2;
                    if (result % 2 != 0)
                    {
                        evenOrOdd = "odd";
                    }
                    Console.WriteLine($"{num1} * {num2} = {result} - {evenOrOdd}");
                    break;
                case '/':
                    if(num1 == 0)
                    {
                        Console.WriteLine($"Cannot divide {num1} by zero");
                        return;
                    }
                    result = (double)num1 / num2;
                    Console.WriteLine($"{num1} / {num2} = {result:f2}");
                    break;
                case '%':
                    if (num1 == 0)
                    {
                        Console.WriteLine($"Cannot divide {num1} by zero");
                        return;
                    }
                    result = num1 % num2;
                    Console.WriteLine($"{num1} % {num2} = {result}");
                    break;
            }
        }
    }
}
