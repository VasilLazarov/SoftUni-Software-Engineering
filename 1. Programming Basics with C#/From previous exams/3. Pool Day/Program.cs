using System;

namespace _3._Pool_Day
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfPeoples = int.Parse(Console.ReadLine());
            double entranceFee = double.Parse(Console.ReadLine());
            double priceForDeckChair = double.Parse(Console.ReadLine());
            double priceForUmbrella = double.Parse(Console.ReadLine());
            double moneyForEntrance = numOfPeoples * entranceFee;
            double moneyForDeckChairs = (Math.Ceiling(numOfPeoples * 0.75)) * priceForDeckChair;
            double moneyForUmbrellas = (Math.Ceiling(numOfPeoples / 2.0)) * priceForUmbrella;
            double total = moneyForEntrance + moneyForDeckChairs + moneyForUmbrellas;
            Console.WriteLine($"{total:f2} lv.");
        }
    }
}
