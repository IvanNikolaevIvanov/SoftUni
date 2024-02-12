using Chainblock.Contracts;
using Chainblock.Models;
using Moq;
using NUnit.Framework;
using System;

namespace Chainblock.Tests
{
    [TestFixture]

    public class TransactionTests
    {
        [Test]
        public void ConstructorShouldInitializeIdProperly()
        {
            int expectedId = 1;

            ITransaction transaction = new Transaction(expectedId, TransactionStatus.Successfull, "from", "to", 1000);

            int actualId = transaction.Id;

            Assert.AreEqual(expectedId, actualId);
        }

        [Test]
        public void ConstructorShouldInitializeStatusProperly()
        {
            TransactionStatus expectedStatus = TransactionStatus.Unauthorized;

            ITransaction transaction = new Transaction(1, expectedStatus, "from", "to", 1000);

            TransactionStatus actualStatus = transaction.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Test]
        public void ConstructorShouldInitializeSenderProperly()
        {
            string expectedSender = "Gosho";

            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, expectedSender, "Pesho", 1000);

            string actualSender = transaction.From;

            Assert.IsTrue(expectedSender.Equals(actualSender));
        }

        [Test]
        public void ConstructorShouldInitializeReceiverProperly()
        {
            string expectedReceiver = "Pesho";

            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Gosho", expectedReceiver, 1000);

            string actualReceiver = transaction.To;

            Assert.AreEqual(expectedReceiver, actualReceiver);
        }

        [Test]
        public void ConstructorShouldInitializeAmmountProperly()
        {
            decimal expectedAmmount = 1000;

            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Gosho", "Pesho", expectedAmmount);

            decimal actualAmmount = transaction.Amount;

            Assert.AreEqual(expectedAmmount, actualAmmount);
        }

        [TestCase(- 100)]
        [TestCase(- 1)]
        [TestCase(0)]
        public void IdSetterShouldThrowExceptionWithZeroOrNegative(int id)
        {

            Assert.Throws<ArgumentException>(() =>
            {
                ITransaction transaction = new Transaction(id, TransactionStatus.Successfull, "Gosho", "Pesho", 1000);
            }, "Sender name cannot be null or whitespace string!");
            
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("   ")]
        public void SenderShouldThrowExceptionWhenNullOrWhiteSpace(string from)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, from, "Pesho", 1000);
            }, "Sender name cannot be null or whitespace string!");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("   ")]
        public void ReceiverShouldThrowExceptionWhenNullOrWhiteSpace(string to)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Gosho", to, 1000);
            }, "Receiver name cannot be null or whitespace string!");
        }

        [TestCase(- 0.000001)]
        [TestCase(- 50)]
        [TestCase(- 500)]
        [TestCase(- 3000)]
        [TestCase(0)]
        public void AmmountSetterShouldThrowExceptionWithZeroOrNegativeAmmount(decimal ammount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Gosho", "Pesho", ammount);

            }, "Amount must be a positive number!");

        }

    }
}
