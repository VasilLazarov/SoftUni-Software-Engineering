using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly SupplementRepository supplements;
        private readonly RobotRepository robots;

        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            IRobot robot = null;
            if (typeName == nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);
            }
            else if (typeName == nameof(IndustrialAssistant))
            {
                robot = new IndustrialAssistant(model);
            }
            else
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }
            robots.AddNew(robot);
            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            ISupplement supplement = null;
            if (typeName == nameof(SpecializedArm))
            {
                supplement = new SpecializedArm();
            }
            else if (typeName == nameof(LaserRadar))
            {
                supplement = new LaserRadar();
            }
            else
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }
            supplements.AddNew(supplement);
            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            List<IRobot> validRobots = robots.Models().Where(r => r.InterfaceStandards.Contains(intefaceStandard)).ToList();
            if (validRobots.Count == 0)
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }
            List<IRobot> orderedValidRobots = validRobots.OrderByDescending(r => r.BatteryLevel).ToList();
            int sumOfBatteryLevels = 0;
            for (int i = 0; i < orderedValidRobots.Count; i++)
            {
                sumOfBatteryLevels += orderedValidRobots[i].BatteryLevel;
            }
            if (sumOfBatteryLevels < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, (totalPowerNeeded - sumOfBatteryLevels));
            }

            int countOfUsedRobots = 0;
            IRobot robot;
            while (totalPowerNeeded > 0)
            {
                robot = orderedValidRobots[countOfUsedRobots];
                countOfUsedRobots++;
                if (robot.BatteryLevel >= totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    totalPowerNeeded = 0;
                }
                else
                {
                    totalPowerNeeded -= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                }
            }
            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, countOfUsedRobots);
        }

        public string Report()
        {
            List<IRobot> orderedRobots = robots.Models()
                .OrderByDescending(r => r.BatteryLevel)
                .ThenBy(r => r.BatteryCapacity)
                .ToList();
            StringBuilder result = new StringBuilder();
            foreach (IRobot robot in orderedRobots)
            {
                result.AppendLine(robot.ToString());
            }
            return result.ToString().TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)
        {
            List<IRobot> validRobots = robots.Models().Where(r => r.Model == model && r.BatteryLevel < (r.BatteryCapacity / 2)).ToList();
            foreach (IRobot robot in validRobots)
            {
                robot.Eating(minutes);
            }
            return string.Format(OutputMessages.RobotsFed, validRobots.Count);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplementForAdding = supplements.Models().FirstOrDefault(s => s.GetType().Name == supplementTypeName);
            List<IRobot> validRobots = robots.Models().Where(r => !r.InterfaceStandards.Contains(supplementForAdding.InterfaceStandard) && r.Model == model).ToList();
            if (validRobots.Count == 0)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }
            IRobot robot = validRobots.First();
            robot.InstallSupplement(supplementForAdding);
            supplements.RemoveByName(supplementTypeName);
            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }
    }
}
