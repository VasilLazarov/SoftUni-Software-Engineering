﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : Car, IElectricCar
    {
        public Tesla(string model, string color, int battery) 
            : base(model, color)
        {
            Battery = battery;
        }

        public int Battery
        {
            get;
            set;
        }
        
        public override string ToString()
        {
            return $"{Color} {GetType().Name} {Model} with {Battery} Batteries" 
                + Environment.NewLine + Start() 
                + Environment.NewLine + Stop();
        }
    }
}
