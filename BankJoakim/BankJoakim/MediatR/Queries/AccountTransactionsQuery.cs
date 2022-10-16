using BankJoakim.Resources.Accounts;
using MediatR;
using System;

namespace BankJoakim.MediatR.Queries
{
    public class AccountTransactionsQuery : IRequest<AccountTransactionsResource>
    {
        public Guid AccountId { get; }
        public AccountTransactionsQuery(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}
