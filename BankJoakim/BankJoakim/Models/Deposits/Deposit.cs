using BankJoakim.Models.Accounts;
using System;

namespace BankJoakim.Models.Deposits
{
    public class Deposit : IEntityBase
    {
        // Perhaps a deposit should just be a type of Transaction? Oh well...
        public Guid Id { get; set; }
        public double Ammount { get; set; }
        public DateTime CreatedOn { get; set; }

        public Guid AccountId { get; set; }
        public Account Account { get; set; }
    }
}
