using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    [TestFixture]

    public class Tests
    {
        private Hotel hotel1;
        private Room room1;

        [SetUp]
        public void Setup()
        {
            hotel1 = new Hotel("Hotel", 4);
            room1 = new Room(2, 100);
        }

        [Test]
        public void ConstructorShouldSetFullName()
        {
            Hotel hotel = new Hotel("Pesho", 2);

            Assert.AreEqual("Pesho", hotel.FullName);
        }

        [Test]
        public void ConstructorShouldCategory()
        {
            Hotel hotel = new Hotel("Pesho", 2);

            Assert.AreEqual(2, hotel.Category);
        }

        [Test]
        public void ConstructorShouldInitiateRoomsList()
        {
            Hotel hotel = new Hotel("Pesho", 2);

            Assert.AreEqual(0, hotel.Rooms.Count);
        }
        [Test]
        public void ConstructorShouldInitiateBookingsList()
        {
            Hotel hotel = new Hotel("Pesho", 2);

            Assert.AreEqual(0, hotel.Bookings.Count);
        }

        [TestCase("a")]
        [TestCase("a1")]
        [TestCase("Abvb1234")]
        [TestCase("Abvb1234 Pesho")]
        public void FullNameSetterShouldSetFullName(string name)
        {
            Hotel hotel = new Hotel(name, 2);

            Assert.AreEqual(name, hotel.FullName);
        }

        [TestCase(null)]
        [TestCase("  ")]
        [TestCase("")]
        public void FullNameSetterShouldThrow(string name)
        {
            
            Assert.Throws<ArgumentNullException>(() =>
            {
                Hotel hotel = new Hotel(name, 2);

            });
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void CategorySetterShouldSetValue(int category)
        {
            Hotel hotel = new Hotel("Pesho", category);

            Assert.AreEqual(category, hotel.Category);
        }

        [TestCase(0)]
        [TestCase(-5)]
        [TestCase(7)]
        [TestCase(10000)]
        public void CategorySetterShouldThrow(int category)
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Hotel hotel = new Hotel("Pesho", category);

            });
        }

        [Test]
        public void TurnoverShouldBeSetToZero()
        {
            Assert.AreEqual(0, hotel1.Turnover);

        }

        [Test]
        public void AddRoomShouldAddRoom()
        {
            hotel1.AddRoom(room1);

            Assert.IsTrue(hotel1.Rooms.Count == 1);

        }

        [Test]
        public void BookRoomShouldBookRoom()
        {
            hotel1.AddRoom(room1);

            hotel1.BookRoom(1, 1, 1, 200);

            Assert.AreEqual(1, hotel1.Bookings.Count);

        }

        [Test]
        public void BookingShouldSetTurnOver()
        {
            hotel1.AddRoom(room1);

            hotel1.BookRoom(1, 1, 1, 200);

            Assert.AreEqual(100, hotel1.Turnover);

        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(-6000)]
        public void BookRoomShouldThrowWhenAdultsNegativeOrZero(int adults)
        {
            hotel1.AddRoom(room1);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel1.BookRoom(adults, 1, 1, 200);
            });

        }

        
        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(-6000)]
        public void BookRoomShouldThrowWhenChildrenNegative(int children)
        {
            hotel1.AddRoom(room1);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel1.BookRoom(1, children, 1, 200);
            });

        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(-6000)]
        public void BookRoomShouldThrowWhenDurationNegativeOrZero(int duration)
        {
            hotel1.AddRoom(room1);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel1.BookRoom(1, 1, duration, 200);
            });

        }

    }
}