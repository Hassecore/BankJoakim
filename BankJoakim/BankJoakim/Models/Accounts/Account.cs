using BankJoakim.Models;
using BankJoakim.Models.Customers;
using System;

namespace BankJoakim
{
    public class Account : IEntityBase
    {
        public Guid Id { get; set; }
        public string AccountName { get; set; }
        public double Balance { get; set; }
        public DateTime CreatedOn { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
