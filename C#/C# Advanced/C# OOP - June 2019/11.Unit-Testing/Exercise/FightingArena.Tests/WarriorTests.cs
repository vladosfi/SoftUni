using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warior;
        private readonly int defaultDamage = 50;
        private readonly int defaultHp = 50;

        [SetUp]
        public void Setup()
        {
            warior = new Warrior("Vapman", defaultDamage, defaultHp);
        }

        [Test]
        public void TestConstructors()
        {
            Assert.That("Vapman", Is.EqualTo(this.warior.Name));
            Assert.That(defaultDamage, Is.EqualTo(this.warior.Damage));
            Assert.That(defaultDamage, Is.EqualTo(this.warior.HP));
        }


        [Test]
        public void TestWariorNameException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(string.Empty, defaultDamage, defaultHp));
            Assert.Throws<ArgumentException>(() => new Warrior(null, defaultDamage, defaultHp));
            Assert.Throws<ArgumentException>(() => new Warrior(" ", defaultDamage, defaultHp));
        }

        [Test]
        public void TestWariorDamageException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Vapman", 0, defaultHp));
        }

        [Test]
        public void TestWariorHpException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Vapman", defaultDamage, -1));
        }

        [Test]
        public void TestWariorHpMinAttakException()
        {
            Warrior fakeWarior = new Warrior("Pakman", defaultDamage, 30);
            Assert.Throws<InvalidOperationException>(() => this.warior.Attack(fakeWarior));
        }

        [Test]
        public void TestFakeWariorHpMinAttakException()
        {
            Warrior fakeWarior = new Warrior("Pakman", defaultDamage, 30);
            this.warior = new Warrior("Vapman", defaultDamage, defaultHp);

            Assert.Throws<InvalidOperationException>(() => this.warior.Attack(fakeWarior));
        }

        [Test]
        public void TestIfWarirorHpIsLowerThenFakeWariorDamageAttakException()
        {
            Warrior fakeWarior = new Warrior("Pakman", 100, defaultHp);
            this.warior = new Warrior("Vapman", defaultDamage, defaultHp);

            Assert.Throws<InvalidOperationException>(() => this.warior.Attack(fakeWarior));
        }


        //Tri varianta na tozi test 
        [Test]
        public void TestIfWarirorAttak()
        {
            //Assert
            Warrior fakeWarior = new Warrior("Pakman", 10, defaultHp);
            this.warior = new Warrior("Vapman", defaultDamage, defaultHp);
            int expectedWariorHp = this.warior.HP - fakeWarior.Damage;
            int expectedFakeWariorHp = fakeWarior.HP - this.warior.Damage;

            if (expectedWariorHp < 0)
            {
                expectedFakeWariorHp = 0;
            }

            //Act
            this.warior.Attack(fakeWarior);

            //Assert
            Assert.That(expectedWariorHp, Is.EqualTo(this.warior.HP));
            Assert.That(expectedFakeWariorHp, Is.EqualTo(fakeWarior.HP));
        }

    }
}