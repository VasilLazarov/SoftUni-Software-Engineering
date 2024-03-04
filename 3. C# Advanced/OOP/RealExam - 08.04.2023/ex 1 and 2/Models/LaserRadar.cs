using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models
{
    public class LaserRadar : Supplement
    {
        private const int LazerInterfaceStandard = 20082;
        private const int LazerBatteryUsage = 5000;
        public LaserRadar()
            : base(LazerInterfaceStandard, LazerBatteryUsage)
        {
        }
    }
}
