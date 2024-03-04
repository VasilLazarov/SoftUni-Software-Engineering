namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void Test_ConstructorShouldCreateArenaCorrectly()
        {
            Assert.IsNotNull(arena);
            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void Test_EnrollShouldAddWarriorToFieldWarriors()
        {
            warrior = new Warrior("Vaseto", 100, 500);
            arena.Enroll(warrior);

            List<Warrior> warriors = arena.Warriors as List<Warrior>;
            Assert.Contains(warrior, warriors);
            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void Test_EnrollShouldThrowException_WhenWarriorIsAlreadyEnrolled()
        {
            warrior = new Warrior("Vaseto", 100, 500);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warrior);
            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void Test_PropertyWarriosShouldCorrectlyReturnFieldWarriors()
        {
            List<Warrior> expectedWarriors = new List<Warrior>();

            warrior = new Warrior("Vaseto", 100, 500);
            arena.Enroll(warrior);
            expectedWarriors.Add(warrior);
            warrior = new Warrior("Ani", 50, 250);
            arena.Enroll(warrior);
            expectedWarriors.Add(warrior);

            CollectionAssert.AreEqual(expectedWarriors, arena.Warriors);
        }

        [Test]
        public void Test_FightSouldThrowException_WherNonExistingAttacker()
        {
            Warrior attacker = new Warrior("Vaseto", 100, 300);
            Warrior defender = new Warrior("Ani", 50, 150);

            arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(attacker.Name, defender.Name);
            }, $"There is no fighter with name {attacker.Name} enrolled for the fights!");
        }

        [Test]
        public void Test_FightSouldThrowException_WherNonExistingDefender()
        {
            Warrior attacker = new Warrior("Vaseto", 100, 300);
            Warrior defender = new Warrior("Ani", 50, 150);

            arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(attacker.Name, defender.Name);
            }, $"There is no fighter with name {defender.Name} enrolled for the fights!");
        }

        [Test]
        public void Test_FightSouldSucceed_WhenWariorsExists()
        {
            Warrior attacker = new Warrior("Vaseto", 100, 300);
            Warrior defender = new Warrior("Ani", 50, 150);

            int expectedAttackerHP = attacker.HP - defender.Damage;
            int expectedDefenderHP = defender.HP - attacker.Damage;
            
            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            int actualAttackerHP = attacker.HP;
            int actualDefenderHP = defender.HP;

            Assert.AreEqual(expectedAttackerHP, actualAttackerHP);
            Assert.AreEqual(expectedDefenderHP, actualDefenderHP);
        }
    }
}
