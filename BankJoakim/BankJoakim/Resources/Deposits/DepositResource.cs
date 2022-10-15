using System;

namespace BankJoakim.Resources.Deposits
{
    public class DepositResource
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public double Ammount { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
