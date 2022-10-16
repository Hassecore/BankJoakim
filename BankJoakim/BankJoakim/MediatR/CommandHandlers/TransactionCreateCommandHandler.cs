using BankJoakim.MediatR.Commands;
using BankJoakim.Models.Accounts;
using BankJoakim.Models.Transactions;
using BankJoakim.Resources.Transactions;
using MediatR;
using System;
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
                return Task.FromResult(new CommandResult<TransactionResource> { HasSucceeded = false, ErrorMessage = "Sending account not found." });
            }

            if (receivingAccount == null)
            {
                return Task.FromResult(new CommandResult<TransactionResource> { HasSucceeded = false, ErrorMessage = "Receiving account not found." });
            }

            if (sendingAccount.Balance < resource.Ammount)
            {
                return Task.FromResult(new CommandResult<TransactionResource> { HasSucceeded = false, ErrorMessage = "Insufficient balance." });
            }

            sendingAccount.Balance -= resource.Ammount;
            receivingAccount.Balance += resource.Ammount;

            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                Ammount = resource.Ammount,
                SendingAccountId = resource.SendingAccountId,
                SendingAccount = sendingAccount,
                ReceivingAccountId = resource.ReceivingAccountId,
                ReceivingAccount = receivingAccount
            };

            _transactionsRepository.Add(transaction);
            _transactionsRepository.Commit();

            return Task.FromResult(new CommandResult<TransactionResource>
            {
                HasSucceeded = true,
                Resource = new TransactionResource
                {
                    Id = transaction.Id,
                    Ammount = transaction.Ammount,
                    CreatedOn = transaction.CreatedOn,
                    SendingAccountId = transaction.SendingAccountId,
                    ReceivingAccountId = transaction.ReceivingAccountId
                }
            });
        }
    }
}
