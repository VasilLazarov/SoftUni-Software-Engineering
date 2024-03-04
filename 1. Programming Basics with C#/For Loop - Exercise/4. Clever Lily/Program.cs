using System;

namespace _4._Clever_Lily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());
            int numOfToys = 0;
            int money = 0;
            int sum = 0;
            for(int x = 1; x <= age; x++)
            {
                if(x%2 != 0)
                {
                    numOfToys++;
                }
                else if(x%2 == 0)
                {
                    money += ((x * 5) -1);
                }
            }
            sum = money + numOfToys * toyPrice;
            
            if(sum >= price)
            {
                Console.WriteLine($"Yes! {sum - price:f2}");
            }
            else
            {
                Console.WriteLine($"No! {price - sum:f2}");
            }
        }
    }
}
