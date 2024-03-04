using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int numbersOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersOfCars; i++)
            {
                string[] inputElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = inputElements[0];    
                int speed = int.Parse(inputElements[1]);
                int power = int.Parse(inputElements[2]);
                int cargoWeight = int.Parse(inputElements[3]);
                string cargoType = inputElements[4];
                double pressure1 = double.Parse(inputElements[5]);
                int age1 = int.Parse(inputElements[6]);
                double pressure2 = double.Parse(inputElements[7]);
                int age2 = int.Parse(inputElements[8]);
                double pressure3 = double.Parse(inputElements[9]);
                int age3 = int.Parse(inputElements[10]);
                double pressure4 = double.Parse(inputElements[11]);
                int age4 = int.Parse(inputElements[12]);

                cars.Add(new Car(model, speed, power, cargoWeight, 
                    cargoType, pressure1, age1, pressure2, age2, 
                    pressure3, age3, pressure4, age4));
            }
            string carsTypeCargo = Console.ReadLine();


            if(carsTypeCargo == "fragile")
            {
                foreach(Car car in cars.Where(v => v.Cargo.Type == carsTypeCargo && v.Tires.Any(v => v.Pressure < 1) ))
                {
                    //bool printOrNot = false;    // easy with second check in Where
                    //for (int i = 0; i < 4; i++)
                    //{
                    //    if (car.Tires[i].Pressure < 1)
                    //    {
                    //        printOrNot = true;
                    //        break;
                    //    }
                    //}
                    //if (printOrNot)
                    //{
                    //    Console.WriteLine(car.Model);
                    //}
                    Console.WriteLine(car.Model);
                }
            }
            else if(carsTypeCargo == "flammable")
            {
                foreach (Car car in cars.Where(v => v.Cargo.Type == carsTypeCargo && v.Engine.Power > 250))
                {
                    //bool printOrNot = false;  // easy with second check in Where 
                    //for (int i = 0; i < 4; i++)
                    //{
                    //    if (car.Engine.Power > 250)
                    //    {
                    //        printOrNot = true;
                    //        break;
                    //    }
                    //}
                    //if (printOrNot)
                    //{
                    //    Console.WriteLine(car.Model);
                    //}
                    Console.WriteLine(car.Model);
                }
            }
            
        }
    }
}
