using BankJoakim.MediatR.Queries;
using BankJoakim.Models.Accounts;
using BankJoakim.Resources.Accounts;
using BankJoakim.Resources.Transactions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BankJoakim.MediatR.QueryHandlers
{
    public class AccountTransactionsQueryHandler : IRequestHandler<AccountTransactionsQuery, AccountTransactionsResource>
    {

        readonly IAccountsRepository _accountsRepository;

        public AccountTransactionsQueryHandler(IAccountsRepository accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }

        public Task<AccountTransactionsResource> Handle(AccountTransactionsQuery request, CancellationToken cancellationToken)
        {
            var account = _accountsRepository.GetIncludingTransactions(request.AccountId);

            if (account == null)
            {
                return Task.FromResult(new AccountTransactionsResource());
            }

            return Task.FromResult(new AccountTransactionsResource
            {
                AccountId = account.Id,
                Transactions = account.Transactions?.Select(t => new TransactionResource 
                               {
                                    Id = t.Id,
                                    Ammount = t.Ammount,
                                    CreatedOn = t.CreatedOn,
                                    ReceivingAccountId = t.ReceivingAccountId,
                                    SendingAccountId = t.SendingAccountId
                               }).ToList() ?? new List<TransactionResource>()
            }); ;


            throw new NotImplementedException();
        }
    }
}
