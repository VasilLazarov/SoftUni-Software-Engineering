using System;

namespace _09._Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uint startingYield = uint.Parse(Console.ReadLine());
            long totalSpice = 0;
            int days = 0;
            if(startingYield < 100)
            {
            }
            else
            {
                while (startingYield >= 100)
                {
                    days++;
                    totalSpice += ((long)startingYield - 26);
                    startingYield -= 10;
                }
                totalSpice -= 26;
            }
            Console.WriteLine($"{days}\n{totalSpice}");
        }
    }
}
