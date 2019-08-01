using Database;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void CapacityMustBeExactly16Integers()
        {
            Database.Database db = new Database.Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6);

            Assert.That(db.Count, Not.EqualTo(16), "Dummy health doesn't change after attack.");
        }
    }
}