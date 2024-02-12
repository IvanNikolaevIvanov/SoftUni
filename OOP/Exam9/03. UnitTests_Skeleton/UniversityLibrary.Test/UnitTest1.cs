namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Dynamic;
    using System.Text;

    [TestFixture]

    public class Tests
    {
        private TextBook book1;
        private UniversityLibrary university1;

        [SetUp]
        public void Setup()
        {
            book1 = new TextBook("kniga", "Pesho", "roman");
            university1 = new UniversityLibrary();
        }

        [Test]
        public void CtorShouldInitList()
        {
            UniversityLibrary library= new UniversityLibrary();

            Assert.AreEqual(0, library.Catalogue.Count);

        }

        [Test]
        public void AddTextBookShouldChangeInventoryNumber()
        {
            university1.AddTextBookToLibrary(book1);
            Assert.AreEqual(1, book1.InventoryNumber);

        }

        [Test]
        public void AddTextBookShouldAddToList()
        {
            university1.AddTextBookToLibrary(book1);
            Assert.AreEqual(1, university1.Catalogue.Count);

        }

        [Test]
        public void AddTextBookShouldReturnString()
        {
            string actualString = university1.AddTextBookToLibrary(book1);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Book: kniga - 1");
            sb.AppendLine($"Category: roman");
            sb.AppendLine($"Author: Pesho");

            string expString = sb.ToString().TrimEnd();

            Assert.AreEqual(expString, actualString);

        }

        [Test]
        public void LoanTextBookShouldReturnString()
        {
            university1.AddTextBookToLibrary(book1);

            string actualString = university1.LoanTextBook(1, "Gosho");

            string expString = "kniga loaned to Gosho.";

            Assert.AreEqual(expString, actualString);

        }

        [Test]
        public void LoanTextBookShouldReturnAnotherString()
        {
            university1.AddTextBookToLibrary(book1);

            university1.LoanTextBook(1, "Gosho");

            string actualString = university1.LoanTextBook(1, "Gosho");

            string expString = "Gosho still hasn't returned kniga!";

            Assert.AreEqual(expString, actualString);

        }

        [Test]
        public void ReturnTextBookShouldReturnString()
        {
            university1.AddTextBookToLibrary(book1);

            university1.LoanTextBook(1, "Gosho");

            string actualString = university1.ReturnTextBook(1);

            string expString = "kniga is returned to the library.";

            Assert.AreEqual(expString, actualString);

        }

        [Test]
        public void ReturnTextBookShouldEmptyHolder()
        {
            university1.AddTextBookToLibrary(book1);

            university1.LoanTextBook(1, "Gosho");

            university1.ReturnTextBook(1);

            string actualString = book1.Holder;

            string expString = string.Empty;

            Assert.AreEqual(expString, actualString);

        }

    }
}