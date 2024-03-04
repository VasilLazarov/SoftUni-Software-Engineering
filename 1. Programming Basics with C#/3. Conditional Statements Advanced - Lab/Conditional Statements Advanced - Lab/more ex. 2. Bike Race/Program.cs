using System;

namespace more_ex._2._Bike_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfJuniors = int.Parse(Console.ReadLine());
            int numOfSeniors = int.Parse(Console.ReadLine());
            string typeOfRoute = Console.ReadLine();
            double priceForJuniors = 0;
            double priceForSeniors = 0;
            double totalPrice = 0;

            switch (typeOfRoute)
            {
                case "trail":
                    priceForJuniors = numOfJuniors * 5.50;
                    priceForSeniors = numOfSeniors * 7.00;
                    totalPrice = priceForJuniors + priceForSeniors;
                    break;
                case "cross-country":
                    priceForJuniors = numOfJuniors * 8.00;
                    priceForSeniors = numOfSeniors * 9.50;
                    totalPrice = priceForJuniors + priceForSeniors;
                    if((numOfJuniors + numOfSeniors) >= 50)
                    {
                        totalPrice -= totalPrice * 0.25;
                    }
                    break;
                case "downhill":
                    priceForJuniors = numOfJuniors * 12.25;
                    priceForSeniors = numOfSeniors * 13.75;
                    totalPrice = priceForJuniors + priceForSeniors;
                    break;
                case "road":
                    priceForJuniors = numOfJuniors * 20.00;
                    priceForSeniors = numOfSeniors * 21.50;
                    totalPrice = priceForJuniors + priceForSeniors;
                    break;
            }

            totalPrice -= totalPrice * 0.05;

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
