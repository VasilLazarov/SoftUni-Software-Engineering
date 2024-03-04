using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] inputSequence = input
                .ToCharArray();
            Stack<char> openParentheses = new Stack<char>();
            for (int i = 0; i < inputSequence.Length; i++)
            {
                char currentParenthese = inputSequence[i];
                switch (currentParenthese)
                {
                    case '(':
                    case '[':
                    case '{':
                        openParentheses.Push(currentParenthese);
                        break;
                    case ')':
                        if (!openParentheses.Any() || openParentheses.Pop() != '(')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                    case ']':
                        if (!openParentheses.Any() || openParentheses.Pop() != '[')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                    case '}':
                        if (!openParentheses.Any() || openParentheses.Pop() != '{')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;

                }
            }
            if (openParentheses.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
