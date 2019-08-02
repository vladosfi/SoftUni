using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase dbPerson;
        private Person person;

        [SetUp]
        public void Setup()
        {
            this.person = new ExtendedDatabase.Person(1, "Ivan");
            this.dbPerson = new ExtendedDatabase.ExtendedDatabase(person);
        }

        [Test]
        public void TestIfPersonConstructorWorksCorrectly()
        {
            Assert.AreEqual(1, this.person.Id);
            Assert.AreEqual("Ivan", this.person.UserName);
        }

        [Test]
        public void AddRangeIfMethodShoulThrowArgumentExceptionIfRangeIsMoreThan16()
        {
            Person[] personData = new Person[17];
            for (int i = 0; i < 17; i++)
            {
                person = new ExtendedDatabase.Person(i, $"Sasho{i}");
                personData[i] = person;
            }

            Assert.Throws<ArgumentException>(() => new ExtendedDatabase.ExtendedDatabase(personData));
        }


        [Test]
        public void TestIfDatabaseConstructorWorksCorrectly()
        {
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.dbPerson.Count);
        }

        [Test]
        public void AddMethodShoulThrowExceptionWithInvalidParameter()
        {
            for (int i = 2; i < 17; i++)
            {
                person = new ExtendedDatabase.Person(i, $"Sasho{i}");
                this.dbPerson.Add(person);
            }
            person = new ExtendedDatabase.Person(18, $"Sasho18");

            Assert.Throws<InvalidOperationException>(() => this.dbPerson.Add(person));
        }


        [Test]
        [TestCase(2, "Ivan")]
        [TestCase(1, "Pesho")]
        public void CheckIfCanAddUserThatAlreadyExist(int id, string name)
        {
            ExtendedDatabase.Person personToAdd = new ExtendedDatabase.Person(id, name);

            Assert.Throws<InvalidOperationException>(() => this.dbPerson.Add(personToAdd));
        }

        [Test]
        public void Test_Remove_Method()
        {
            this.dbPerson.Remove();

            Assert.AreEqual(0, this.dbPerson.Count);
        }

        [Test]
        public void CheckRemoveFromDatabaseException()
        {
            this.dbPerson.Remove();

            Assert.Throws<InvalidOperationException>(() => this.dbPerson.Remove());
        }

        [Test]
        public void CheckFindByUsernameIfNoUserExistWithThatNameOrParameterIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.dbPerson.FindByUsername("Sasho"));
        }

        [Test]
        public void CheckFindByUsernameIfSearchParameterIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.dbPerson.FindByUsername(null));
        }

        [Test]
        public void FindByIdIfSearchIdIsNotFoundException()
        {
            Assert.Throws<InvalidOperationException>(() => this.dbPerson.FindById(2));
        }

        [Test]
        public void FindByIdIfIdIsNegativeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.dbPerson.FindById(-1));
        }

        [Test]
        public void CheckFindById()
        {
            Assert.AreEqual(1, this.dbPerson.FindById(1).Id);
            Assert.AreEqual("Ivan", this.dbPerson.FindById(1).UserName);
        }

        [Test]
        public void CheckFindByName()
        {
            Assert.AreEqual(1, this.dbPerson.FindByUsername("Ivan").Id);
            Assert.AreEqual("Ivan", this.dbPerson.FindByUsername("Ivan").UserName);
        }
    }
}
