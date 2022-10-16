using BankJoakim.Resources.Transactions;
using System;
using System.Collections.Generic;

namespace BankJoakim.Resources.Accounts
{
    public class AccountTransactionsResource
    {
        public Guid AccountId { get; set; }
        public List<TransactionResource> Transactions { get; set; }
    }
}
