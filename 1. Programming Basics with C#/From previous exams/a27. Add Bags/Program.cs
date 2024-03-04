using System;

namespace a27._Add_Bags
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceOfLuggageOver20kg = double.Parse(Console.ReadLine());
            double luggageKG = double.Parse(Console.ReadLine());
            int dayToTrip = int.Parse(Console.ReadLine());
            int numOfLuggages = int.Parse(Console.ReadLine());
            double priceOfLuggageUnder10kg = priceOfLuggageOver20kg * 0.20;
            double priceOfLuggageBetween10kgAnd20kg = priceOfLuggageOver20kg / 2;
            double totalPrice = 0;
            if(dayToTrip > 30)
            {
                priceOfLuggageOver20kg += priceOfLuggageOver20kg * 0.10;
                priceOfLuggageUnder10kg += priceOfLuggageUnder10kg * 0.10;
                priceOfLuggageBetween10kgAnd20kg += priceOfLuggageBetween10kgAnd20kg * 0.10;

            }
            else if(dayToTrip <= 30 && dayToTrip >= 7)
            {
                priceOfLuggageOver20kg += priceOfLuggageOver20kg * 0.15;
                priceOfLuggageUnder10kg += priceOfLuggageUnder10kg * 0.15;
                priceOfLuggageBetween10kgAnd20kg += priceOfLuggageBetween10kgAnd20kg * 0.15;
            }
            else
            {
                priceOfLuggageOver20kg += priceOfLuggageOver20kg * 0.40;
                priceOfLuggageUnder10kg += priceOfLuggageUnder10kg * 0.40;
                priceOfLuggageBetween10kgAnd20kg += priceOfLuggageBetween10kgAnd20kg * 0.40;
            }

            if(luggageKG > 20)
            {
                totalPrice = priceOfLuggageOver20kg * numOfLuggages;
            }
            else if(luggageKG < 10)
            {
                totalPrice = priceOfLuggageUnder10kg * numOfLuggages;

            }
            else
            {
                totalPrice = priceOfLuggageBetween10kgAnd20kg * numOfLuggages;
            }

            Console.WriteLine($"The total price of bags is: {totalPrice:f2} lv.");
        }
    }
}
