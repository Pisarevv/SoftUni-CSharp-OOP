namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void ArenaShouldInitializeWithAnEmptyConstructor()
        {
            //Assign, Act
            Arena arena = new Arena();
            //Assert
            Assert.IsNotNull(arena);
        }

        [Test]
        public void ArenaEnrollMethodShouldAddAWarriorThatDoesNotExistInTheArena()
        {
            //Assign
            Arena arena = new Arena();
            Warrior warrior1 = new Warrior("Pesho", 50, 60);
            Warrior warrior2 = new Warrior("Ivan", 30, 70);
            List<Warrior> warriorsToAdd = new List<Warrior>();
            warriorsToAdd.Add(warrior1);
            warriorsToAdd.Add(warrior2);
            //Act
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            //Assert
            List<Warrior> expectedWarriors = warriorsToAdd;
            List<Warrior> actualWarriors = arena.Warriors.ToList();

            CollectionAssert.AreEqual(expectedWarriors, actualWarriors);
                      
        }
        [Test]
        public void ArenaEnrollMethodShoudThrowInvalidOperationExceptionWhenTryingToAddAnWarriorWithName()
        {
            //Assign
            Arena arena = new Arena();
            Warrior warrior1 = new Warrior("Pesho", 50, 60);
            Warrior warrior2 = new Warrior("Pesho", 30, 70);
            //Act and Assert
            Assert.That(() =>
            {
                arena.Enroll(warrior1);
                arena.Enroll(warrior2);
            }, Throws.TypeOf<InvalidOperationException>(), "Warrior is already enrolled for the fights!");
            
        }

        [Test]
        public void PropertyCountShoudReturnTheActualCountOfTheWarriorsForTheFight()
        {
            //Assign
            Arena arena = new Arena();
            Warrior warrior1 = new Warrior("Pesho", 50, 60);
            Warrior warrior2 = new Warrior("Ivan", 30, 70);
            List<Warrior> warriorsToAdd = new List<Warrior>();
            warriorsToAdd.Add(warrior1);
            warriorsToAdd.Add(warrior2);
            //Act
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            //Assert
            int exepctedount = warriorsToAdd.Count;
            int actualCount = arena.Count;

            Assert.AreEqual(exepctedount, actualCount);
        }

        [Test]
        public void FightMethodShouldCallExistingWarriorsAndLetThemAttackEachother()
        {
            int AwarriorHP = 100;
            int DwarriorHP = 100;
            int AwarriorAttack = 40;
            int DwarriorAttack = 45;
            //Assign
            Warrior Awarrior = new Warrior("Pesho", AwarriorAttack, AwarriorHP);
            Warrior Dwarrior = new Warrior("Ivan", DwarriorAttack, DwarriorHP);
            Arena arena = new Arena();
            //Act
            arena.Enroll(Awarrior);
            arena.Enroll(Dwarrior);
            arena.Fight("Pesho", "Ivan");

            int expectedAwarriorHP = AwarriorHP - DwarriorAttack;
            int actualAwarriorHP = Awarrior.HP;
            int expectedDwarriorHP = DwarriorHP - AwarriorAttack;
            int actualDwarriorHP = Dwarrior.HP;
            //Assert
            Assert.AreEqual(expectedAwarriorHP, actualAwarriorHP);
            Assert.AreEqual(expectedDwarriorHP, actualDwarriorHP);

        }

        [Test]
        public void AttackMethodShouldThrowInvalidOperationExceptionWhenAnAttackerDoesNotExist()
        {

            int AwarriorHP = 100;
            int DwarriorHP = 100;
            int AwarriorAttack = 40;
            int DwarriorAttack = 45;
            //Assign
            Warrior Awarrior = new Warrior("Pesho", AwarriorAttack, AwarriorHP);
            Warrior Dwarrior = new Warrior("Ivan", DwarriorAttack, DwarriorHP);
            Arena arena = new Arena();
            //Act
            arena.Enroll(Awarrior);
            arena.Enroll(Dwarrior);
            //Assert
            Assert.That(() =>
            {
                arena.Fight("Milko", "Ivan");
            }, Throws.TypeOf<InvalidOperationException>(), $"There is no fighter with name Milko enrolled for the fights!");
        }
        [Test]
        public void AttackMethodShouldThrowInvalidOperationExceptionWhenDefenderDoesNotExist()
        {

            int AwarriorHP = 100;
            int DwarriorHP = 100;
            int AwarriorAttack = 40;
            int DwarriorAttack = 45;
            //Assign
            Warrior Awarrior = new Warrior("Pesho", AwarriorAttack, AwarriorHP);
            Warrior Dwarrior = new Warrior("Ivan", DwarriorAttack, DwarriorHP);
            Arena arena = new Arena();
            //Act
            arena.Enroll(Awarrior);
            arena.Enroll(Dwarrior);
            //Assert
            Assert.That(() =>
            {
                arena.Fight("Pesho", "Mladen");
            }, Throws.TypeOf<InvalidOperationException>(), $"There is no fighter with name Mladen enrolled for the fights!");
        }
    }
}
