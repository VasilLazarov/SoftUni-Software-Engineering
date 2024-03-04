using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        private int attackPoints;
        private int durabilityPoints;

        [SetUp]
        public void Setup()
        {
            attackPoints = 10;
            durabilityPoints = 15;
            axe = new Axe(attackPoints, durabilityPoints);
            dummy = new Dummy(100, 100);
        }

        [Test]
        public void Test_AxeConstructorShouldSetDataProperly()
        {
            Assert.IsNotNull(axe);
            Assert.That(axe.AttackPoints, Is.EqualTo(attackPoints));
            Assert.That(axe.DurabilityPoints, Is.EqualTo(durabilityPoints));
        }

        [Test]
        public void Test_AxeShouldLoseDurabilityPointsAfterEachAttack()
        {
            for (int i = 0; i < 5; i++)
            {
                axe.Attack(dummy);
            }

            Assert.That(axe.DurabilityPoints, Is.EqualTo(durabilityPoints - 5));
        }

        [Test]
        public void Test_AxeShouldThrowException_WhenDurabilityIsZero()
        {
            axe = new Axe(20, 0);

            Assert.Throws<InvalidOperationException>((() =>
            {
                axe.Attack(dummy);
            }));
        }

        [Test]
        public void Test_AxeShouldThrowException_WhenDurabilityIsNegative()
        {
            axe = new Axe(20, -5);

            Assert.Throws<InvalidOperationException>((() =>
            {
                axe.Attack(dummy);
            }));
        }
    }
}