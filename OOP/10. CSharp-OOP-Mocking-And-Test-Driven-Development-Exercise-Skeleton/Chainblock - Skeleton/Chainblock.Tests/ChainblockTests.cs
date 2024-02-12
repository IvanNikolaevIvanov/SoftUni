namespace Chainblock.Tests
{
    using Models;
    using Contracts;
    using NUnit.Framework;
    using System;
    using System.Reflection;
    using System.Linq;

    [TestFixture]

    public class ChainblockTests
    {
        private IChainblock chainblock;
        private ITransaction testTransaction;

        [SetUp]
        public void SetUp()
        {
            this.chainblock = new Chainblock();
            this.testTransaction = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gosho", 1000);
        }

        [Test]
        public void ConstructorShouldInitializeTransactionCollection()
        {
            Type chainblockType = this.chainblock.GetType();

            FieldInfo transactionsField = chainblockType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.Name == "transactions");

            object value = transactionsField.GetValue(this.chainblock);

            Assert.IsNotNull(value);

        }

        [Test]
        public void AddShouldAppendTransactionToDataCollection()
        {
            this.chainblock.Add(this.testTransaction);

            bool transactionAdded = this.chainblock.Contains(this.testTransaction);

            Assert.IsTrue(transactionAdded);
        }

        [Test]
        public void AddShouldIncreaseCount() 
        {
            this.chainblock.Add(this.testTransaction);

            int expectedCount = 1;
            int actualCount = this.chainblock.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void AddShouldTrhowExceptionWhenAddingSameTransaction()
        {
            this.chainblock.Add(testTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.Add(testTransaction);
            }, "You cannot add already existing transaction!");
        }

        [Test]
        public void AddShouldThrowExceptionWhenAddingTransactionWithExistingId()
        {
            this.chainblock.Add(testTransaction);

            ITransaction newTransaction = new Transaction(1, TransactionStatus.Failed, "Gosho", "Pesho", 100);

            Assert.Throws<InvalidOperationException>(() =>
            {

                this.chainblock.Add(newTransaction);
            }, "You cannot add already existing transaction!");

        }

        [Test]
        public void ContainsByTransactionShouldReturnTrueWhenExists()
        {
            this.chainblock.Add(this.testTransaction);

            bool transactionExists = this.chainblock.Contains(this.testTransaction);

            Assert.IsTrue(transactionExists);

        }

        [Test]
        public void ContainsByTransactionShouldReturnFlaseWhenNotExists()
        {
            bool transactionExists = this.chainblock.Contains(this.testTransaction);

            Assert.IsFalse(transactionExists);
        }

        [Test]
        public void ContainsByIdShouldReturnTrueWhenExists()
        {
            this.chainblock.Add(testTransaction);

            bool transactionExist = this.chainblock.Contains(this.testTransaction.Id);

            Assert.IsTrue(transactionExist);
        }

        [Test]
        public void ContainsByIdShouldREturnFalseWhenNotExist()
        {

            bool transactionExist = this.chainblock.Contains(this.testTransaction.Id);

            Assert.IsFalse(transactionExist);
        }

        [Test]
        public void CountShuldReturnZeroWhenNoTransactionsAreAdded ()
        {
            int expectedCount = 0;
            int actualCount = this.chainblock.Count;

            Assert.AreEqual(expectedCount, actualCount);    

        }

        [Test]
        public void ChangeTransactionStatusShouldThrowExceptionWithNonExistingId()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.chainblock.ChangeTransactionStatus(1, TransactionStatus.Failed);

            }, "You cannot change the status of non-existing transaction!");
        }

        [Test]
        public void ChangeTransactionStatusShouldCHangeStatusIfItISDifferent()
        {
            this.chainblock.Add(this.testTransaction);

            TransactionStatus expStatus = TransactionStatus.Unauthorized;

            this.chainblock.ChangeTransactionStatus(this.testTransaction.Id, expStatus);

            ITransaction changedTransaction = this.chainblock.GetById(this.testTransaction.Id);

            TransactionStatus actualStatus = changedTransaction.Status;

            Assert.AreEqual(expStatus, actualStatus);

        }
    }
}
