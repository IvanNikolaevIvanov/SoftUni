namespace Book.Tests
{
    using System;

    using NUnit.Framework;
    [TestFixture]
    public class Tests
    {
        private Book defBook;

        [SetUp]
        public void SetUp()
        {
            defBook = new Book("book1", "Pesho");
        }

        [Test]
        public void ConstructorShouldInitializeBookNameProperly()
        {
            string expectedBookName = "kniga";

            Book book = new Book(expectedBookName, "Pesho");

            Assert.AreEqual(expectedBookName, book.BookName);

        }

        [Test]
        public void ConstructorShouldInitializeAuthorProperly()
        {
            string expectedAuthor = "Peshkata";

            Book book = new Book("kniga1", expectedAuthor);

            Assert.AreEqual(expectedAuthor, book.Author);

        }

        [Test]
        public void FootNoteCountShouldReturnCorrectCount()
        {
            int actualFootNoteCnt = defBook.FootnoteCount;


            Assert.AreEqual(0, actualFootNoteCnt);

        }

        [TestCase("A")]
        [TestCase("AAaaa")]
        [TestCase("123123")]
        [TestCase("Pesho Malkiq i Dve Lica")]
        public void BookNameSetterShouldSetUpWithCorrectData(string bookName)
        {
            Book book = new Book(bookName, "Author1");

            Assert.AreEqual(bookName, book.BookName);

        }

       
        [TestCase(null)]
        [TestCase("")]
        public void BookNameSetterShouldThrow(string bookName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(bookName, "Author1");
            });

        }

        [TestCase("A")]
        [TestCase("AAaaa")]
        [TestCase("123123")]
        [TestCase("Pesho Malkiq i Dve Lica")]
        public void AuthorSetterShouldSetUpWithCorrectData(string Author)
        {
            Book book = new Book("kniga123", Author);

            Assert.AreEqual(Author, book.Author);

        }

        [TestCase(null)]
        [TestCase("")]
        public void AuthorSetterShouldThrow(string Author)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("kniga123", Author);
            });

        }

        [Test]
        public void AddFootNoteShouldAdd()
        {
            defBook.AddFootnote(123, "abvgd");
            int expectedFootNoteCount = 1;
            int actualFootNoteCount = defBook.FootnoteCount;
            Assert.AreEqual(expectedFootNoteCount, actualFootNoteCount);
           
        }

        [Test]
        public void AddFootNoteShouldThrow()
        {
            defBook.AddFootnote(123, "abvgd");

            Assert.Throws<InvalidOperationException>(() =>
            {
                defBook.AddFootnote(123, "abvgd");
            }, "Footnote already exists!");

        }

        [Test]
        public void FindFootnoteShouldFindExistingFootNote() 
        {
            defBook.AddFootnote(123, "abvgd");

            string expectedFootNote = "Footnote #123: abvgd";

            string actualFootNote = defBook.FindFootnote(123);

            Assert.AreEqual(expectedFootNote, actualFootNote);
        }

        [Test]
        public void FindFootnoteShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                defBook.FindFootnote(654);
            });
        }

        [Test]
        public void AlterFootnoteShouldAlterText()
        {
            defBook.AddFootnote(123, "abvgd");
            string expectedText = "Footnote #123: Apple";
            defBook.AlterFootnote(123, "Apple");

            string actualNewText = defBook.FindFootnote(123);

            Assert.AreEqual(expectedText, actualNewText);

        }

        [Test]
        public void AlterFootnoteShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                defBook.AlterFootnote(798, "newText");

            });

        }
    }
}