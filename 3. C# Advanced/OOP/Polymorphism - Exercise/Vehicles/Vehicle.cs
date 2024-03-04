using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public void Drive(double distance)
        {
            double neededFuel = distance * FuelConsumption;
            if (neededFuel > FuelQuantity)
            {
                Console.WriteLine($"{GetType().Name} needs refueling"); 
            }
            else
            {
                FuelQuantity -= neededFuel;
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }
        }

        public virtual void Refuel(double fuel)
        {
            FuelQuantity += fuel;
        }
        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
