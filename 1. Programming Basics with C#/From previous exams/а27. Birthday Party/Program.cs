using System;

namespace а27._Birthday_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double hallPrice = double.Parse(Console.ReadLine());
            double cakePrice = hallPrice * 0.20;
            double drinks = cakePrice * 0.55;
            double animator = hallPrice / 3;
            double totalPrice = hallPrice + cakePrice + drinks + animator;
            Console.WriteLine(totalPrice);
        }
    }
}
