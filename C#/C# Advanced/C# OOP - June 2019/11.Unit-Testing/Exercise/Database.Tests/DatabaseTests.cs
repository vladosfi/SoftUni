using System;
using NUnit.Framework;
using Database;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database.Database db;
        private readonly int[] database = new int[] { 1, 2, 3 };

        [SetUp]
        public void Setup()
        {
            this.db = new Database.Database(database);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            int expectedCount = 3;

            Assert.AreEqual(expectedCount, db.Count);
        }

        [Test]
        public void AddMethodShoulThrowExceptionWithInvalidParameter()
        {
            for (int i = 0; i < 13; i++)
            {
                this.db.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => this.db.Add(3));
        }

        [Test]
        public void RemoveMethodShoulRemoveLastElement()
        {
            int expectedCount = 2;

            this.db.Remove();

            Assert.That(expectedCount, Is.EqualTo(db.Count));
        }

        [Test]
        public void RemoveMethodShoulThrowExceptionIfDatabaseIsEmpty()
        {
            for (int i = 0; i <= this.db.Count + 1; i++)
            {
                this.db.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => this.db.Remove());
        }

        [Test]
        public void CheckIfFetchWork()
        {
            int[] result = this.db.Fetch();

            CollectionAssert.AreEqual(database, result);
        }
    }
}