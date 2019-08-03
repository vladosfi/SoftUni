using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.warrior = new Warrior("Vapman", 50, 50);
            this.arena.Enroll(warrior);
        }

        [Test]
        public void TestArenaConstructor()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void TestEnrollingWorks()
        {
            Warrior expectedWarrior = this.arena.Warriors.Where(w => w.Name == "Vapman").FirstOrDefault();
            Assert.That(warrior, Is.EqualTo(expectedWarrior));
        }

        [Test]
        public void TestIfCounterWorks()
        {
            Assert.That(1, Is.EqualTo(arena.Count));
        }

        [Test]
        public void AlreadyEnrolledWariorsShouldNotBeAbleToEnrollAgainException()
        {
            Warrior enrolledWarrior = new Warrior("Vapman", 28, 57);

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(enrolledWarrior));
        }

        [Test]
        public void WarriorCantFightIfIsNotEnrolledException()
        {
            Warrior notEnrolledWarrior = new Warrior("Pacman", 28, 57);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(warrior.Name, notEnrolledWarrior.Name));
        }

        [Test]
        public void WarirorAttakIfWariorDamageIsBiggerThanDefenderHp()
        {
            //Assert
            Warrior defender = new Warrior("Pacman", 10, 50);
            Warrior attacker = new Warrior("Crackman", 50, 50);
            int expectedWariorHp = attacker.HP - defender.Damage;
            int expectedFakeWariorHp = defender.HP - attacker.Damage;
            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            //Act
            this.arena.Fight(attacker.Name,defender.Name);

            //Assert
            Assert.That(expectedWariorHp, Is.EqualTo(attacker.HP));
            Assert.That(expectedFakeWariorHp, Is.EqualTo(defender.HP));
        }

        [Test]
        public void WarirorAttakIfWariorDamageIsSmallerThanDefenderHp()
        {
            //Assert
            Warrior defender = new Warrior("Pacman", 50, 40);
            Warrior attacker = new Warrior("Crackman", 50, 50);
            int expectedAttackerHp = attacker.HP - defender.Damage;
            int expectedDefenderHp = 0;
            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            //Act
            this.arena.Fight(attacker.Name, defender.Name);

            //Assert
            Assert.That(expectedAttackerHp, Is.EqualTo(attacker.HP));
            Assert.That(expectedDefenderHp, Is.EqualTo(defender.HP));
        }
    }
}
