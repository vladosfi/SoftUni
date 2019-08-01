using Moq;
using NUnit.Framework;
using Skeleton.Contracts;
using System;

namespace Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            axe = new Axe(10, 10);
            dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
        }
    }

    [TestFixture]
    public class DummyTests
    {
        private Axe axe;
        private Dummy dummy;
        private Hero hero;

        [Test]
        [TestCase(15,3)]
        [TestCase(25,6)]
        [TestCase(25, 0)]
        public void DummyLosesHealthIfAttacked(int dummyHealth, int attackPower)
        {
            axe = new Axe(10, 10);
            dummy = new Dummy(dummyHealth, 10);

            dummy.TakeAttack(attackPower);

            Assert.That(dummy.Health, Is.EqualTo(dummyHealth - attackPower), "Dummy health doesn't change after attack.");
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            dummy = new Dummy(0, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(1));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            hero = new Hero("Batman");
            dummy = new Dummy(0, 10);
            
            Assert.Throws<InvalidOperationException>(() => hero.Attack(dummy));            
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            Dummy dummy = new Dummy(5, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }

    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void XPFunctionality()
        {
            IWeapon fakeWeapon = new Axe(10, 10);
            ITarget fakeTarget = new Dummy(10, 10);

            Hero hero = new Hero("Vlado", fakeWeapon);
            hero.Attack(fakeTarget);

            Assert.That(fakeTarget.IsDead, Is.EqualTo(true), "Target is not Dead after attack.");
        }

        [Test]
        public void XPFunctionalityMockDemo()
        {
            Mock<IWeapon> mockWeapon = new Mock<IWeapon>();
            Mock<ITarget> mockTarget = new Mock<ITarget>();

            Hero batman = new Hero("Batman", mockWeapon.Object);

            mockWeapon.Setup(w => w.Attack(mockTarget.Object));
            mockTarget.Setup(t => t.GiveExperience()).Returns(() => 5);

            var exp = mockTarget.Object.GiveExperience();

        }
    }
}