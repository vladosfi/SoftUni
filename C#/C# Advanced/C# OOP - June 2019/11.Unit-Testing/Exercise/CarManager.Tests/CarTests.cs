using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("Mitsubishi","Carisma",5.5,55);
        }

        [Test]
        public void TestConstructors()
        {
            Car expectedCar = new Car("Mitsubishi", "Carisma", 5.5, 55);

            Assert.AreEqual(0,car.FuelAmount);
            Assert.That(expectedCar.Make, Is.EqualTo(this.car.Make));
            Assert.That(expectedCar.Model, Is.EqualTo(this.car.Model));
            Assert.That(expectedCar.FuelConsumption, Is.EqualTo(this.car.FuelConsumption));
            Assert.That(expectedCar.FuelCapacity, Is.EqualTo(this.car.FuelCapacity));
            Assert.That(expectedCar.FuelAmount, Is.EqualTo(this.car.FuelAmount));
        }

        [Test]
        public void TestMakePropertyException()
        {
            Assert.Throws<ArgumentException>(() => new Car(null, "Carisma", 5.5, 55));
            Assert.Throws<ArgumentException>(() => new Car(string.Empty, "Carisma", 5.5, 55));
        }

        [Test]
        public void TestModelPropertyException()
        {
            Assert.Throws<ArgumentException>(() => new Car("Mitsubishi",null, 5.5, 55));
            Assert.Throws<ArgumentException>(() => new Car("Mitsubishi",string.Empty, 5.5, 55));
        }

        [Test]
        public void TestFuelConsumptionPropertyException()
        {
            Assert.Throws<ArgumentException>(() => new Car("Mitsubishi", "Carisma", 0, 55));
        }

        [Test]
        public void TestFuelAmountPropertyException()
        {
            Assert.Throws<ArgumentException>(() => new Car("Mitsubishi", "Carisma", 5.5, -1));
        }

        [Test]
        public void TestFuelCapacityPropertyException()
        {
            Assert.Throws<ArgumentException>(() => new Car("Mitsubishi", "Carisma", 5.5, 0));
        }

        [Test]
        public void TestRefuelException()
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(0));
        }

        [Test]
        public void TestRefuel()
        {
            this.car.Refuel(55);

            Assert.That(55, Is.EqualTo(this.car.FuelAmount));
        }

        [Test]
        public void TestIfRefuelCapacityIsMoreThanTankCapacity()
        {
            this.car.Refuel(60);

            Assert.That(55, Is.EqualTo(this.car.FuelAmount));
        }

        [Test]
        public void TestDriveException()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(900));
        }

        [Test]
        public void TestDrive()
        {
            double distance = 100;
            double expectedFuelAmount;
            this.car.Refuel(55);
            double fuelNeeded = (distance / 100) * this.car.FuelConsumption;
            expectedFuelAmount = this.car.FuelAmount - fuelNeeded;
            this.car.Drive(distance);

            Assert.That(expectedFuelAmount, Is.EqualTo(this.car.FuelAmount));
        }
    }
}