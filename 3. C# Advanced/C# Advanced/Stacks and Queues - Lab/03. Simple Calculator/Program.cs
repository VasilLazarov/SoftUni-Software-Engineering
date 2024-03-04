using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ');
            Array.Reverse(input);
            Stack<string> expression = new Stack<string>(input);
            int result = int.Parse(expression.Pop());
            while(expression.Count > 0)
            {
                char operation = char.Parse(expression.Pop());
                int currentNum = int.Parse(expression.Pop());
                if(operation == '+')
                {
                    result += currentNum;
                }
                else if(operation == '-')
                {
                    result -= currentNum;
                }
            }
            Console.WriteLine(result);
        }
    }
}
