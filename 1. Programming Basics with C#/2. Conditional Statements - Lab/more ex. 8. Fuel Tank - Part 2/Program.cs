using System;

namespace more_ex._8._Fuel_Tank___Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeFuel = Console.ReadLine();
            double fuelLiters = double.Parse(Console.ReadLine());
            string clubCard = Console.ReadLine();
            double priceGasoline = 2.22;
            double priceDiesel = 2.33;
            double priceGas = 0.93;
            double priceGasolineWithCard = 2.04;
            double priceDieselWithCard = 2.21;
            double priceGasWithCard = 0.85;
            double total;
            if(fuelLiters < 20)
            {
                if(clubCard == "Yes")
                {
                    switch (typeFuel)
                    {
                        case "Gasoline":
                            total = fuelLiters * priceGasolineWithCard;
                            Console.WriteLine($"{total:f2} lv.");
                            break;
                        case "Diesel":
                            total = fuelLiters * priceDieselWithCard;
                            Console.WriteLine($"{total:f2} lv.");
                            break;
                        case "Gas":
                            total = fuelLiters * priceGasWithCard;
                            Console.WriteLine($"{total:f2} lv.");
                            break;
                    }
                }
                else if(clubCard == "No")
                {
                    switch (typeFuel)
                    {
                        case "Gasoline":
                            total = fuelLiters * priceGasoline;
                            Console.WriteLine($"{total:f2} lv.");
                            break;
                        case "Diesel":
                            total = fuelLiters * priceDiesel;
                            Console.WriteLine($"{total:f2} lv.");
                            break;
                        case "Gas":
                            total = fuelLiters * priceGas;
                            Console.WriteLine($"{total:f2} lv.");
                            break;
                    }
                }
            }
            else if(fuelLiters >=20 && fuelLiters <= 25)
            {
                if (clubCard == "Yes")
                {
                    switch (typeFuel)
                    {
                        case "Gasoline":
                            total = (fuelLiters * priceGasolineWithCard) - (fuelLiters * priceGasolineWithCard * 0.08);
                            Console.WriteLine($"{total:f2} lv.");
                            break;
                        case "Diesel":
                            total = (fuelLiters * priceDieselWithCard) - (fuelLiters * priceDieselWithCard * 0.08);
                            Console.WriteLine($"{total:f2} lv.");
                            break;
                        case "Gas":
                            total = (fuelLiters * priceGasWithCard) - (fuelLiters * priceGasWithCard * 0.08);
                            Console.WriteLine($"{total:f2} lv.");
                            break;
                    }
                }
                else if (clubCard == "No")
                {
                    switch (typeFuel)
                    {
                        case "Gasoline":
                            total = (fuelLiters * priceGasoline) - (fuelLiters * priceGasoline * 0.08);
                            Console.WriteLine($"{total:f2} lv.");
                            break;
                        case "Diesel":
                            total = (fuelLiters * priceDiesel) - (fuelLiters * priceDiesel * 0.08);
                            Console.WriteLine($"{total:f2} lv.");
                            break;
                        case "Gas":
                            total = (fuelLiters * priceGas) - (fuelLiters * priceGas * 0.08);
                            Console.WriteLine($"{total:f2} lv.");
                            break;
                    }
                }
            }
            else if(fuelLiters > 25)
            {
                if (clubCard == "Yes")
                {
                    switch (typeFuel)
                    {
                        case "Gasoline":
                            total = (fuelLiters * priceGasolineWithCard) - (fuelLiters * priceGasolineWithCard * 0.10);
                            Console.WriteLine($"{total:f2} lv.");
                            break;
                        case "Diesel":
                            total = (fuelLiters * priceDieselWithCard) - (fuelLiters * priceDieselWithCard * 0.10);
                            Console.WriteLine($"{total:f2} lv.");
                            break;
                        case "Gas":
                            total = (fuelLiters * priceGasWithCard) - (fuelLiters * priceGasWithCard * 0.10);
                            Console.WriteLine($"{total:f2} lv.");
                            break;
                    }
                }
                else if (clubCard == "No")
                {
                    switch (typeFuel)
                    {
                        case "Gasoline":
                            total = (fuelLiters * priceGasoline) - (fuelLiters * priceGasoline * 0.10);
                            Console.WriteLine($"{total:f2} lv.");
                            break;
                        case "Diesel":
                            total = (fuelLiters * priceDiesel) - (fuelLiters * priceDiesel * 0.10);
                            Console.WriteLine($"{total:f2} lv.");
                            break;
                        case "Gas":
                            total = (fuelLiters * priceGas) - (fuelLiters * priceGas * 0.10);
                            Console.WriteLine($"{total:f2} lv.");
                            break;
                    }
                }
            }
        }
    }
}
