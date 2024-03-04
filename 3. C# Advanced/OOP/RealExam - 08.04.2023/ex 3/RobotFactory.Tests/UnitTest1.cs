using Microsoft.VisualStudio.TestPlatform.Common.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace RobotFactory.Tests
{
    public class Tests
    {
        private Robot robot; 
        private Factory factory;
        private Supplement supplement;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_SuppmentConstucttor()
        {
            string name = "Vasil";
            int interface1 = 10;
            supplement = new Supplement(name, interface1);

            Assert.IsNotNull(supplement);
            Assert.That(supplement.Name, Is.EqualTo(name));
            Assert.That(supplement.InterfaceStandard, Is.EqualTo(interface1));

        }
        [Test]
        public void Test_SuppmentToString()
        {
            string name = "Vasil";
            int interface1 = 10;
            supplement = new Supplement(name, interface1);

            string actual = supplement.ToString();
            string expected = $"Supplement: {supplement.Name} IS: {supplement.InterfaceStandard}";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_RobotConstucttor()
        {
            string model = "DDZ";
            double price = 10.50;
            int interface1 = 10;
            robot = new Robot(model, price, interface1);

            Assert.IsNotNull(robot);
            Assert.That(robot.Model, Is.EqualTo(model));
            Assert.That(robot.Price, Is.EqualTo(price));
            Assert.That(robot.InterfaceStandard, Is.EqualTo(interface1));
            Assert.That(robot.Supplements.Count, Is.EqualTo(0));

        }
        [Test]
        public void Test_RobotToString()
        {
            string model = "DDZ";
            double price = 10.50;
            int interface1 = 10;
            robot = new Robot(model, price, interface1);
            string actual = robot.ToString();
            string expected = $"Robot model: {robot.Model} IS: {robot.InterfaceStandard}, Price: {robot.Price:f2}";

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Test_FactoryConstructor()
        {
            string name = "Fac";
            int capacity = 50;
            factory = new Factory(name, capacity);

            Assert.IsNotNull(factory);
            Assert.That(factory.Name, Is.EqualTo(name));
            Assert.That(factory.Capacity, Is.EqualTo(capacity));

            Assert.That(factory.Supplements.Count, Is.EqualTo(0));
            Assert.That(factory.Robots.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test_Factory_MethodProduceRobot_WhenHaveAvailableCapacity()
        {
            string name = "Fac";
            int capacity = 50;
            factory = new Factory(name, capacity);

            string actual = factory.ProduceRobot("Vasil", 10, 101);
            string expected = $"Produced --> {factory.Robots[0]}";

            Assert.That(factory.Robots.Count, Is.EqualTo(1));
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Test_Factory_MethodProduceRobot_WhenDontHaveAvailableCapacity()
        {
            string name = "Fac";
            int capacity = 1;
            factory = new Factory(name, capacity);
            factory.ProduceRobot("Vasil1", 101, 1011);
            string actual = factory.ProduceRobot("Vasil", 10, 101);
            string expected = $"The factory is unable to produce more robots for this production day!";

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Test_Factory_MethodProduceSupplement_WhenHaveAvailableCapacity()
        {
            string name = "Fac";
            int capacity = 50;
            factory = new Factory(name, capacity);

            string actual = factory.ProduceSupplement("Vasil", 101);
            string expected = factory.Supplements[0].ToString();

            Assert.That(factory.Supplements.Count, Is.EqualTo(1));
            Assert.That(actual, Is.EqualTo(expected));

        }
        [Test]
        public void Test_Factory_MethodUpgradeRobot_WhenDataIsCorrect()
        {
            string name = "Fac";
            int capacity = 50;
            factory = new Factory(name, capacity);
            robot = new Robot("ddz", 10, 101);
            supplement = new Supplement("nz", 1000);

            int suppelmentCountBefore = factory.Supplements.Count;
            bool fOrT = factory.UpgradeRobot(robot, supplement);
            
            Assert.That(factory.Supplements.Count, Is.EqualTo(suppelmentCountBefore));
            Assert.That(fOrT, Is.EqualTo(false));

        }
        [Test]
        public void Test_Factory_MethodUpgradeRobot_WhenDataIsntCorrect()
        {
            string name = "Fac";
            int capacity = 50;
            factory = new Factory(name, capacity);
            robot = new Robot("ddz", 10, 101);
            supplement = new Supplement("nz", 1000);
            factory.UpgradeRobot(robot, supplement);
            int suppelmentCountBefore = factory.Supplements.Count;
            bool fOrT = factory.UpgradeRobot(robot, supplement);

            Assert.That(factory.Supplements.Count, Is.EqualTo(suppelmentCountBefore));
            Assert.That(fOrT, Is.EqualTo(false));

        }

        [Test]
        public void Sell()
        {
            string name = "Fac";
            int capacity = 50;
            factory = new Factory(name, capacity);
            factory.ProduceRobot("ddz", 10, 101);
            factory.ProduceSupplement  ("nz", 1000);
            List<Robot> orderedRobots = factory.Robots.OrderByDescending(r => r.Price).ToList();

            Robot robot = orderedRobots.FirstOrDefault(r => r.Price <= price);

            Assert.That(factory.Robots[0], Is.EqualTo(robot));

        }

    }
}