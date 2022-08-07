namespace Book.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void ConstructorShouldInitializeABookWithNameAuthorAndEmptyDictonary()
        {
            //Assign
            string bookName = "Test";
            string author = "TestAuthor";
            //Act
            Book book = new Book(bookName, author);
            Type type = book.GetType();
            FieldInfo noteField = type
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.Name == "footnote").FirstOrDefault();
            var fieldValue = noteField.GetValue(book);
            //Assert
            Assert.AreEqual(bookName, book.BookName);
            Assert.AreEqual(author, book.Author);
            Assert.IsNotNull(fieldValue);
        }

        [Test]
        public void BookNamePropertyShouldThrowArgumentExceptionWhenInputIsEmpty()
        {
            //Assign
            string bookName = "";
            string author = "TestAuthor";
            Book book = null;
            //Act && Assert
            Assert.Throws<ArgumentException>(() => book = new Book(bookName, author), $"Invalid BookName");
        }
        [Test]
        public void BookNamePropertyShouldThrowArgumentExceptionWhenInputIsNull()
        {
            //Assign
            string bookName = null;
            string author = "TestAuthor";
            Book book = null;
            //Act && Assert
            Assert.Throws<ArgumentException>(() => book = new Book(bookName, author), $"Invalid BookName");
        }
        [Test]
        public void AuthorPropertyShouldThrowArgumentExceptionWhenInputIsEmpty()
        {
            //Assign
            string bookName = "Test";
            string author = "";
            Book book = null;
            //Act && Assert
            Assert.Throws<ArgumentException>(() => book = new Book(bookName, author), $"Invalid Author");
        }
        [Test]
        public void AuthorPropertyShouldThrowArgumentExceptionWhenInputIsNull()
        {
            //Assign
            string bookName = "Test";
            string author = null;
            Book book = null;
            //Act && Assert
            Assert.Throws<ArgumentException>(() => book = new Book(bookName, author), $"Invalid Author");
        }
        [Test]
        public void AddFootnoteShouldAddANoteAndFoodnoteCountShouldWorkCorrectly()
        {
            //Assign
            string bookName = "Test";
            string author = "TestAuthor";
            int footNoteNumber = 1;
            string textTodd = "Test123";
            //Act
            Book book = new Book(bookName, author);
            book.AddFootnote(footNoteNumber, textTodd);
            int expectedCount = 1;
            int actualCount = book.FootnoteCount;
            Assert.AreEqual(expectedCount, actualCount);


        }
        [Test]
        public void AddFootnoteShouldThrowInvalidOperationExceptionIfNoteAlreadyExist()
        {
            //Assign
            string bookName = "Test";
            string author = "TestAuthor";
            int footNoteNumber = 1;
            string textTodd = "Test123";
            //Act
            Book book = new Book(bookName, author);
            book.AddFootnote(footNoteNumber, textTodd);
            //Assert
            Assert.Throws<InvalidOperationException>
                (() => book.AddFootnote(footNoteNumber, textTodd), "Footnote already exists!");
        }
    }
}