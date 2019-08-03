using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private readonly int defaultDamage = 50;
        private readonly int defaultHp = 50;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConstructors()
        {
            Warrior warrior = new Warrior("Vapman", defaultDamage, defaultHp);

            Assert.AreEqual("Vapman", warrior.Name);
            Assert.AreEqual(defaultDamage, warrior.Damage);
            Assert.AreEqual(defaultHp, warrior.HP);
        }


        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("         ")]
        [TestCase(null)]
        public void TestWariorNameException(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 10, defaultHp));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void TestWariorDamageException(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Vapman", damage, 10));
        }


        [Test]
        public void TestWariorHpException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Vapman", defaultDamage, -1));
        }

        [Test]
        public void TestWariorHpLowHp()
        {
            Warrior attaker = new Warrior("Crackman", 10, 25);
            Warrior defender = new Warrior("Pakman", 5, 45);
            Assert.Throws<InvalidOperationException>(() => attaker.Attack(defender));
        }

        [Test]
        public void TestAttackingEnemyWithLowHp()
        {
            Warrior attaker = new Warrior("Crackman", 10, 45);
            Warrior defender = new Warrior("Pakman", 5, 25);
            Assert.Throws<InvalidOperationException>(() => attaker.Attack(defender));
        }

        [Test]
        public void TestAttackingWithStrongerEnemy()
        {
            Warrior attacker = new Warrior("Pakman", 10, 35);
            Warrior deffender = new Warrior("Vapman", 40, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(deffender));
        }



        [Test]
        public void Attack_WorkProperly()
        {
            int expektedAttackerHp = 95;
            int expektedDefenderrHp = 80;

            Warrior attacker = new Warrior("Vapman", 10, 100);
            Warrior defender = new Warrior("Pacman", 5, 90);

            attacker.Attack(defender);

            Assert.AreEqual(expektedAttackerHp, attacker.HP);
            Assert.AreEqual(expektedDefenderrHp, defender.HP);
        }

        [Test]
        public void TestKillingEnemy()
        {
            int expektedAttackerHp = 55;
            int expektedDefenderrHp = 0;

            Warrior attacker = new Warrior("Vapman", 50, 100);
            Warrior defender = new Warrior("Pacman", 45, 40);

            attacker.Attack(defender);

            Assert.AreEqual(expektedAttackerHp, attacker.HP);
            Assert.AreEqual(expektedDefenderrHp, defender.HP);
        }
    }
}