using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone phone1;
        private Smartphone phone2;
        private Shop shop;
        [SetUp]
        public void SetUp()
        {
            shop = new Shop(2);
            phone1 = new Smartphone("1", 10);
            phone2= new Smartphone("2", 10);

        }

        [Test]
        public void ConstructorShouldInitCapacityProperly()
        {
            Shop shop1 = new Shop(1);

            Assert.AreEqual(1, shop1.Capacity);
        }

        [Test]
        public void ConstructorShouldInitListProperly()
        {
            Assert.AreEqual(0, shop.Count);
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(100)]
        [TestCase(1000)]
        public void CapacitySetterShouldSetValue(int capacity)
        {
            Shop shop1 = new Shop(capacity);

            Assert.AreEqual(capacity, shop1.Capacity);

        }

        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(-10)]
        [TestCase(-1100)]
        public void CapacitySetterShouldThrow(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop1 = new Shop(capacity);
            });

        }

        [Test]
        public void CountShouldWork()
        {
            shop.Add(phone1);
            shop.Add(phone2);

            Assert.IsTrue(shop.Count == 2);

        }

        [Test]
        public void AddPhoneShouldAddPhone()
        {

            shop.Add(phone1);

            Assert.IsTrue(shop.Count == 1);

        }
        [Test]
        public void AddPhoneShouldThrowWhenPhoneExists()
        {

            shop.Add(phone1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(phone1);
            });

        }
        [Test]
        public void AddPhoneShouldThrowWhenCapacityFull()
        {

            shop.Add(phone1);
            shop.Add(phone2);

            Smartphone phone3 = new Smartphone("3", 19);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(phone3);
            });

        }

        [Test]
        public void RemoveShouldRemove()
        {

            shop.Add(phone1);
            shop.Add(phone2);

            shop.Remove("2");

            Assert.IsTrue(shop.Count == 1);

        }

        [Test]
        public void RemoveShouldThrow()
        {

            shop.Add(phone1);
            shop.Add(phone2);

            Smartphone phone3 = new Smartphone("3", 19);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("3");
            });

        }

        [Test]
        public void TestPhoneShouldReduceCharge()
        {

            shop.Add(phone1);
            shop.Add(phone2);

            shop.TestPhone("2", 2);

            Assert.AreEqual(8, phone2.CurrentBateryCharge);
        }
        [Test]
        public void TestPhoneShouldThrowWhenPhoneNotExisting()
        {

            shop.Add(phone1);
            shop.Add(phone2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("3", 5);
            });

        }
        [Test]
        public void TestPhoneShouldThrowWhenBatteryLow()
        {

            shop.Add(phone1);
            shop.Add(phone2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("2", 15);
            });

        }

        [Test]
        public void ChargePhoneShouldCharge()
        {

            shop.Add(phone1);
            shop.Add(phone2);

            shop.TestPhone("2", 2);

            shop.ChargePhone("2");

            Assert.AreEqual(10, phone2.CurrentBateryCharge);
        }

        [Test]
        public void ChargePhoneShouldThrow()
        {

            shop.Add(phone1);
            shop.Add(phone2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("NaGosho");
            });

        }

    }
}