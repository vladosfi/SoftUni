using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfUnitMotorcycleConstructorSetsPropertyesCorrectly()
        {
            UnitMotorcycle motorcycle = new UnitMotorcycle("BMV", 50, 60);

            Assert.That("BMV", Is.EqualTo(motorcycle.Model));
            Assert.That(50, Is.EqualTo(motorcycle.HorsePower));
            Assert.That(60, Is.EqualTo(motorcycle.CubicCentimeters));
        }

        [Test]
        public void TestIfUnitRiderConstructorSetsPropertyesCorrectly()
        {
            UnitMotorcycle motorcycle = new UnitMotorcycle("BMV", 50, 60);
            UnitRider rider = new UnitRider("Pesho", motorcycle);

            Assert.That("Pesho", Is.EqualTo(rider.Name));
        }

        [Test]
        public void TestIfUnitRiderThrowsExceptionIfNameIsNull()
        {
            UnitMotorcycle motorcycle = new UnitMotorcycle("BMV", 50, 60);

            Assert.Throws<ArgumentNullException>(() => new UnitRider(null, motorcycle));
        }

        [Test]
        public void TestIfRaceEntryConstructorWorkCorrectly()
        {
            RaceEntry raceEntry = new RaceEntry();

            Assert.That(0, Is.EqualTo(raceEntry.Counter));
        }

        [Test]
        public void TestIfRiderIsAdded()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitMotorcycle motorcycle = new UnitMotorcycle("BMV", 50, 60);
            UnitRider rider = new UnitRider("Pesho", motorcycle);

            Assert.That("Rider Pesho added in race.", Is.EqualTo(raceEntry.AddRider(rider)));
        }

        [Test]
        public void TestIfRiderIsNullTrowsException()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitMotorcycle motorcycle = new UnitMotorcycle("BMV", 50, 60);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(null), "Rider cannot be null.");
        }

        [Test]
        public void TestIfRiderIsAlreadyAddedException()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitMotorcycle motorcycle = new UnitMotorcycle("BMV", 50, 60);
            UnitRider rider = new UnitRider("Pesho", motorcycle);
            raceEntry.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(rider), "Rider Pesho is already added.");
        }

        [Test]
        public void TestIfRiderIsCalculateAverageHorsePowerWorksCorrectly()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitMotorcycle motorcycle = new UnitMotorcycle("BMV", 120, 60);
            UnitMotorcycle motorcycle2 = new UnitMotorcycle("BMV", 60, 50);
            UnitRider rider = new UnitRider("Pesho", motorcycle);
            UnitRider rider2 = new UnitRider("Gosho", motorcycle2);
            raceEntry.AddRider(rider);
            raceEntry.AddRider(rider2);

            Assert.That(90, Is.EqualTo(raceEntry.CalculateAverageHorsePower()));
        }


        [Test]
        public void TestIfRiderIsCalculateAverageHorsePowerThrowsExceptionIfRidersCountIsLessThanTwo()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitMotorcycle motorcycle = new UnitMotorcycle("BMV", 120, 60);
            UnitRider rider = new UnitRider("Pesho", motorcycle);            
            raceEntry.AddRider(rider);            

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower(), "The race cannot start with less than 2 participants.");
        }
    }
}