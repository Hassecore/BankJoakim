using BankJoakim.Models.Accounts;
using System;
using System.Collections.Generic;

namespace BankJoakim.Models.Customers
{
    public class Customer : IEntityBase
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
