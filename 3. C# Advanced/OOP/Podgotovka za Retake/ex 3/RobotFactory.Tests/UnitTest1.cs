using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace RobotFactory.Tests
{
    public class Tests
    {
        private Factory factory;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_ConstructorMustSetDataCorrectly()
        {
            string name = "Fac1";
            int capacity = 5;
            factory = new Factory(name, capacity);

            Assert.IsNotNull(factory);
            Assert.That(factory.Name, Is.EqualTo(name));
            Assert.That(factory.Capacity, Is.EqualTo(capacity));
            Assert.That(factory.Robots.Count, Is.EqualTo(0));
            Assert.That(factory.Supplements.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test_MethodProduceRobot_WhenHaveAvailableCapacity()
        {
            factory = new Factory("Fac1", 5);
            string model = "Robot1";
            double price = 117.205;
            int interfaceStandard = 10045;

            string realResult = factory.ProduceRobot(model, price, interfaceStandard);
            string expectedResult = $"Produced --> Robot model: {model} IS: {interfaceStandard}, Price: {price:f2}";

            Assert.IsNotNull((Robot)factory.Robots[0]);
            Assert.That(factory.Robots.Count, Is.EqualTo(1));
            Assert.That(factory.Robots[0].Model, Is.EqualTo(model));
            Assert.That(factory.Robots[0].Price, Is.EqualTo(price));
            Assert.That(factory.Robots[0].InterfaceStandard, Is.EqualTo(interfaceStandard));
            Assert.That(factory.Robots[0].Supplements.Count, Is.EqualTo(0));
            Assert.That(realResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_MethodProduceRobot_WhenDontHaveAvailableCapacity()
        {
            factory = new Factory("Fac1", 1);
            string model1 = "Robot1";
            string model2 = "Robot2";
            double price = 117.205;
            int interfaceStandard = 10045;
            factory.ProduceRobot(model1, price, interfaceStandard);
            string realResult = factory.ProduceRobot(model2, price, interfaceStandard);
            string expectedResult = $"The factory is unable to produce more robots for this production day!";
            
            Assert.That(realResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_MethodProduceSupplement()
        {
            factory = new Factory("Fac1", 5);
            string name = "Robot1";
            int interfaceStandard = 10045;

            string realResult = factory.ProduceSupplement(name, interfaceStandard);
            string expectedResult = $"Supplement: {name} IS: {interfaceStandard}";

            Assert.IsNotNull((Supplement)factory.Supplements[0]);
            Assert.That(factory.Supplements.Count, Is.EqualTo(1));
            Assert.That(factory.Supplements[0].Name, Is.EqualTo(name));
            Assert.That(factory.Supplements[0].InterfaceStandard, Is.EqualTo(interfaceStandard));

            Assert.That(realResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_MethodUpgradeRobot_WithValidData()
        {
            factory = new Factory("Fac1", 5);
            factory.ProduceRobot("Robot1", 117.20, 10045);
            factory.ProduceSupplement("Supp1", 10045);

            Assert.That(factory.Robots[0].Supplements.Count, Is.EqualTo(0));

            bool realResult = factory.UpgradeRobot(factory.Robots[0], factory.Supplements[0]);

            Assert.That(factory.Robots[0].Supplements.Count, Is.EqualTo(1));
            Assert.True(realResult);
        }

        [Test]
        public void Test_MethodUpgradeRobot_WhenRobotDontSupportThisInterface()
        {
            factory = new Factory("Fac1", 5);
            factory.ProduceRobot("Robot1", 117.20, 10045);
            factory.ProduceSupplement("Supp1", 10044);

            Assert.That(factory.Robots[0].Supplements.Count, Is.EqualTo(0));

            bool realResult = factory.UpgradeRobot(factory.Robots[0], factory.Supplements[0]);

            Assert.That(factory.Robots[0].Supplements.Count, Is.EqualTo(0));
            Assert.False(realResult);
        }

        [Test]
        public void Test_MethodUpgradeRobot_WhenRobotAlreadyhaveThisSupplement()
        {
            factory = new Factory("Fac1", 5);
            factory.ProduceRobot("Robot1", 117.20, 10045);
            factory.ProduceSupplement("Supp1", 10045);

            Assert.That(factory.Robots[0].Supplements.Count, Is.EqualTo(0));

            factory.UpgradeRobot(factory.Robots[0], factory.Supplements[0]);
            bool realResult = factory.UpgradeRobot(factory.Robots[0], factory.Supplements[0]);

            Assert.That(factory.Robots[0].Supplements.Count, Is.EqualTo(1));
            Assert.False(realResult);
        }

        [Test]
        public void Test_MethodSellRobot()
        {
            factory = new Factory("Fac1", 10);
            factory.ProduceRobot("Robot1", 50, 10045);
            factory.ProduceRobot("Robot2", 100, 10045);
            factory.ProduceRobot("Robot3", 500, 10045);
            factory.ProduceRobot("Robot4", 1000, 10045);
            factory.ProduceRobot("Robot5", 5000, 10045);
            factory.ProduceRobot("Robot6", 10000, 10045);
            factory.ProduceRobot("Robot7", 50000, 10045);
            factory.ProduceRobot("Robot8", 100000, 10045);

            List<Robot> orderedRobots = factory.Robots.OrderByDescending(r => r.Price).ToList();
            Assert.That(orderedRobots[0].Price, Is.EqualTo(100000));
            Assert.That(orderedRobots[3].Price, Is.EqualTo(5000));
            Assert.That(orderedRobots[orderedRobots.Count - 1].Price, Is.EqualTo(50));

            Robot expectedSoldRobot = orderedRobots[4];
            Robot realSoldRobot = factory.SellRobot(1050);

            Assert.That(realSoldRobot, Is.EqualTo(expectedSoldRobot));
        }
    }
}