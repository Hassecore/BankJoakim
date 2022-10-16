using System;

namespace BankJoakim.Resources.Transactions
{
    public class TransactionCreateResource
    {
        public Guid SendingAccountId { get; set; }
        public Guid ReceivingAccountId { get; set; }
        public double Ammount { get; set; }
    }
}
