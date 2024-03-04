using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carsInParking = new HashSet<string>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] partsOfInput = input.Split(", ");
                string inOrOut = partsOfInput[0];
                string carNumber = partsOfInput[1];
                if (inOrOut == "IN")
                {
                    carsInParking.Add(carNumber);
                }
                else
                {
                    carsInParking.Remove(carNumber);
                }
                input = Console.ReadLine();
            }
            if (carsInParking.Any())
            {
                foreach (string car in carsInParking)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine($"Parking Lot is Empty");
            }
        }
    }
}
