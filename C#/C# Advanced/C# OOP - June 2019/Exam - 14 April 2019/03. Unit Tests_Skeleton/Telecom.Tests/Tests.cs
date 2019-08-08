namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        [Test]
        public void TestConstructor()
        {
            Phone phone = new Phone("Samsung", "S1");

            Assert.That("Samsung", Is.EqualTo(phone.Make));
            Assert.That("S1", Is.EqualTo(phone.Model));
        }


        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void TestIsMakeIsInvalid(string make)
        {
            Assert.Throws<ArgumentException>(() => new Phone(make, "S1"), $"Invalid {nameof(Phone)}!");
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void TestIsModelIsInvalid(string model)
        {
            Assert.Throws<ArgumentException>(() => new Phone("Samsung", model), $"Invalid {nameof(Phone)}!");
        }

        [Test]
        public void TestAddingContactSuccessfully()
        {
            Phone phone = new Phone("Samsung", "S1");

            phone.AddContact("Ivan", "123456");
            
            Assert.That(1, Is.EqualTo(phone.Count));
        }

        [Test]
        public void TestAddingExistingContactException()
        {
            Phone phone = new Phone("Samsung", "S1");

            phone.AddContact("Ivan", "123456");

            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Ivan", "123456"), "Person already exists!");
        }

        [Test]
        public void TestCallingToPhoneNumber()
        {
            Phone phone = new Phone("Samsung", "S1");

            phone.AddContact("Ivan", "123456");

            Assert.That("Calling Ivan - 123456...",Is.EqualTo(phone.Call("Ivan")));
        }

        [Test]
        public void TestCallingToNonExistincContactException()
        {
            Phone phone = new Phone("Samsung", "S1");

            Assert.Throws<InvalidOperationException>(() => phone.Call("SASA"), "Person doesn't exists!");
        }
    }
}