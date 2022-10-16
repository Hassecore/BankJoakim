using BankJoakim.MediatR.Commands;
using BankJoakim.Models.Accounts;
using BankJoakim.Models.Transactions;
using BankJoakim.Resources.Transactions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BankJoakim.MediatR.CommandHandlers
{
    public class TransactionCreateCommandHandler : IRequestHandler<TransactionCreateCommand, CommandResult<TransactionResource>>
    {
        readonly IAccountsRepository _accountsRepository;
        readonly ITransactionsRepository _transactionsRepository;

        public TransactionCreateCommandHandler(IAccountsRepository accountsRepository,
                                               ITransactionsRepository transactionsRepository)
        {
            _accountsRepository = accountsRepository;
            _transactionsRepository = transactionsRepository;
        }

        public Task<CommandResult<TransactionResource>> Handle(TransactionCreateCommand request, CancellationToken cancellationToken)
        {
            var resource = request.TransactionCreateResource;

            var accounts = _accountsRepository.Get(a => a.Id == resource.SendingAccountId || a.Id == resource.ReceivingAccountId);

            var sendingAccount = accounts.FirstOrDefault(a => a.Id == resource.SendingAccountId);
            var receivingAccount = accounts.FirstOrDefault(a => a.Id == resource.ReceivingAccountId);

            if (sendingAccount == null)
            {

            }

            if (receivingAccount == null)
            {

            }


            throw new NotImplementedException();
        }
    }
}
