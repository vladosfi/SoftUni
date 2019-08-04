using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry race;
        private UnitRider rider;
        private UnitMotorcycle motorcycle;

        [SetUp]
        public void Setup()
        {
            race = new RaceEntry();
            motorcycle = new UnitMotorcycle("BMV", 100, 50.6);
            rider = new UnitRider("Vapman", motorcycle);
        }

        [Test]
        public void RaceEntryConstructorTest()
        {
            Assert.That(0, Is.EqualTo(this.race.Counter));
        }

        [Test]
        public void UnitMotorcycleConstructorTest()
        {
            Assert.That("BMV", Is.EqualTo(this.motorcycle.Model));
            Assert.That(100, Is.EqualTo(this.motorcycle.HorsePower));
            Assert.That(50.6, Is.EqualTo(this.motorcycle.CubicCentimeters));
        }


        [Test]
        public void UnitRiderConstructorTest()
        {
            Assert.That("Vapman", Is.EqualTo(this.rider.Name));
            Assert.That("BMV", Is.EqualTo(this.rider.Motorcycle.Model));
            Assert.That(100, Is.EqualTo(this.rider.Motorcycle.HorsePower));
            Assert.That(50.6, Is.EqualTo(this.rider.Motorcycle.CubicCentimeters));
        }

        [Test]
        public void TestIfRiderCanBeAdded()
        {
            Assert.That("Rider Vapman added in race.", Is.EqualTo(this.race.AddRider(rider)));
        }

        [Test]
        public void TestIfRiderIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.race.AddRider(null));
        }

        [Test]
        public void TestIfRiderAlreadyExistException()
        {
            this.race.AddRider(rider);
            Assert.Throws<InvalidOperationException>(() => this.race.AddRider(rider));
        }

        [Test]
        public void TestForMinimumRaceParticipantsException()
        {
            this.race.AddRider(rider);
            Assert.Throws<InvalidOperationException>(() => this.race.CalculateAverageHorsePower());
        }

        [Test]
        public void TestForCorrectCalculationOfAverageHorsePower()
        {
            UnitRider secondRider = new UnitRider("Crackman", motorcycle);
            this.race.AddRider(rider);
            this.race.AddRider(secondRider);

            Assert.That(100, Is.EqualTo(this.race.CalculateAverageHorsePower()));
        }

        [Test]
        public void UnitRiderNameExceptionIfNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitRider(null, motorcycle));
        }


    }
}