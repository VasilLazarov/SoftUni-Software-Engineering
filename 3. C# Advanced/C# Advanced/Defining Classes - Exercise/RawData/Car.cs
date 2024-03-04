using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Car
    {

        public Car(string model,int speed, int power , int cargoWeight,
            string cargoType, double pressure1, int age1, double pressure2, int age2
            , double pressure3, int age3, double pressure4, int age4)
        {
            Model = model;
            Engine = new Engine(speed, power);
            Cargo = new Cargo(cargoWeight, cargoType);
            Tires = new Tire[4]
            {
                new Tire(pressure1, age1),
                new Tire(pressure2, age2),
                new Tire(pressure3, age3),
                new Tire(pressure4, age4)
            };
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }
    }
}
