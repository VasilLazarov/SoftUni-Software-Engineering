using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private double increasedConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            FuelConsumption += increasedConsumption;
        }

        public override void Refuel(double fuel)
        {
            double fuelForAdd = fuel * 0.95;
            base.Refuel(fuelForAdd);
        }
    }
}
