using System;
using System.Collections.Generic;
using System.Linq;

namespace _02EnterNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            ReadNumber(1, 100, numbers);
            
            Console.WriteLine(String.Join(", ", numbers));
        }

        static void ReadNumber(int start, int end, List<int> numbers)
        {
            while(numbers.Count < 10)
            {
                if (numbers.Any())
                {
                    start = numbers.Max();
                }
                try
                {
                    int currentNumber = int.Parse(Console.ReadLine());
                    if (currentNumber <= start || currentNumber >= end)
                    {
                        throw new ArgumentException($"Your number is not in range {start} - 100!");
                    }
                    numbers.Add(currentNumber);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
