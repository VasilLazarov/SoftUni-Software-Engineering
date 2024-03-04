using System;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            double result = 0;
            string next = "";
            while (next != "end")
            {
                
                double num1 = double.Parse(Console.ReadLine());
                string operation = Console.ReadLine();
                
                if (operation == "sqrt")
                {
                    result = Math.Sqrt(num1);
                    Console.WriteLine(result);
                    next = Console.ReadLine();
                }
                else
                {
                    double num2 = double.Parse(Console.ReadLine());
                    switch (operation)
                    {
                        case "+":
                            result = num1 + num2;
                            Console.WriteLine(result);
                            next = Console.ReadLine();
                            break;
                        case "-":
                            result = num1 - num2;
                            Console.WriteLine(result);
                            next = Console.ReadLine();
                            break;
                        case "*":
                            result = num1 * num2;
                            Console.WriteLine(result);
                            next = Console.ReadLine();
                            break;
                        case "/":
                            result = num1 / num2;
                            Console.WriteLine(result);
                            next = Console.ReadLine();
                            break;
                        case "^":
                            result = Math.Pow(num1, num2);
                            Console.WriteLine(result);
                            next = Console.ReadLine();
                            break;
                    }
                }
                
                
            }

        }
    }
}
