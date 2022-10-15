using System;
using System.ComponentModel.DataAnnotations;

namespace BankJoakim.Resources.Accounts
{
    public class AccountCreateResource
    {
        [Required]
        public string AccountName { get; set; }

        [Required]
        public Guid? CustomerId { get; set; }
    }
}
