namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void WarriorConstructorShoudGenerateAWarrior()
        {
            //Assing and Act
            Warrior warrior = new Warrior("Pesho", 60, 70);
            //Assert
            Assert.That(warrior, Is.Not.Null);
        }
        [Test]
        public void WarriorNamePropertyGetterShoudReturnWarriorName()
        {
            Warrior warrior = new Warrior("Pesho", 60, 70);
            string expectedName = "Pesho";
            string actualName = warrior.Name;
            Assert.AreEqual(expectedName, actualName);
        }
        [Test]
        public void WarriorNamePropertySetterShoudThrowArgumentExceptionWhenInputIsNull()
        {
            //Assign,Act,Assert
            Assert.That(() =>
            {
                Warrior warrior = new Warrior(null, 60, 70);
            }
            , Throws.TypeOf<ArgumentException>(), "Name should not be empty or whitespace!"
            );            
        }
        [Test]
        public void WarriorNamePropertySetterShoudThrowArgumentExceptionWhenInputIsWhiteSpace()
        {
            //Assign,Act,Assert
            Assert.That(() =>
            {
                Warrior warrior = new Warrior(" ", 60, 70);
            }
            , Throws.TypeOf<ArgumentException>(), "Name should not be empty or whitespace!"
            );
        }
        [TestCase(28)]
        [TestCase(29)]
        [TestCase(30)]
        public void WarriorDamagePropertyGetterShoudReturnWarriorHealth(int value)
        {
            Warrior warrior = new Warrior("Pesho", value, 70);
            int expectedDamage = value;
            int actualDamage = warrior.Damage;
            Assert.AreEqual(expectedDamage, actualDamage);
        }

        [Test]
        public void WarriorDamagePropertySetterShoudThrowArgumentExceptionWhenInputIsZero()
        {
            //Assign,Act,Assert
            Assert.That(() =>
            {
                Warrior warrior = new Warrior("Pesho", 0, 70);
            }
            , Throws.TypeOf<ArgumentException>(), "Damage value should be positive!"
            );
        }
        [Test]
        public void WarriorDamagePropertySetterShoudThrowArgumentExceptionWhenInputIsNegative()
        {
            //Assign,Act,Assert
            Assert.That(() =>
            {
                Warrior warrior = new Warrior("Pesho", -60, 70);
            }
            , Throws.TypeOf<ArgumentException>(), "Damage value should be positive!"
            );
        }

        [TestCase(28)]
        [TestCase(29)]
        [TestCase(30)]
        public void WarriorHealthPropertyGetterShoudReturnWarriorHealth(int value)
        {
            Warrior warrior = new Warrior("Pesho", 60, value);
            int expectedHealth = value;
            int actualHealth = warrior.HP;
            Assert.AreEqual(expectedHealth, actualHealth);
        }


        [TestCase(-1)]
        [TestCase(-29)]
        public void WarriorHealthPropertySetterShoudThrowArgumentExceptionWhenInputIsNegative(int value)
        {
            //Assign,Act,Assert
            Assert.That(() =>
            {
                Warrior warrior = new Warrior("Pesho", 60, value);
            }
            , Throws.TypeOf<ArgumentException>(), "Health value should be positive!");
        }
        [TestCase(28)]
        [TestCase(29)]
        [TestCase(30)]
        public void AttackMethodShouldThrowInvalidOperationExceptionIfAttackerHealthIsBelowOrEqualToRequired(int value)
        {
            //Assign
            Warrior Awarrior = new Warrior("Pesho", 48, value);
            Warrior Dwarrior = new Warrior("Resho", 40, 30);
            //Act and Assert
            Assert.That(() =>
            {
                Awarrior.Attack(Dwarrior);
            }
            , Throws.TypeOf<InvalidOperationException>(), "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(28)]
        [TestCase(29)]
        [TestCase(30)]
        public void AttackMethodThrowInvalidOperationExceptionWhenDefendingWarriorHPisBellowTheRequired(int value)
        {
            //Assign
            Warrior Awarrior = new Warrior("Pesho", 50, 55);
            Warrior Dwarrior = new Warrior("Resho", 40, value);
            //Act and Assert
            Assert.That(() =>
            {
                Awarrior.Attack(Dwarrior);
            }
            , Throws.TypeOf<InvalidOperationException>(), $"Enemy HP must be greater than 30 in order to attack him!");
        }
        [TestCase(50)]
        [TestCase(80)]
        [TestCase(99)]
        public void AttackMethodThrowsInvalidOperationExceptionWhenAttackerIsWeakerThanDefenderWarrior(int value)
        {
            //Assign
            Warrior Awarrior = new Warrior("Pesho", 50, value);
            Warrior Dwarrior = new Warrior("Resho", 100, 500);
            //Act and Assert
            Assert.That(() =>
            {
                Awarrior.Attack(Dwarrior);
            }
            , Throws.TypeOf<InvalidOperationException>(), "You are trying to attack too strong enemy");
        }
        [Test]
        public void AttackMethodShouldAttackDefenderWarrior()
        {
            int AwarriorHP = 100;
            int DwarriorHP = 100;
            int AwarriorAttack = 40;
            int DwarriorAttack = 45;
            //Assign
            Warrior Awarrior = new Warrior("Pesho", AwarriorAttack, AwarriorHP);
            Warrior Dwarrior = new Warrior("Resho", DwarriorAttack, DwarriorHP);
            //Act
            Awarrior.Attack(Dwarrior);
            int expectedAwarriorHP = AwarriorHP - DwarriorAttack;
            int actualAwarriorHP = Awarrior.HP;
            int expectedDwarriorHP = DwarriorHP - AwarriorAttack;
            int actualDwarriorHP = Dwarrior.HP;
            //Assert
            Assert.AreEqual(expectedAwarriorHP, actualAwarriorHP);
            Assert.AreEqual(expectedDwarriorHP, actualDwarriorHP);
        }
        [Test]
        public void AttackMethodFromAttackerWarriorWithGreaterDamageThanDefenderHPShouldKillDefender()
        {
            int AwarriorHP = 100;
            int DwarriorHP = 100;
            int AwarriorAttack = 101;
            int DwarriorAttack = 45;
            //Assign
            Warrior Awarrior = new Warrior("Pesho", AwarriorAttack, AwarriorHP);
            Warrior Dwarrior = new Warrior("Resho", DwarriorAttack, DwarriorHP);
            //Act
            Awarrior.Attack(Dwarrior);
            //Assert
            int expectedDwarriorHP = 0;
            int actualDwarriorHP = Dwarrior.HP;
            
            Assert.AreEqual(expectedDwarriorHP, actualDwarriorHP);
        }

      
        

    }
}