using System;

namespace _1._Dishwasher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bottles = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int preparation = bottles * 750;
            int dishes = 0;
            int count = 0;
            int sum1 = 0;
            int sum2 = 0;
            while(input != "End")
            {
                dishes = int.Parse(input);
                count++;
                if(count%3 == 0)
                {
                    preparation -= dishes * 15;
                    sum2 += dishes;
                }
                else
                {
                    preparation -= dishes * 5;
                    sum1 += dishes;
                }
                if(preparation < 0)
                {
                    Console.WriteLine($"Not enough detergent, {Math.Abs(preparation)} ml. more necessary!");
                    return;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Detergent was enough!");
            Console.WriteLine($"{sum1} dishes and {sum2} pots were washed.");
            Console.WriteLine($"Leftover detergent {preparation} ml.");
        }
    }
}
