using BankJoakim.Models.Customers;
using System;

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

    }
}
