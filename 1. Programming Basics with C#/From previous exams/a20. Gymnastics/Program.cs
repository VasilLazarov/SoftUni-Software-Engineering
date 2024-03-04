using System;

namespace a20._Gymnastics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string device = Console.ReadLine();
            double rating = 0;
            if(country == "Russia")
            {
                switch (device)
                {
                    case "ribbon":
                        rating = 9.100 + 9.400;
                        break;
                    case "hoop":
                        rating = 9.300 + 9.800;
                        break;
                    case "rope":
                        rating = 9.600 + 9.000;
                        break;
                }
            }
            else if(country == "Bulgaria")
            {
                switch (device)
                {
                    case "ribbon":
                        rating = 9.600 + 9.400;
                        break;
                    case "hoop":
                        rating = 9.550 + 9.750;
                        break;
                    case "rope":
                        rating = 9.500 + 9.400;
                        break;
                }
            }
            else if( country == "Italy")
            {
                switch (device)
                {
                    case "ribbon":
                        rating = 9.200 + 9.500;
                        break;
                    case "hoop":
                        rating = 9.450 + 9.350;
                        break;
                    case "rope":
                        rating = 9.700 + 9.150;
                        break;
                }
            }
            double percentage = ((20.000 - rating) / 20) * 100;
            Console.WriteLine($"The team of {country} get {rating:f3} on {device}.");
            Console.WriteLine($"{percentage:f2}%");
        }
    }
}
