using System;
using System.ComponentModel.DataAnnotations;

namespace BankJoakim.Resources.Deposits
{
    public class DepositCreateResource
    {
        [Required]
        public Guid? AccountId { get; set; }
        
        [Required]
        public double Ammount { get; set; }
    }
}
