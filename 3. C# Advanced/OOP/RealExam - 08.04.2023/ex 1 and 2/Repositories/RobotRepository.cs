using RobotService.Repositories.Contracts;
using RobotService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private readonly List<IRobot> robots;

        public RobotRepository()
        {
            robots = new List<IRobot>();
        }

        public IReadOnlyCollection<IRobot> Models()
            => robots;
        public void AddNew(IRobot model)
        {
            robots.Add(model);
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            IRobot robot = robots.FirstOrDefault(r => r.InterfaceStandards.Any(s => s == interfaceStandard));

            if (robot == null)
            {
                return null;
            }
            return robot;
        }

        public bool RemoveByName(string robotModel)
        {
            IRobot robot = robots.FirstOrDefault(r => r.Model == robotModel);

            if(robot == null)
            {
                return false;
            }
            robots.Remove(robot);
            return true;
        }
    }
}
