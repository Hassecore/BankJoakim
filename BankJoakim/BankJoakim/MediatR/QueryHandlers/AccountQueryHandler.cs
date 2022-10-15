using BankJoakim.MediatR.Queries;
using BankJoakim.Models.Accounts;
using BankJoakim.Resources.Accounts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BankJoakim.MediatR.QueryHandlers
{
    public class AccountQueryHandler : IRequestHandler<AccountQuery, AccountResource>
    {
        readonly IAccountsRepository _accountsRepository;

        public AccountQueryHandler(IAccountsRepository accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }

        public Task<AccountResource> Handle(AccountQuery request, CancellationToken cancellationToken)
        {
            var account = _accountsRepository.GetById(request.Id);

            if (account == null)
            {
                return Task.FromResult(new AccountResource());
            }

            return Task.FromResult(new AccountResource
            {
                Id = account.Id,
                AccountName = account.AccountName,
                Balance = account.Balance,
                Iban = account.Iban,
                CreatedOn = account.CreatedOn
            });
        }
    }
}
