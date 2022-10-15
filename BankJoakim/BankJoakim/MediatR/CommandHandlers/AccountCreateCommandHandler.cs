using BankJoakim.MediatR.Commands;
using BankJoakim.Models.Accounts;
using BankJoakim.Models.Customers;
using BankJoakim.Resources.Accounts;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BankJoakim.MediatR.CommandHandlers
{
    public class AccountCreateCommandHandler : IRequestHandler<AccountCreateCommand, CommandResult<AccountResource>>
    {
        readonly IAccountsRepository _accountsRepository;
        readonly ICustomersRepository _customersRepository;
        
        public AccountCreateCommandHandler(IAccountsRepository accountsRepository,
                                           ICustomersRepository customersRepository)
        {
            _accountsRepository = accountsRepository;
            _customersRepository = customersRepository;
        }

        public Task<CommandResult<AccountResource>> Handle(AccountCreateCommand request, CancellationToken cancellationToken)
        {
            var resource = request.AccountCreateResource;

            var customer = _customersRepository.GetCustomerIncludingAccounts(resource.CustomerId.Value);
            if (customer == null)
            {
                return Task.FromResult(new CommandResult<AccountResource>
                {
                    HasSucceeded = false,
                    ErrorMessage = "Customer not found."
                });
            }
            else if (customer.Accounts.Any(a => a.AccountName == resource.AccountName))
            {
                return Task.FromResult(new CommandResult<AccountResource>
                {
                    HasSucceeded = false,
                    ErrorMessage = "Account name already exists."
                });
            }

            var iban = RetrieveRandomIban();
            var account = new Account
            {
                Id = Guid.NewGuid(),
                AccountName = resource.AccountName,
                CustomerId = resource.CustomerId.Value,
                Iban = iban,
                Balance = 0,
                CreatedOn = DateTime.UtcNow
            };

            _accountsRepository.Add(account);
            _accountsRepository.Commit();

            return Task.FromResult(new CommandResult<AccountResource>
            {
                HasSucceeded = true,
                Resource = new AccountResource
                {
                    Id = account.Id,
                    AccountName = account.AccountName,
                    Iban = account.Iban,
                    Balance = account.Balance,
                    CreatedOn = account.CreatedOn,
                }
            });
        }

        private string RetrieveRandomIban()
        {
            // to be implemented properly, with http://randomiban.com/?country=Netherlands
            // for now just some unique string.
            return $"Iban-{Guid.NewGuid()}"; 
        }
    }
}
