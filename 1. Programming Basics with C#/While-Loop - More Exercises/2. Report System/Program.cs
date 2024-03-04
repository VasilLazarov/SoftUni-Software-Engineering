using System;

namespace _2._Report_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cel = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int price = 0;
            double collectedMoney = 0;
            int count = 0;
            int card = 0;
            int cash = 0;
            double sum1 = 0;
            double sum2 = 0;
            while (input != "End")
            {
                price = int.Parse(input);
                count++;
                if(count%2 == 0)
                {
                    if (price < 10)
                    {
                        Console.WriteLine($"Error in transaction!");
                    }
                    else
                    {
                        Console.WriteLine($"Product sold!");
                        sum1 += price;
                        card++;

                    }
                }
                else
                {
                    if (price > 100)
                    {
                        Console.WriteLine($"Error in transaction!");
                    }
                    else
                    {
                        Console.WriteLine($"Product sold!");
                        sum2 += price;
                        cash++;
                    }
                }
                collectedMoney = sum1 + sum2;

                if(collectedMoney >= cel)
                {
                    Console.WriteLine($"Average CS: {sum2 / cash:f2}");
                    Console.WriteLine($"Average CC: {sum1 / card:f2}");
                    return;
                }


                
                input = Console.ReadLine();
            }
            
            Console.WriteLine($"Failed to collect required money for charity.");
        }
    }
}
