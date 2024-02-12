
namespace Chainblock.Models
{
    using System;
    
    using Contracts;

    public class Transaction : ITransaction
    {
        private int id;
        private string from;
        private string to;
        private decimal amount;

        public Transaction(int id, TransactionStatus status, string from, string to, decimal amount)
        {
            this.Id = id;
            this.Status = status;
            this.From = from;
            this.To = to;
            this.Amount = amount;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                 this.id = value;
            }
        }


        public TransactionStatus Status { get; set; }

        public string From 
        { 
            get 
            {
                return this.from;
            }
            set 
            {
                this.from = value;
            }
        }

        public string To 
        {
            get 
            {
                return this.to;
            }
            set
            {
                this.to = value;
            }
        }

        public decimal Amount 
        {
            get 
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
            }
        }
    }
}
