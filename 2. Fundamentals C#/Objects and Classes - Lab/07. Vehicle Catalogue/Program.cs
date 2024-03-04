using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Vehicle_Catalogue
{
    public class Program
    {
        static void Main(string[] args)
        {
            int countOfTrucks = 0;
            int countOfCars = 0;
            Catalog vehicleCatalogue = new Catalog();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputCMD = input.Split('/');
                string type = inputCMD[0];
                string brand = inputCMD[1];
                string model = inputCMD[2];
                int value = int.Parse(inputCMD[3]);
                AddVehicle(vehicleCatalogue.Trucks, vehicleCatalogue.Cars, type, brand, model, value, ref countOfTrucks, ref countOfCars);
            }
            PrintCatalog(vehicleCatalogue.Trucks, vehicleCatalogue.Cars, countOfCars, countOfTrucks);
        }
        static void PrintCatalog(List<Truck> trucks, List<Car> cars, int countOfCars, int countOfTrucks)
        {
            if (countOfCars > 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car car in cars.OrderBy(c => c.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (countOfTrucks > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck truck in trucks.OrderBy(t => t.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
        static void AddVehicle(List<Truck> trucks, List<Car> cars, string type, string brand, string model, int value, ref int countOfTrucks, ref int countOfCars)
        {
            if (type == "Truck")
            {
                Truck newTruck = new Truck(brand, model, value);
                trucks.Add(newTruck);
                countOfTrucks++;
            }
            else if (type == "Car")
            {
                Car newCar = new Car(brand, model, value);
                cars.Add(newCar);
                countOfCars++;
            }
        }
    }
    public class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
        public Truck(string brand, string model, int weight)
        {
            this.Brand = brand;
            this.Model = model;
            this.Weight = weight;
        }
    }
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public Car(string brand, string model, int horsePower)
        {
            this.Brand = brand;
            this.Model = model;
            this.HorsePower = horsePower;
        }
    }
    public class Catalog
    {
        public List<Truck> Trucks { get; set; }
        public List<Car> Cars { get; set; }
        public Catalog()
        {
            Trucks = new List<Truck>();
            Cars = new List<Car>();
        }
    }
}
