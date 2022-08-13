using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void ConstructorShouldInitializeListHeroWithData()
    {
        //Assign
        HeroRepository heroRepository = new HeroRepository();
        //Act
        Type type = heroRepository.GetType();
        FieldInfo dataField = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(x => x.Name == "data").FirstOrDefault();
        var datafieldValue = dataField.GetValue(heroRepository);
        //Assert
        Assert.IsNotNull(datafieldValue);
    }

    [Test]
    public void CreateMethodShouldThrowArgumentNullExceptionIfInutHeroIsNull()
    {
        //Assign
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = null;
        //Act && asseret
        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(hero), nameof(hero), "Hero is null");
    }

    [Test]
    public void CreateMethodShouldAddAHeroToTheRepository()
    {
        //Assign
        Hero hero = new Hero("Petko", 34);
        HeroRepository heroRepository = new HeroRepository();
        //Act
        string expectedMassage = "Successfully added hero Petko with level 34";
        string actualMassage = heroRepository.Create(hero);
        Type type = heroRepository.GetType();
        FieldInfo dataField = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(x => x.Name == "data").FirstOrDefault();
        List<Hero> datafieldValue = (List<Hero>)dataField.GetValue(heroRepository);
        //Assert
        int expectedCouunt = 1;
        int actualCouunt = datafieldValue.Count;
        Assert.AreEqual(expectedCouunt, actualCouunt);
        Assert.AreEqual(expectedMassage, actualMassage);

    }
    [Test]
    public void CreateMethodShouldThrowInvalidOperationExceptionWhenHeroAlreadyExist()
    {
        //Assign
        Hero hero = new Hero("Petko", 34);
        HeroRepository heroRepository = new HeroRepository();
        //Act
        heroRepository.Create(hero);
        //Assert
        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(hero), $"Hero with name {hero.Name} already exists");
    }

    [Test]
    public void RemoveMethodShouldRemoveHeroFromRepositoryByName()
    {
        //Assign
        //Assign
        Hero hero = new Hero("Petko", 34);
        HeroRepository heroRepository = new HeroRepository();
        //Act
        heroRepository.Create(hero);
        bool expectedResult = true;
        bool actualResult = heroRepository.Remove("Petko");
        Assert.AreEqual(expectedResult, actualResult);
    }
    [TestCase(null)]
    [TestCase("")]
    public void RemoveMethodShouldArgumentNullExceptionIfInputIsNullOrWhiteSpace(string input)
    {
        //Assign
        Hero hero = new Hero("Petko", 34);
        HeroRepository heroRepository = new HeroRepository();
        //Act
        heroRepository.Create(hero);
        //Assert
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(input), "Name cannot be null");
    }

    [Test]
    public void GetHeroWithHighestLevelShouldReturnHeroWithHighestLevel()
    {
        //Assign
        HeroRepository heroRepository = new HeroRepository();
        Hero heroWithHighestLevel = new Hero("Petko", 534);
        Hero hero = new Hero("Ivan",1);
        Hero hero1 = new Hero("Milko", 1);
        heroRepository.Create(heroWithHighestLevel);
        heroRepository.Create(hero);
        heroRepository.Create(hero1);
        //Act
        Hero expectedHero = heroWithHighestLevel;
        Hero actualHero = heroRepository.GetHeroWithHighestLevel();
        //Assert
        Assert.AreEqual(expectedHero, actualHero);

    }

    [TestCase("Petko")]
    public void GetHeroMethodShouldReturnHeroByName(string name)
    {
        //Assign
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero(name, 534);
        heroRepository.Create(hero);
        //Act
        Hero expectedHero = hero;
        Hero actualHero = heroRepository.GetHero(name);
        //Assert
        Assert.AreEqual(expectedHero, actualHero);

    }

    [Test]
    public void GetHeroMethodShouldReturnNullIfHeroIsNotFount()
    {
        //Assign
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Petko", 534);
        heroRepository.Create(hero);
        //Act
        Hero expectedHero = null;
        Hero actualHero = heroRepository.GetHero("Ivan");
        //Assert
        Assert.AreEqual(expectedHero, actualHero);

    }

    [Test]
    public void PropertyHeroesShouldReturnDataAsIReadonllyCollection()
    {
        //Assign
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Petko", 534);
        Hero hero1 = new Hero("Ivan", 1);
        Hero hero2 = new Hero("Milko", 1);
        //Act
        heroRepository.Create(hero);
        heroRepository.Create(hero1);
        heroRepository.Create(hero2);
        IReadOnlyCollection<Hero> expectedCollection = new List<Hero>()
        {
            hero,hero1,hero2
        };
        IReadOnlyCollection<Hero> actualCollection = heroRepository.Heroes;
        //Assert
        CollectionAssert.AreEqual(expectedCollection, actualCollection);
    }
}