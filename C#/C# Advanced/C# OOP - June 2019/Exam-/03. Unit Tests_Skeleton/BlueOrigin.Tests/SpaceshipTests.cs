namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        [Test]
        public void TestAstronautConstructor()
        {
            Astronaut astronaut = new Astronaut("Pesho", 3.5);

            Assert.That("Pesho", Is.EqualTo(astronaut.Name));
            Assert.That(3.5, Is.EqualTo(astronaut.OxygenInPercentage));
        }

        [Test]
        public void TestSpacheshipConstructor()
        {
            Spaceship spaceship = new Spaceship("MKS", 10);

            Assert.That("MKS", Is.EqualTo(spaceship.Name));
            Assert.That(10, Is.EqualTo(spaceship.Capacity));
            Assert.That(0, Is.EqualTo(spaceship.Count));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void TestSpacheshipNameException(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(name, 10), "Invalid spaceship name!");
        }

        [Test]
        public void TestSpacheshipCapacityException()
        {

            Assert.Throws<ArgumentException>(() => new Spaceship("MKS", -1), "Invalid capacity!");
        }

        [Test]
        public void TestIfAddingAstronautWorks()
        {
            Spaceship spaceship = new Spaceship("MKS", 10);
            Astronaut astronaut = new Astronaut("Pesho", 3.5);
            spaceship.Add(astronaut);
            Assert.That(1, Is.EqualTo(spaceship.Count));
        }

        [Test]
        public void TestSpacheshipSpaceshipIsFull()
        {
            Spaceship spaceship = new Spaceship("MKS", 1);
            Astronaut astronaut1 = new Astronaut("Pesho1", 3.5);
            Astronaut astronaut2 = new Astronaut("Pesho2", 3.5);

            spaceship.Add(astronaut1);
            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut2), "Spaceship is full!");
        }



        [Test]
        public void TestSpacheshipAstronautDuplication()
        {
            Spaceship spaceship = new Spaceship("MKS", 2);
            Astronaut astronaut = new Astronaut("Pesho1", 3.5);

            spaceship.Add(astronaut);
            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut), $"Astronaut {astronaut.Name} is already in!");
        }

        [Test]
        public void TestSpacheshipRemoveWorks()
        {
            Spaceship spaceship = new Spaceship("MKS", 2);
            Astronaut astronaut = new Astronaut("Pesho1", 3.5);

            spaceship.Add(astronaut);
            Assert.IsTrue(spaceship.Remove("Pesho1"));
        }

    }
}