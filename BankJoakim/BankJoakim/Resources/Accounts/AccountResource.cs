using System;

namespace BankJoakim.Resources.Accounts
{
    public class AccountResource
    {
        public Guid Id { get; set; }
        public string AccountName { get; set; }
        public string Iban { get; set; }
        public double Balance { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
