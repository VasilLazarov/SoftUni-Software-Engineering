using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        //private Axe axe;
        private Dummy dummy;
        private Dummy deadDummy;
        private int health;
        private int experience;

        [SetUp]
        public void Setup()
        {
            health = 100;
            experience = 10;
            dummy = new Dummy(health, experience);
            deadDummy = new Dummy(health, experience);
            deadDummy.TakeAttack(health + 1);
        }

        [Test]
        public void Test_DummyConstructorShouldSetDataProperly()
        {
            Assert.IsNotNull(dummy);
            Assert.That(dummy.Health, Is.EqualTo(health));
        }

        [Test]
        public void Test_DummyShouldLoseHealth_WhenAttacked()
        {
            dummy.TakeAttack(5);
            Assert.That(dummy.Health, Is.EqualTo(health - 5));
        }

        [Test]
        public void Test_DummyShouldThrowException_WhenAttackedAndHealthIsZero()
        {
            dummy.TakeAttack(health);
            Assert.Throws<InvalidOperationException>((() =>
            {
                dummy.TakeAttack(1);
            }));
        }

        [Test]
        public void Test_DummyShouldThrowException_WhenAttackedAndHealthIsNegative()
        {
            Assert.Throws<InvalidOperationException>((() =>
            {
                deadDummy.TakeAttack(1);
            }));
        }

        [Test]
        public void Test_DummyShouldGiveExperience_WhenIsDead()
        {
            var dummyExperience = deadDummy.GiveExperience();

            Assert.That(dummyExperience, Is.EqualTo(experience));
        }

        [Test]
        public void Test_DummyGiveExperience_ShouldThrowException_WhenDummyIsNotDead()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
        }
    }
}