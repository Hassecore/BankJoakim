using BankJoakim.Models.Customers;
using BankJoakim.Models.Deposits;
using BankJoakim.Models.Transactions;
using System;
using System.Collections.Generic;

namespace BankJoakim.Models.Accounts
{
    public class Account : IEntityBase
    {
        public Guid Id { get; set; }
        public string AccountName { get; set; }
        public string Iban { get; set; }
        public double Balance { get; set; }
        public DateTime CreatedOn { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<Deposit> Deposits { get; set; }
        public List<Transaction> Transactions { get; set; }

    }
}
