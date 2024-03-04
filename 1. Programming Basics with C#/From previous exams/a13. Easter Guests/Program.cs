using System;

namespace a13._Easter_Guests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfGuests = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double easterBread = Math.Ceiling(numOfGuests/3.0);
            int eggs = numOfGuests * 2;
            double totalPrice = easterBread * 4 + eggs * 0.45;
            if(budget >= totalPrice)
            {
                Console.WriteLine($"Lyubo bought {easterBread} Easter bread and {eggs} eggs.");
                Console.WriteLine($"He has {budget - totalPrice:f2} lv. left.");
            }
            else
            {
                Console.WriteLine($"Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {totalPrice - budget:f2} lv. more.");
            }
        }
    }
}
