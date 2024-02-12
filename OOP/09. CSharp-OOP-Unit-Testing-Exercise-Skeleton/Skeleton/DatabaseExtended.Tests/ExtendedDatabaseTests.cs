namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Data.Common;
    using System.Runtime.CompilerServices;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person dummyPerson1;
        private Person dummyPerson2;
        private Database defDb;

        [SetUp]
        public void SetUp()
        {
            defDb = new Database();

            dummyPerson1 = new Person(12345, "Person1");

            dummyPerson2 = new Person(6789, "Person2");
        }

        [Test]
        public void ConstructorShouldInitializeColllectionProperly()
        {
            Person[] persons = new Person[] { dummyPerson1, dummyPerson2 };

            var db = new Database(persons);

            int expectedCount = 2;

            int actualCount = db.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldAddValidPerson()
        {
            defDb.Add(dummyPerson1);

            var expected = dummyPerson1;

            var actual = defDb.FindById(12345);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddShouldThrowExceptionIfCountIsBiggerThanLimit()
        {

            var persons = new Person[]
            {
                dummyPerson1,
                dummyPerson2,
                new Person(2342, "Person3"),
                new Person(1234, "Person4"),
                new Person(3452, "Person5"),
                new Person(3466, "Person6"),
                new Person(4567, "Person7"),
                new Person(5688, "Person8"),
                new Person(2349, "Person9"),
                new Person(1231, "Person10"),
                new Person(1232, "Person11"),
                new Person(1233, "Person12"),
                new Person(1235, "Person13"),
                new Person(1236, "Person14"),
                new Person(1237, "Person15"),
                new Person(1238, "Person16")

            };

            var db = new Database(persons);

            Assert.Throws<InvalidOperationException>(() =>
            {

                db.Add(new Person(99999, "Pesho"));
            }, "Array's capacity must be exactly 16 integers!");

        }

        [Test]
        public void AddShouldThrowExceptionIfCollectionContainsThisUserName()
        {
            defDb.Add(dummyPerson1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                defDb.Add(new Person(6666, "Person1"));
            }, "There is already user with this username!");

        }

        [Test]
        public void AddShouldThrowExceptionIfCollectionContainsThisID()
        {
            defDb.Add(dummyPerson1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                defDb.Add(new Person(12345, "Stamat"));
            }, "There is already user with this Id!");

        }

        [Test]
        public void RemoveShouldReduceCount()
        {
            defDb.Add(dummyPerson1);
            defDb.Add(dummyPerson2);

            defDb.Remove();

            int expCount = 1;
            int actualCount = defDb.Count;

            Assert.AreEqual(expCount, actualCount);

        }

        [Test]
        public void RemoveFromEmptyDatabaseShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                defDb.Remove();
            });
        }

        [Test]
        public void FindByUsernameShouldReturnPersonWhenUsernameIsValid() 
        {
            defDb.Add(dummyPerson1);
            defDb.Add(dummyPerson2);

            var expectedPerson = dummyPerson1;

            var actualPerson = defDb.FindByUsername("Person1");

            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionWhenUsernameDoesNotExist()
        {
            defDb.Add(dummyPerson1);
            defDb.Add(dummyPerson2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                defDb.FindByUsername("Pesho Malkiq");
            }, "No user is present by this username!");

        }

        [Test]
        public void FindByUsernameShouldThrowExceptionWhenStringIsNull()
        {
            defDb.Add(dummyPerson1);
            defDb.Add(dummyPerson2);

            Assert.Throws<ArgumentNullException>(() =>
            {
                defDb.FindByUsername(null);
            }, "Username parameter is null!");

        }
        [Test]
        public void FindByIdSouldReturnExistantPerson()
        {
            defDb.Add(dummyPerson1);
            defDb.Add(dummyPerson2);
            var expectedPerson = dummyPerson1;
            var actualPerson = defDb.FindById(12345);

            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [TestCase(- 1)]
        [TestCase(- 55)]
        [TestCase(- 50000)]
        public void FindByIdShouldThrowExceptionWhenIdIsNegative(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                defDb.FindById(id);

            }, "Id should be a positive number!");

        }

        [TestCase(0)]
        [TestCase(15234)]
        [TestCase(150000000)]
        public void FindByIdShouldThrowExceptionWhenThereIsNoSuchId(int id)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                defDb.FindById(id);

            }, "No user is present by this ID!");

        }
    }
}