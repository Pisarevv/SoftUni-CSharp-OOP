namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void CreateObjects()
        {
            
        }
        
        //Test database constructor 
        [Test]
        public void DatabaseConstructorShoudAddObejtOfTypePersonAndTestFieldPersons()
        {
            //Assign
            Person person = new Person(13, "Peter");
            Database db = new Database(person);
            //Act
            Type dbClass = db.GetType();
            FieldInfo field = dbClass.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.Name == "persons").FirstOrDefault();
            Person[] fieldValues = field.GetValue(db) as Person[];
            //Assert
            string expectedName = "Peter";
            long expectedID = 13;
            string actualName = fieldValues[0].UserName;
            long actualID = fieldValues[0].Id;
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedID, actualID);
        }

        [TestCase(new int[] {1})]
        [TestCase(new int[] {2})]
        [TestCase(new int[] {10})]
        [TestCase(new int[] {16})]
        public void DatabaseConstructorShoudAddArrayOfTypePersonBetween0and16(int[] values)
        {
            Person[] persons = GeneratePersons(values[0]);
            //Assign
            Database db = new Database(persons);
            //Act
            Type dbClass = db.GetType();
            FieldInfo field = dbClass.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.Name == "persons").FirstOrDefault();
            Person[] fieldValues = field.GetValue(db) as Person[];
            //Assert
            for (int i = 0; i < values.Length; i++)
            {
                Person expectedPerson = persons[i];
                Person actualPerson = fieldValues[i];

                Assert.AreEqual(expectedPerson, actualPerson);
            }
        }
        [TestCase(new int[] { 17 })]
        public void DatabaseConstructorShoudThrowArgumentExceptionWhenPersonsToAddAreMoreThan16(int[] values)
        {
            //Assign 
            Person[] persons = GeneratePersons(values[0]);
            Database db = new Database();
            //Act Assert
            Assert.That(() => db = new Database(persons), Throws.TypeOf<ArgumentException>()
                .With.Message.EqualTo("Provided data length should be in range [0..16]!"));           
        }
       
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 2 })]
        [TestCase(new int[] { 10 })]
        [TestCase(new int[] { 16 })]
        public void AddRangeMethodShoudAddUpto16Persons(int[] values)
        {
            //Assign
            Person[] persons = GeneratePersons(values[0]);          
            Database db = new Database();
            //Act
            foreach(Person person in persons)
            {
                db.Add(person);
            }
            Type dbClass = db.GetType();
            FieldInfo field = dbClass.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.Name == "persons").FirstOrDefault();
            Person[] fieldValues = field.GetValue(db) as Person[];
            //Assert
            for (int i = 0; i < values.Length; i++)
            {
                Person expectedPerson = persons[i];
                Person actualPerson = fieldValues[i];

                Assert.AreEqual(expectedPerson, actualPerson);
            }
        }

        [TestCase(new int[] { 17 })]
        [TestCase(new int[] { 19 })]
        public void AddMethodShoudThrowArgumentExceptionWhenPersonsToAddAreMoreThan16(int[] values)
        {
            //Assign
            Person[] persons = GeneratePersons(values[0]);
            Database db = new Database();
            //Act & Assert
            Assert.That(() =>
            {
                foreach (Person person in persons)
                {
                    db.Add(person);
                }
            },Throws.TypeOf<InvalidOperationException>().With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));          
            
        }
        //After testing add method i am using it to add objects
        public void AddMethodShouldNotAddAPersonWithAnExistingUsername()
        {
            //Assign
            Person person1 = new Person(1, "person1");
            Person person2 = new Person(2, "person1");
            Database db = new Database();
            //Act
            db.Add(person1);
            //Assert
            Assert.That(() =>
            {
                db.Add(person2);
            }, Throws.TypeOf<InvalidOperationException>()
            .With.Message.EqualTo("There is already user with this username!"));

        }

        [Test]
        public void AddMethodShoudNotAddAPersonWithAnExistingID()
        {
            Person person1 = new Person(1, "person1");
            Person person2 = new Person(1, "person2");
            Database db = new Database();
            //Act
            db.Add(person1);
            //Assert
            Assert.That(() =>
            {
                db.Add(person2);
            }, Throws.TypeOf<InvalidOperationException>()
            .With.Message.EqualTo("There is already user with this Id!"));
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 2 })]
        [TestCase(new int[] { 10 })]
        [TestCase(new int[] { 16 })]
        public void CountShoudReturnCorrectCountOfItemsInTheFieldPersons(int[] values)
        {
            //Assign
            Person[] persons = GeneratePersons(values[0]); 
            Database db = new Database(persons);
            //Act && Assert 
            int expectedCount = values[0];
            int actualCount = db.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }




        public Person[] GeneratePersons(int count)
        {
            Person[] generatedPersons = new Person[count];
            for (int i = 0; i < count; i++)
            {
                generatedPersons[i] = new Person(i, "personNumber" + i);    
            }
            return generatedPersons;
        }
    }
}