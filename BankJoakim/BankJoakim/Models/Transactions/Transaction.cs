using BankJoakim.Models.Accounts;
using System;

namespace BankJoakim.Models.Transactions
{
    public class Transaction : IEntityBase
    {
        public Guid Id { get; set; }
        public double Ammount { get; set; }
        public DateTime CreatedOn { get; set; }

        public Guid SendingAccountId { get; set; }
        public Account SendingAccount { get; set; }

        public Guid ReceivingAccountId { get; set; }
        public Account ReceivingAccount { get; set; }

    }
}
