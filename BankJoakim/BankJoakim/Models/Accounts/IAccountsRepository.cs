using System;

namespace BankJoakim.Models.Accounts
{
    public interface IAccountsRepository : IRepositoryBase<Account>
    {
        Account GetIncludingTransactions(Guid accountId);
    }
}
