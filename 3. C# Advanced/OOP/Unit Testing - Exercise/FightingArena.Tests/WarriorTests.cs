namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        private Warrior attacker;
        private Warrior defender;


        [Test]
        public void Test_ConstructorSetCorrectlyDataInFields_WhenDataIsValid()
        {
            string expectedName = "Vaseto";
            int expectedDamage = 100;
            int expectedHP = 300;
            warrior = new Warrior(expectedName, expectedDamage, expectedHP);

            Assert.IsNotNull(warrior);
            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHP, warrior.HP);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Test_ConstructorShouldThrowException_WithInvalidName(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(name, 10, 50);
            }, "Name should not be empty or whitespace!");
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void Test_ConstructorShouldThrowException_WithInvalidDamage(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("Vaseto", damage, 50);
            }, "Damage value should be positive!");
        }

        [TestCase(-1)]
        [TestCase(-50)]
        public void Test_ConstructorShouldThrowException_WithInvalidHP(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("Vaseto", 10, hp);
            }, "HP should not be negative!");
        }

        [TestCase(10)]
        [TestCase(100)]
        public void Test_AttackMethodShouldDecreaseHPOnAttackerAndDefender_WhenAttackIsPossible(int attackerDamage)
        {
            int attackerHP = 300;
            attacker = new Warrior("Vaseto", attackerDamage, attackerHP);
            int defenderHP = 50;
            int defenderDamage = 80;
            defender = new Warrior("Ani", defenderDamage, defenderHP);
            attacker.Attack(defender);

            Assert.AreEqual(attackerHP - defenderDamage, attacker.HP);
            if (attackerDamage > defenderHP)
            {
                Assert.AreEqual(0, defender.HP);
            }
            else
            {
                Assert.AreEqual(defenderHP - attackerDamage, defender.HP);
            }
        }

        [Test]
        public void Test_AttackMethodShouldThrowException_WhenAttackerDontHaveEnoughHPForAttack()
        {
            attacker = new Warrior("Vaseto", 50, 20);
            defender = new Warrior("Ani", 10, 40);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            }, "Your HP is too low in order to attack other warriors!");
            
        }

        [Test]
        public void Test_AttackMethodShouldThrowException_WhenDefenderDontHaveEnoughHPForAttack()
        {
            attacker = new Warrior("Vaseto", 50, 50);
            defender = new Warrior("Ani", 10, 20);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            }, $"Enemy HP must be greater than 30 in order to attack him!");
        }

        [Test]
        public void Test_AttackMethodShouldThrowException_WhenDefenderHasMoreDamageThanAttackersHP()
        {
            attacker = new Warrior("Vaseto", 50, 40);
            defender = new Warrior("Ani", 41, 60);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            }, $"You are trying to attack too strong enemy");
        }
    }
}