using System;

namespace more_ex._1._Back_To_The_Past
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double inheritedMoney = double.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            int neededMoney = 0;
            int theYearsOfIvan = 18;
            for (int x = 1800; x <= year; x++)
            {
                if(x % 2 == 0)
                {
                    neededMoney += 12000;
                }
                else
                {
                    neededMoney += 12000 + 50 * theYearsOfIvan;
                }
                theYearsOfIvan++;
            }
            if(inheritedMoney >= neededMoney)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {inheritedMoney - neededMoney:f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {neededMoney - inheritedMoney:f2} dollars to survive.");
            }
        }
    }
}
