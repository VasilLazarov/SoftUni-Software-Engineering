using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Tire[]> tires = new List<Tire[]>();
            List<Car> cars = new List<Car>();

            string input = string.Empty;
            int countTireArrays = 0;

            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] inputElements = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                tires.Add(new Tire[4]);
                int tiresInCurrentArray = 0;

                for (int i = 0; i < inputElements.Length; i += 2)
                {
                    int year = int.Parse(inputElements[i]);
                    double pressure = double.Parse(inputElements[i + 1]);
                    tires[countTireArrays][tiresInCurrentArray] = new Tire(year, pressure);
                    tiresInCurrentArray++;
                }
                countTireArrays++;
            }

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] inputElements = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(inputElements[0]);
                double cubicCapacity = double.Parse(inputElements[1]);
                engines.Add(new Engine(horsePower, cubicCapacity));
            }



            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] inputElements = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = inputElements[0];
                string model = inputElements[1];
                int year = int.Parse(inputElements[2]);
                double fuelQuantity = double.Parse(inputElements[3]);
                double fuelConsumption = double.Parse(inputElements[4]);
                int engineIndex = int.Parse(inputElements[5]);
                int tiresIndex = int.Parse(inputElements[6]);
                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]));
            }

            foreach (Car car in cars)
            {
                double fullTiresPressureForCurrentCar = car.CalculateSumOfTiresPressures(car.Tires);
                if (car.Year >= 2017 && car.Engine.HorsePower > 330 && fullTiresPressureForCurrentCar < 10 && fullTiresPressureForCurrentCar > 9)
                {
                    double distance = 20 / 100.0;
                    car.Drive(distance);
                    Console.WriteLine($"Make: {car.Make}");
                    Console.WriteLine($"Model: {car.Model}");
                    Console.WriteLine($"Year: {car.Year}");
                    Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                    Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
                }
                
            }








            //Tire[] tires = new Tire[4]
            //{
            //    new Tire(1, 2.5),
            //    new Tire(1, 2.1),
            //    new Tire(2, 0.5),
            //    new Tire(2, 2.3)
            //};

            //tires.Add(new Tire[4]{   -> tires is List<Tires[]>
            //    new Tire(1, 2.5),
            //    new Tire(1, 2.1),
            //    new Tire(2, 0.5),
            //    new Tire(2, 2.3)
            //});


            //
            //Engine engine = new Engine(560, 6300);
            //
            //Car car = new Car("Lamborghini", "Aventador", 2020, 250, 9, engine, tires);
            //Console.WriteLine($"{car.Engine.HorsePower} - {car.Engine.CubicCapacity}");
            //foreach(var tire in car.Tires)
            //{
            //    Console.WriteLine($"{tire.Year} - {tire.Pressure}");
            //}


            //Car car = new Car();
            //car.Make = "VW";
            //car.Model = "MK3";
            //car.Year = 1992;
            //car.FuelQuantity = 200;
            //car.FuelConsumption = 200;
            //car.Drive(2000);
            //Console.WriteLine(car.WhoAmI());

            //Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
        }
    }
}
