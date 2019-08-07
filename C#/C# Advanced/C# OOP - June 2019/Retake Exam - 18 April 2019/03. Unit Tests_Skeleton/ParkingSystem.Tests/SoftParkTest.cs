namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private Car car;
        private SoftPark park;

        [SetUp]
        public void Setup()
        {
            car = new Car("Mitsubishi", "1112");
            park = new SoftPark();
        }

        [Test]
        public void TestCarConstructorAndPropertyes()
        {
            Assert.That("Mitsubishi", Is.EqualTo(car.Make));
            Assert.That("1112", Is.EqualTo(car.RegistrationNumber));
        }


        [Test]
        public void TestSoftParkConstructor()
        {
            Assert.That(12, Is.EqualTo(park.Parking.Count));
        }

        [Test]
        public void TestForExistingParkSpotException()
        {
            string parkSpot = "D1";

            Assert.Throws<ArgumentException>(() => park.ParkCar(parkSpot, car), "Parking spot doesn't exists!");
        }

        [Test]
        public void TestSoftParkForFreeParkSpotException()
        {
            string parkSpot = "A1";
            Car secondCar = new Car("Trabant", "VI4444AS");
            park.ParkCar(parkSpot, car);


            Assert.Throws<ArgumentException>(() => park.ParkCar(parkSpot, secondCar), "Parking spot is already taken!");
        }


        [Test]
        public void TestSoftParkIfCarAllreadyPargedException()
        {
            string parkSpot = "A1";
            park.ParkCar(parkSpot, car);


            Assert.Throws<InvalidOperationException>(() => park.ParkCar("A2", car), "Parking spot is already taken!");
        }

        [Test]
        public void TestSoftParkThatCarIsActualyParked()
        {
            string regNumber = "1112";
            string make = "Mitsubishi";

            park.ParkCar("A1", car);

            Assert.That(regNumber, Is.EqualTo(park.Parking["A1"].RegistrationNumber));
            Assert.That(make, Is.EqualTo(park.Parking["A1"].Make));
        }


        [Test]
        public void TestForRemoveFromNoneExistingParkingException()
        {
            string parkSpot = "D1";

            Assert.Throws<ArgumentException>(() => park.RemoveCar(parkSpot, car), "Parking spot doesn't exists!");
        }


        [Test]
        public void TestRemoveNotParkedCarException()
        {
            string parkSpot = "B1";

            Assert.Throws<ArgumentException>(() => park.RemoveCar(parkSpot, car), "Car for that spot doesn't exists!");
        }


        [Test]
        public void TestIfRemoveCarWork()
        {
            string parkSpot = "A1";
            park.ParkCar(parkSpot, car);

            Assert.That($"Remove car:{car.RegistrationNumber} successfully!",Is.EqualTo(park.RemoveCar(parkSpot, car)));
        }

    }
}