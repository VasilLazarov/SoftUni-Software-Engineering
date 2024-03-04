using System;

namespace more_ex._3._Flowers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfChrysanthemums = int.Parse(Console.ReadLine());
            int numOfRoses = int.Parse(Console.ReadLine());
            int numOfTulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            char holidayYesOrNO = char.Parse(Console.ReadLine());
            int numOfAllFlowers = numOfChrysanthemums + numOfTulips + numOfRoses;
            double totalPrice = 0;
            if( holidayYesOrNO == 'Y')
            {
                switch (season)
                {
                    case "Spring":
                    case "Summer":
                        totalPrice = numOfChrysanthemums * (2.00 + 2.00 * 0.15) + numOfRoses * (4.10 + 4.10 * 0.15) + numOfTulips * (2.50 + 2.50 * 0.15);
                        if(numOfTulips > 7 && season == "Spring")
                        {
                            totalPrice -= totalPrice * 0.05;
                        }
                        break;
                    case "Autumn":
                    case "Winter":
                        totalPrice = numOfChrysanthemums * (3.75 + 3.75 * 0.15) + numOfRoses * (4.50 + 4.50 * 0.15) + numOfTulips * (4.15 + 4.15 * 0.15);
                        if(numOfRoses >= 10 && season == "Winter")
                        {
                            totalPrice -= totalPrice * 0.10;
                        }
                        break;
                }
                if(numOfAllFlowers > 20)
                {
                    totalPrice -= totalPrice * 0.20;
                }

            }
            else if( holidayYesOrNO == 'N')
            {
                switch (season)
                {
                    case "Spring":
                    case "Summer":
                        totalPrice = numOfChrysanthemums * 2.00 + numOfRoses * 4.10 + numOfTulips * 2.50;
                        if (numOfTulips > 7 && season == "Spring")
                        {
                            totalPrice -= totalPrice * 0.05;
                        }
                        break;
                    case "Autumn":
                    case "Winter":
                        totalPrice = numOfChrysanthemums * 3.75 + numOfRoses * 4.50 + numOfTulips * 4.15;
                        if (numOfRoses >= 10 && season == "Winter")
                        {
                            totalPrice -= totalPrice * 0.10;
                        }
                        break;
                }
                if (numOfAllFlowers > 20)
                {
                    totalPrice -= totalPrice * 0.20;
                }
            }
            totalPrice += 2;
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
