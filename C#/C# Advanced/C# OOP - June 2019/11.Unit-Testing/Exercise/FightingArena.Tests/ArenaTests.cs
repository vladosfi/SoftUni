using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void Test1()
        {
            Assert.That(0,Is.EqualTo(arena.Count));
        }
    }
}
