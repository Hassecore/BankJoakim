using BankJoakim.Resources.Accounts;
using System;
using System.Collections.Generic;

namespace BankJoakim.Resources.Customers
{
    public class CustomerResource
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }
        public IEnumerable<AccountResource> Accounts { get; set; }
    }
}
