using System;

namespace _1._Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeProjection = Console.ReadLine();
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int numOfSeats = r * c;
            double totalPrice = 0;
            switch (typeProjection)
            {
                case "Premiere":
                    totalPrice = numOfSeats * 12.00;
                    break;
                case "Normal":
                    totalPrice = numOfSeats * 7.50;
                    break;
                case "Discount":
                    totalPrice = numOfSeats * 5.00;
                    break;
            }
            Console.WriteLine($"{totalPrice:f2} leva");
        }
    }
}
