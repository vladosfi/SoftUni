using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private Hero hero = new Hero("Vapman", 50);

    [Test]
    public void TestHeroConstructor()
    {
        Assert.That("Vapman", Is.EqualTo(hero.Name));
        Assert.That(50, Is.EqualTo(hero.Level));
    }

    [Test]
    public void TestHeroRepositoryInitializeHeroList()
    {
        HeroRepository repo = new HeroRepository();

        Assert.That(0, Is.EqualTo(repo.Heroes.Count));
    }


    [Test]
    public void TestIfHeroIsCreated()
    {
        HeroRepository repo = new HeroRepository();

        Assert.That($"Successfully added hero {hero.Name} with level {hero.Level}", Is.EqualTo(repo.Create(hero)));
    }

    [Test]
    public void TestIfHeroIsCreationTrowsExceptionIfHeroIsNull()
    {
        HeroRepository repo = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() => repo.Create(null), "Hero is null");
    }

    [Test]
    public void TestIfExceptionIsThrownWhenHeroAlreadyExist()
    {
        HeroRepository repo = new HeroRepository();

        repo.Create(hero);

        Assert.Throws<InvalidOperationException>(() => repo.Create(hero), $"Hero with name {hero.Name} already exists");
    }

    [Test]
    public void TestIfRemoveFromRepoActualyRemoveHero()
    {
        HeroRepository repo = new HeroRepository();

        repo.Create(hero);

        Assert.IsTrue(repo.Remove(hero.Name));
    }

    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase("     ")]
    public void TestIfExceptionIsThrownWhenTryToRemoveHeroThatNameIsNullOrWhitespace(string name)
    {
        HeroRepository repo = new HeroRepository();
        
        Assert.Throws<ArgumentNullException>(() => repo.Remove(name), "Name cannot be null");
    }

    [Test]
    public void TestGettingHeroWithHighestLevel()
    {
        HeroRepository repo = new HeroRepository();
        Hero hero1 = new Hero("Vapman", 50);
        Hero hero2 = new Hero("Dapman", 70);
        Hero hero3 = new Hero("Mapman", 90);

        repo.Create(hero1);
        repo.Create(hero2);
        repo.Create(hero3);

        Assert.That(hero3.Level, Is.EqualTo(repo.GetHeroWithHighestLevel().Level));
    }

    [Test]
    public void TestGettingHeroByName()
    {
        HeroRepository repo = new HeroRepository();
        
        repo.Create(hero);
        
        Assert.That("Vapman", Is.EqualTo(repo.GetHero("Vapman").Name));
    }
}