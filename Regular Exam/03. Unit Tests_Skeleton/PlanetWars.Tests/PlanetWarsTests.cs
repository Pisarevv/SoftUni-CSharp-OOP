using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            //Testing the weapon class
            [Test]
            public void CreatingWeaponConstructorShouldCreateAWeapon()
            {
                //Assign
                string name = "GandalfsWeapon";
                double price = 42;
                int destructionLevel = 15;
                //Act
                Weapon testWeapon = new Weapon(name, price, destructionLevel);
                Type type = testWeapon.GetType();
                FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                double FieldPriceValue = (double)fields.Where(x => x.Name == "price").FirstOrDefault().GetValue(testWeapon);
                //Assign
                string expectedName = name;
                string actualName = testWeapon.Name;
                Assert.AreEqual(expectedName, actualName);
                double expectedPrice = 42;
                double actualPrice = FieldPriceValue;
                Assert.AreEqual(expectedPrice, actualPrice);
                int expectedDestructionLevel = destructionLevel;
                int actualDestructionLevel = testWeapon.DestructionLevel;
                Assert.AreEqual(expectedDestructionLevel, actualDestructionLevel);
            }

            [TestCase(-1)]
            [TestCase(-5)]
            [TestCase(-177)]
            public void CreatingWeaponWithNegativePriceShouldThrowArgumentException(int value)
            {
                //Assign
                string name = "GandalfsWeapon";
                double price = value;
                int destructionLevel = 15;
                //Act && Assert
                Assert.Throws<ArgumentException>(() => new Weapon(name, price, destructionLevel), "Price cannot be negative.");
            }

            [Test]
            public void IncreaseDestructionLevelShouldIncreaseDestructionByOneEachTime()
            {

                //Assign
                string name = "GandalfsWeapon";
                double price = 42;
                int destructionLevel = 15;
                //Act
                Weapon testWeapon = new Weapon(name, price, destructionLevel);
                testWeapon.IncreaseDestructionLevel();
                //Assert
                int expectedDestructionLevel = destructionLevel + 1;
                int actualDestructionLevel = testWeapon.DestructionLevel;
                Assert.AreEqual(expectedDestructionLevel, actualDestructionLevel);
            }

            [TestCase(10)]
            [TestCase(11)]
            [TestCase(150)]
            public void IsNuclearShouldReturnTrueIfDestructionLevelIsEqualOrMoreThatTen(int value)
            {
                //Assign
                string name = "GandalfsWeapon";
                double price = 42;
                int destructionLevel = value;
                //Act
                Weapon testWeapon = new Weapon(name, price, destructionLevel);
                bool expectedNuclearResult = true;
                bool actualNuclearResult = testWeapon.IsNuclear;
                //Assert
                Assert.AreEqual(expectedNuclearResult, actualNuclearResult);
            }

            [TestCase(9)]
            [TestCase(8)]
            [TestCase(1)]
            public void IsNuclearShouldReturnFalseIfDestructionLevelIsLessThanTen(int value)
            {
                //Assign
                string name = "GandalfsWeapon";
                double price = 42;
                int destructionLevel = value;
                //Act
                Weapon testWeapon = new Weapon(name, price, destructionLevel);
                bool expectedNuclearResult = false;
                bool actualNuclearResult = testWeapon.IsNuclear;
                //Assert
                Assert.AreEqual(expectedNuclearResult, actualNuclearResult);
            }

            //Testing the planet class
            [Test]
            public void PlanetConstructorShouldCreateAPlanet()
            {
                //Assign
                string name = "K2";
                double budget = 3.14;
                Planet testPlanet = new Planet(name, budget);
                //Act
                Type type = testPlanet.GetType();
                FieldInfo weaponField = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(x=> x.Name == "weapons").FirstOrDefault();
                //Assert
                string expectedName = name;
                string actualName = testPlanet.Name;
                Assert.AreEqual(expectedName, actualName);
                double expectedBudget = budget;
                double actualBudget = testPlanet.Budget;
                Assert.AreEqual(expectedName, actualName);
                Assert.IsNotNull(weaponField.GetValue(testPlanet));

            }

            [Test]
            public void CreatingAPlanetWithNullNameShouldThrowArgumentExpection()
            {
                //Assign
                string name = null;
                double budget = 3.14;
                //Act && Assert
                Assert.Throws<ArgumentException>(() => new Planet(name,budget), "Invalid planet Name");
            }

            [Test]
            public void CreatingAPlanetWithEmptyNameShouldThrowArgumentExpection()
            {
                //Assign
                string name = "";
                double budget = 3.14;
                //Act && Assert
                Assert.Throws<ArgumentException>(() => new Planet(name, budget), "Invalid planet Name");
            }
            [TestCase(-1)]
            [TestCase(-0.01)]
            public void CreatingAPlanetWitNegativeBudgetShouldThrowArgumentExpection(double value)
            {
                //Assign
                string name = "K2";
                double budget = value;
                //Act && Assert
                Assert.Throws<ArgumentException>(() => new Planet(name, budget), "Budget cannot drop below Zero!");
            }

            [Test]
            public void AddWeaponMethodShouldAddWeaponToThePlanetWeaponCollection()
            {
                //Assign
                string name = "K2";
                double budget = 3.14;
                Planet testPlanet = new Planet(name, budget);
                string weaponName = "GandalfsWeapon";
                double price = 42;
                int destructionLevel = 15;
                Weapon GandalfsWeapon = new Weapon(weaponName,price, destructionLevel);
                testPlanet.AddWeapon(GandalfsWeapon);
                //Act
                int expectedCountOfWeapons = 1;
                int actualCountOfWeapons = testPlanet.Weapons.Count();
                //Assert
                Assert.AreEqual(expectedCountOfWeapons, actualCountOfWeapons);
            }
            [Test]
            public void AddWeaponMethodShouldThrowInvalidOperationExceptionIfWeaponAlreadyExist()
            {
                //Assign
                string name = "K2";
                double budget = 3.14;
                Planet testPlanet = new Planet(name, budget);
                string weaponName = "GandalfsWeapon";
                double price = 42;
                int destructionLevel = 15;
                Weapon GandalfsWeapon = new Weapon(weaponName, price, destructionLevel);
                testPlanet.AddWeapon(GandalfsWeapon);
                //Act && Assert
                Assert.Throws<InvalidOperationException>(() => testPlanet.AddWeapon(GandalfsWeapon), $"There is already a {GandalfsWeapon.Name} weapon.");

            }

            [Test]
            public void WeaponsShoudReturnACollectionOfTheCurrentWeaponsInThePlanet()
            {
                //Assign
                string name = "K2";
                double budget = 3.14;
                Planet testPlanet = new Planet(name, budget);
                double price = 42;
                int destructionLevel = 15;
                //Act
                Weapon GandalfsWeapon = new Weapon("GandalfsWeapon", price, destructionLevel);
                Weapon FrodosWeapon = new Weapon("FrodosWeapon", price, destructionLevel);
                Weapon BilbosWeapon = new Weapon("BilbosWeapon", price, destructionLevel);
                Weapon SamsWeapon = new Weapon("SamsWeapon", price, destructionLevel);
                testPlanet.AddWeapon(GandalfsWeapon);
                testPlanet.AddWeapon(FrodosWeapon);
                testPlanet.AddWeapon(BilbosWeapon);
                testPlanet.AddWeapon(SamsWeapon);
                ICollection<Weapon> expectedWeapons = new List<Weapon>();
                expectedWeapons.Add(GandalfsWeapon);
                expectedWeapons.Add(FrodosWeapon);
                expectedWeapons.Add(BilbosWeapon);
                expectedWeapons.Add(SamsWeapon);
                ICollection<Weapon> actualWeapons = testPlanet.Weapons.ToList();
                //Assert
                CollectionAssert.AreEqual(expectedWeapons, actualWeapons);
            }

            [Test]
            public void MilitaryPowerRatioPropertyShouldCalculateSumOfTheWeaponsInThePlanetDestructionLevel()
            {
                //Assign
                string name = "K2";
                double budget = 3.14;
                Planet testPlanet = new Planet(name, budget);
                double price = 42;
                int destructionLevel = 15;
                //Act
                Weapon GandalfsWeapon = new Weapon("GandalfsWeapon", price, destructionLevel);
                Weapon FrodosWeapon = new Weapon("FrodosWeapon", price, destructionLevel);
                Weapon BilbosWeapon = new Weapon("BilbosWeapon", price, destructionLevel);
                Weapon SamsWeapon = new Weapon("SamsWeapon", price, destructionLevel);
                testPlanet.AddWeapon(GandalfsWeapon);
                testPlanet.AddWeapon(FrodosWeapon);
                testPlanet.AddWeapon(BilbosWeapon);
                testPlanet.AddWeapon(SamsWeapon);
                //Assert
                double expectedMilitaryPowerRatio = 15 * 4;
                double actualMilitaryPowerRatio = testPlanet.MilitaryPowerRatio;
                Assert.AreEqual(expectedMilitaryPowerRatio, actualMilitaryPowerRatio);
            }

            [TestCase(0)]
            [TestCase(100)]
            [TestCase(500)]
            [TestCase(16080)]
            public void ProfitMethodShouldIncreaseBudget(double value)
            {
                //Assign
                string name = "K2";
                double budget = 3.14;
                Planet testPlanet = new Planet(name, budget);
                //Act
                testPlanet.Profit(value);
                double expectedBudget = budget + value;
                double actualBudget = testPlanet.Budget;
                //Assert
                Assert.AreEqual(expectedBudget, actualBudget);
            }

            [TestCase(1)]
            [TestCase(100)]
            [TestCase(500)]
            [TestCase(1000)]
            public void SpendFundsMethodShouldReduceBudgetIfAmountIsBelowCurrentBudgetOREqual(double value)
            {
                //Assign
                string name = "K2";
                double budget = 1000;
                Planet testPlanet = new Planet(name, budget);
                //Act
                testPlanet.SpendFunds(value);
                double expectedBudget = budget - value;
                double actualBudget = testPlanet.Budget;
                //Assert
                Assert.AreEqual(expectedBudget, actualBudget);
                
            }

            [TestCase(1001)]
            [TestCase(1005)]
            [TestCase(5007)]
            public void SpendFundsMethodShouldThrowInvalidOperationExceptionIfBudgetIsEqualOrBelowAmount(double value)
            {
                //Assign
                string name = "K2";
                double budget = 1000;
                Planet testPlanet = new Planet(name, budget);
                //Act && Assert
                Assert.Throws<InvalidOperationException>(() => testPlanet.SpendFunds(value), "Not enough funds to finalize the deal.");

            }

            [Test]
            public void RemoveWeaponShouldRemoveAWeaponIfItExistInTheWeaponsCollection()
            {
                //Assign
                string name = "K2";
                double budget = 3.14;
                Planet testPlanet = new Planet(name, budget);
                double price = 42;
                int destructionLevel = 15;
                //Act
                Weapon GandalfsWeapon = new Weapon("GandalfsWeapon", price, destructionLevel);
                Weapon FrodosWeapon = new Weapon("FrodosWeapon", price, destructionLevel);
                Weapon BilbosWeapon = new Weapon("BilbosWeapon", price, destructionLevel);
                Weapon SamsWeapon = new Weapon("SamsWeapon", price, destructionLevel);
                testPlanet.AddWeapon(GandalfsWeapon);
                testPlanet.AddWeapon(FrodosWeapon);
                testPlanet.AddWeapon(BilbosWeapon);
                testPlanet.AddWeapon(SamsWeapon);
                testPlanet.RemoveWeapon(SamsWeapon.Name);

                int expectedCount = 3;
                int actualCount = testPlanet.Weapons.Count();

                Assert.AreEqual(expectedCount, actualCount);
            }

            [Test]
            public void RemoveWeaponShouldNotRemoveAWeaponIfItDoenstExistInTheWeaponsCollection()
            {
                //Assign
                string name = "K2";
                double budget = 3.14;
                Planet testPlanet = new Planet(name, budget);
                double price = 42;
                int destructionLevel = 15;
                //Act
                Weapon GandalfsWeapon = new Weapon("GandalfsWeapon", price, destructionLevel);
                Weapon FrodosWeapon = new Weapon("FrodosWeapon", price, destructionLevel);
                Weapon BilbosWeapon = new Weapon("BilbosWeapon", price, destructionLevel);
                Weapon SamsWeapon = new Weapon("SamsWeapon", price, destructionLevel);
                testPlanet.AddWeapon(GandalfsWeapon);
                testPlanet.AddWeapon(FrodosWeapon);
                testPlanet.AddWeapon(BilbosWeapon);
                testPlanet.AddWeapon(SamsWeapon);
                testPlanet.RemoveWeapon("WeaponThatDoesntExist");

                int expectedCount = 4;
                int actualCount = testPlanet.Weapons.Count();

                Assert.AreEqual(expectedCount, actualCount);
            }

            [Test]
            public void UpgradeWeaponShouldIncreaseTheWantedWeaponDestructionLevelFromThePlanetsWeaponCollectionIfItExists()
            {
                //Assign
                string name = "K2";
                double budget = 3.14;
                Planet testPlanet = new Planet(name, budget);
                double price = 42;
                int destructionLevel = 15;
                //Act
                Weapon GandalfsWeapon = new Weapon("GandalfsWeapon", price, destructionLevel);
                testPlanet.AddWeapon(GandalfsWeapon);
                testPlanet.UpgradeWeapon(GandalfsWeapon.Name);
                Weapon upgradedWeapon = testPlanet.Weapons.FirstOrDefault(x => x.Name == "GandalfsWeapon");

                int expectedDestructionLevel = destructionLevel + 1;
                int actualDestructionLevel = upgradedWeapon.DestructionLevel;
                //Assert
                Assert.AreEqual(expectedDestructionLevel, actualDestructionLevel);
            }

            [Test]
            public void UpgradeWeaponShouldThrownvalidOperationExceptionIfWeaponDoesntExistInThePlanetsWeaponsCollection()
            {
                //Assign
                string name = "K2";
                double budget = 3.14;
                Planet testPlanet = new Planet(name, budget);
                double price = 42;
                int destructionLevel = 15;
                //Act
                Weapon GandalfsWeapon = new Weapon("GandalfsWeapon", price, destructionLevel);
                testPlanet.AddWeapon(GandalfsWeapon);
                //Assert 
                Assert.Throws<InvalidOperationException>(() => testPlanet.UpgradeWeapon("NonExistingWeapon"), $"NonExistingWeapon does not exist in the weapon repository of {testPlanet.Name}");

            }

            [Test]
            public void DestructOpponentMethodShouldDestroyAnEnemyWithWeakerMilitaryPowerRatio()
            {
                //Assign
                //StrongerPlanee
                double price = 42;
                int destructionLevel = 15;
                Planet strongerPlanet = new Planet("VeryStrongPlanet", 69);
                Weapon GandalfsWeapon = new Weapon("GandalfsWeapon", price, destructionLevel);
                Weapon FrodosWeapon = new Weapon("FrodosWeapon", price, destructionLevel);
                Weapon BilbosWeapon = new Weapon("BilbosWeapon", price, destructionLevel);
                Weapon SamsWeapon = new Weapon("SamsWeapon", price, destructionLevel);
                strongerPlanet.AddWeapon(GandalfsWeapon);
                strongerPlanet.AddWeapon(FrodosWeapon);
                strongerPlanet.AddWeapon(BilbosWeapon);
                strongerPlanet.AddWeapon(SamsWeapon);

                //WeakerPlanet
                Planet weakerPlanet = new Planet("PoorWeakPlanet", 41);
                Weapon weakGandalfsWeapon = new Weapon("GandalfsWeapon", price, 1);
                weakerPlanet.AddWeapon(weakGandalfsWeapon);

                //Act
                double strongPlanetMilitaryRatio = strongerPlanet.MilitaryPowerRatio;
                double weakPlanetMilitaryRatio = weakerPlanet.MilitaryPowerRatio;

                string expectedResult = $"{weakerPlanet.Name} is destructed!";
                string actualResult = strongerPlanet.DestructOpponent(weakerPlanet);
                //Assert
                Assert.AreEqual(expectedResult, actualResult);
            }

            [Test]
            public void DestructOpponentMethodShouldInvalidOperationExceptionIfAWeakerOpponentTriesToAttackAStrongerOne()
            {
                //Assign
                //StrongerPlanee
                double price = 42;
                int destructionLevel = 15;
                Planet strongerPlanet = new Planet("VeryStrongPlanet", 69);
                Weapon GandalfsWeapon = new Weapon("GandalfsWeapon", price, destructionLevel);
                Weapon FrodosWeapon = new Weapon("FrodosWeapon", price, destructionLevel);
                Weapon BilbosWeapon = new Weapon("BilbosWeapon", price, destructionLevel);
                Weapon SamsWeapon = new Weapon("SamsWeapon", price, destructionLevel);
                strongerPlanet.AddWeapon(GandalfsWeapon);
                strongerPlanet.AddWeapon(FrodosWeapon);
                strongerPlanet.AddWeapon(BilbosWeapon);
                strongerPlanet.AddWeapon(SamsWeapon);

                //WeakerPlanet
                Planet weakerPlanet = new Planet("PoorWeakPlanet", 41);
                Weapon weakGandalfsWeapon = new Weapon("GandalfsWeapon", price, 1);
                weakerPlanet.AddWeapon(weakGandalfsWeapon);

                //Act
                double strongPlanetMilitaryRatio = strongerPlanet.MilitaryPowerRatio;
                double weakPlanetMilitaryRatio = weakerPlanet.MilitaryPowerRatio;

                //Assert
                Assert.Throws<InvalidOperationException>(() => weakerPlanet.DestructOpponent(strongerPlanet), $"{strongerPlanet.Name} is too strong to declare war to!");

            }
        }
    }
}
