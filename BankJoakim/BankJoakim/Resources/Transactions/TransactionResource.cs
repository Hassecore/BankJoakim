using System;

namespace BankJoakim.Resources.Transactions
{
    public class TransactionResource
    {
        public Guid Id { get; set; }
        public Guid SendingAccountId { get; set; }
        public Guid ReceivingAccountId { get; set; }
        public double Ammount { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
