using System;

namespace _09._Sum_of_Odd_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int v = int.Parse(Console.ReadLine());
            int sum = 0;
            int printNumber = 1;

            for(int i = 1; i <= v; i++)
            {
                Console.WriteLine(printNumber);
                sum += printNumber;
                printNumber += 2;

            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
