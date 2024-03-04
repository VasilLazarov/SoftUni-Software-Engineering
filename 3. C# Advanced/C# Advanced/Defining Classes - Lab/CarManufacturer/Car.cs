using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        //Constructors for exercise 3
        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }
        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;

        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires) 
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }


        public string Make 
        { 
            get { return this.make; } 
            set { this.make = value; } 
        }
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
        }
        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }
        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }
        public Tire[] Tires
        {
            get { return this.tires; }
            set { this.tires = value; }
        }


        public void Drive(double distance)
        {
            double neededFuel = distance * fuelConsumption;
            if (neededFuel <= fuelQuantity)
            {
                fuelQuantity -= neededFuel;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            string infoForPrint = $"Make: {this.make}\nModel: {this.model}\nYear: {this.year}\nFuel: {this.fuelQuantity:f2}";
            //better with string builder and using AppendLine( at the and return stringBuilder.ToString().Trim() - use trim for removing empty entries on the end of string
            return infoForPrint;
        }

        public double CalculateSumOfTiresPressures(Tire[] tiresArray)
        {
            double sumOfTiresPressures = 0;
            foreach (Tire tire in tiresArray)
            {
                sumOfTiresPressures += tire.Pressure;
            }
            
            

            return sumOfTiresPressures;
        }
    }
}
