using System;
using System.ComponentModel.DataAnnotations;

namespace BankJoakim.Resources.Transactions
{
    public class TransactionCreateResource
    {
        [Required]
        public Guid? SendingAccountId { get; set; }

        [Required]
        public Guid? ReceivingAccountId { get; set; }

        [Required]
        public double Ammount { get; set; }
    }
}
