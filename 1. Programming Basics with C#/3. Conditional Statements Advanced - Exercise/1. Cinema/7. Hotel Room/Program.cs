using System;

namespace _7._Hotel_Room
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int numOfNights = int.Parse(Console.ReadLine());
            double apartmentPrice = 0;
            double studioPrice = 0;
            switch (month)
            {
                case "May":
                case "October":
                    apartmentPrice = numOfNights * 65.00;
                    studioPrice = numOfNights * 50.00;
                    break;
                case "June":
                case "September":
                    apartmentPrice = numOfNights * 68.70;
                    studioPrice = numOfNights * 75.20;
                    break;
                case "July":
                case "August":
                    apartmentPrice = numOfNights * 77.00;
                    studioPrice = numOfNights * 76.00;
                    break;
            }
            if(numOfNights > 7 && numOfNights <= 14 && (month == "May" || month == "October"))
            {
                studioPrice -= studioPrice * 0.05;
            }
            else if(numOfNights > 14 && (month == "May" || month == "October"))
            {
                studioPrice -= studioPrice * 0.30;
            }
            else if(numOfNights > 14 && (month == "June" || month == "September"))
            {
                studioPrice -= studioPrice * 0.20;
            }
            if(numOfNights > 14)
            {
                apartmentPrice -= apartmentPrice * 0.10;
            }

            Console.WriteLine($"Apartment: {apartmentPrice:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice:f2} lv.");
        }
    }
}
