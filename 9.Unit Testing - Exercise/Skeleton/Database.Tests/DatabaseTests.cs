namespace Database.Tests
{
    using NUnit.Compatibility;
    using NUnit.Framework;
    using System;
    using System.Reflection;
    using System.Linq;
    using System.Collections.Generic;

    [TestFixture]
    public class DatabaseTests
    {
       


        //Test database constructor 
        [TestCase(new int[] {1})]
        [TestCase(new int[] {1,2,3,4,5})]
        public void TestIfDbConstructorWorksCorrectly(int[] values)
        {
            Database db = new Database(values);

            Type dbType = db.GetType();
            object instanceOfDb = Activator.CreateInstance(dbType,values);
            FieldInfo dbDataField = dbType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.Name == "data").FirstOrDefault();
            var fieldValues = (int[])dbDataField.GetValue(instanceOfDb);
            int[] actualValues = new int[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                actualValues[i] = fieldValues[i];
            }
            int[] expectedValues = values;

            CollectionAssert.AreEqual(actualValues, expectedValues, "Values in the range shoud be exactly the same");
        }

        [TestCase(new int[] {1})]
        [TestCase(new int[] { 1,2,3,4,5 })]
        [TestCase(new int[] {0})]
        public void TestIfArrayCapacityIsExactlly16Indexes(int[] values)
        {
            //Assign
            Database db = new Database(values);
            //Act
            Type dbType = db.GetType();
            object instanceOfDb = Activator.CreateInstance(dbType, values);
            FieldInfo dbDataField = dbType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.Name == "data").FirstOrDefault();
            var fieldValues = (int[])dbDataField.GetValue(instanceOfDb);

            //Assert
            int expectedCount = 16;
            int actualCount = fieldValues.Length;

            Assert.AreEqual(expectedCount, actualCount , "The count shoud be identical");
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void TestIfAnInvalidOperatoExceptionIsThrownWhenCapacityIsOver16(int[] values)
        {
            //Assign,Act,Assert
            Assert.That(() =>
            new Database(values), Throws.TypeOf<InvalidOperationException>().With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));

        }
        [TestCase(new int[] { 0 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17})]
        public void TestFetchMethod(int[] values)
        {
            Database db = new Database(values);
            Type dbType = db.GetType();
            object instanceOfDb = Activator.CreateInstance(dbType, values);
            FieldInfo dbDataField = dbType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.Name == "data").FirstOrDefault();
            var fieldValues = (int[])dbDataField.GetValue(instanceOfDb);
            int[] actualValues = db.Fetch();
            int[] expectedValues = values;
            Assert.AreEqual(expectedValues, actualValues);
        }
        //Using Fetch() after i tested it and it works correctly
        [TestCase(new int[] { 0 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        public void TestAddMethodThatWorksCorrecty(int[] values)
        {
            Database db = new Database();
            foreach(int value in values)
            {
                db.Add(value);
            }
            int[] expectedValues = values;
            int[] actualValues = db.Fetch();
            Assert.AreEqual(expectedValues, actualValues);
        }
        [TestCase(new int[] { 0 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        public void TestCountMethod(int[] values)
        {
            Database db = new Database(values);
            int expectedCount = values.Length;
            int actualCount = db.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 })]
        public void TestIfInvalidOperationExceptionIsThrownWhenTryingToAdd17Element(int[] values)
        {
            Database db = new Database();
            Assert.That(() =>
            {
                foreach (int value in values)
                {
                    db.Add(value);
                }
            }, Throws.TypeOf<InvalidOperationException>()
            .With.Message.EqualTo("Array's capacity must be exactly 16 integers!")
            );
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        public void TestIfRemoveMethodIsRemovingLastElement(int[] values)
        {
            List<int> valuesList = values.ToList();
            Database db = new Database(values);
            db.Remove();
            valuesList.RemoveAt(valuesList.Count-1);

            int[] expectedValues = valuesList.ToArray();
            int[] actualValues = db.Fetch();

            Assert.That(actualValues, Is.EqualTo(expectedValues));
        }

        [Test]
        public void TestIfRemovingFromAnEmptyCollectionThrowsInvalidOperationException()
        {
            Database db = new Database();
            Assert.That(() =>
            db.Remove(), Throws.TypeOf<InvalidOperationException>().With.Message.EqualTo("The collection is empty!"));
        }
    }
}
