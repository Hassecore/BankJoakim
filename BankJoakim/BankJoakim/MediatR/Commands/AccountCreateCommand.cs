using BankJoakim.Resources.Accounts;
using MediatR;

namespace BankJoakim.MediatR.Commands
{
    public class AccountCreateCommand : IRequest<CommandResult<AccountResource>>
    {
        public AccountCreateResource AccountCreateResource;
        public AccountCreateCommand(AccountCreateResource accountCreateResource)
        {
            AccountCreateResource = accountCreateResource;
        }
    }
}
