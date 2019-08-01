using System;
using NUnit.Framework;
using DatabaseDemo;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database db;

        [SetUp]
        public void Setup()
        {
            this.db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9);
        }
        
        [Test]
        public void CapacityMustBeExactly16Integers()
        {
            //Assert.Throws<InvalidOperationException>(() => this.db.Count.Equals(16), "Array's capacity is not exactly 16 integers!");
        }

        [Test]
        public void AddMethodShoulThrowExceptionWithInvalidParameter()
        {
            for (int i = 0; i < 6; i++)
            {
                this.db.Add(i);
            }
            
            Assert.Throws<InvalidOperationException>(() => this.db.Add(3));
        }
    }
}