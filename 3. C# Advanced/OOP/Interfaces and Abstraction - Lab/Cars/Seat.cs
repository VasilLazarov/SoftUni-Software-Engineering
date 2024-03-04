﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : Car
    {
        public Seat(string model, string color) 
            : base(model, color)
        {
        }

        public override string ToString()
        {
            return $"{Color} {GetType().Name} {Model}" + Environment.NewLine
                + Start() + Environment.NewLine + Stop();
        }
    }
}
