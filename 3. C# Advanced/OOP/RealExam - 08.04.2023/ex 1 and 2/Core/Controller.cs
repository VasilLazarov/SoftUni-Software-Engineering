using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace RobotService.Core
{
    internal class Controller : IController
    {
        private readonly IRepository<IRobot> robots;
        private readonly IRepository<ISupplement> supplements;

        public Controller()
        {
            robots = new RobotRepository();
            supplements = new SupplementRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            if (typeName != nameof(DomesticAssistant)
                && typeName != nameof(IndustrialAssistant))
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }
            IRobot robot;
            if (typeName == nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);
            }
            else
            {
                robot = new IndustrialAssistant(model);
            }
            robots.AddNew(robot);
            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != nameof(SpecializedArm)
                && typeName != nameof(LaserRadar))
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }
            ISupplement supplement;
            if (typeName == nameof(SpecializedArm))
            {
                supplement = new SpecializedArm();
            }
            else
            {
                supplement = new LaserRadar();
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
            foreach (IRobot robot in orderedValidRobots)
            {
                sumOfBatteryLevels += robot.BatteryLevel;
            }
            if (sumOfBatteryLevels < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - sumOfBatteryLevels);
            }
            int count = 0;
            while (totalPowerNeeded > 0)
            {
                IRobot robot = orderedValidRobots[count];
                count++;
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


            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, count);
        }

        public string Report()
        {
            List<IRobot> orderedForPrintRobots = robots.Models()
                .OrderByDescending(r => r.BatteryLevel)
                .ThenByDescending(r => r.BatteryCapacity)
                .ToList();
            StringBuilder finalResult = new StringBuilder();
            foreach (IRobot robot in orderedForPrintRobots)
            {
                finalResult.AppendLine(robot.ToString());
            }

            return finalResult.ToString().TrimEnd();
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
            ISupplement supplement = supplements.Models().FirstOrDefault(s => s.GetType().Name == supplementTypeName);
            List<IRobot> validRobots = robots.Models().Where(r => !r.InterfaceStandards.Contains(supplement.InterfaceStandard) && r.Model == model).ToList();
            if (validRobots.Count == 0)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }
            IRobot robot = validRobots.First();
            robot.InstallSupplement(supplement);
            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName); ;
        }
    }
}
