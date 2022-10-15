using BankJoakim.MediatR.Commands;
using BankJoakim.Models.Accounts;
using BankJoakim.Models.Deposits;
using BankJoakim.Resources.Deposits;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BankJoakim.MediatR.CommandHandlers
{
    public class DepositCreateCommandHandler : IRequestHandler<DepositCreateCommand, CommandResult<DepositResource>>
    {
        readonly IDepositsRepository _depositsRepository;
        readonly IAccountsRepository _accountsRepository;

        public DepositCreateCommandHandler(IDepositsRepository depositsRepository, IAccountsRepository accountsRepository)
        {
            _depositsRepository = depositsRepository;
            _accountsRepository = accountsRepository;
        }

        public Task<CommandResult<DepositResource>> Handle(DepositCreateCommand request, CancellationToken cancellationToken)
        {
            var resource = request.DepositCreateResource;

            var account = _accountsRepository.GetById(resource.AccountId.Value);
            if (account == null)
            {
                return Task.FromResult(new CommandResult<DepositResource>
                {
                    HasSucceeded = false,
                    ErrorMessage = "Account not found."
                });
            }

            var deposit = new Deposit
            {
                Id = Guid.NewGuid(),
                Ammount = resource.Ammount,
                AccountId = resource.AccountId.Value,
                CreatedOn = DateTime.UtcNow
            };

            _depositsRepository.Add(deposit);
            _depositsRepository.Commit();

            return Task.FromResult(new CommandResult<DepositResource>
            {
                HasSucceeded = true,
                Resource = new DepositResource
                {
                    Id = deposit.Id,
                    AccountId = deposit.AccountId,
                    Ammount = deposit.Ammount,
                    CreatedOn = deposit.CreatedOn
                }
            });
        }
    }
}
