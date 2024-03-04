using System;

namespace cda_more_ex._10._Multiply_by_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double i = double.Parse(Console.ReadLine());
            while(i >= 0)
            {
                Console.WriteLine($"Result: {i * 2:f2}");
                i = double.Parse(Console.ReadLine());

            }
            Console.WriteLine("Negative number!");
        }

    }
}
