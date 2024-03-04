using System;

namespace _07._Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int liters = 0;
            int litersInTank = 0;
            for (int i = 0; i < num; i++)
            {
                liters = int.Parse(Console.ReadLine());
                if(litersInTank + liters <= 255)
                {
                    litersInTank += liters;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine(litersInTank);

        }
    }
}
