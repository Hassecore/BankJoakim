using BankJoakim.MediatR.Commands;
using BankJoakim.Resources.Accounts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BankJoakim.MediatR.CommandHandlers
{
    public class AccountCreateCommandHandler : IRequestHandler<AccountCreateCommand, CommandResult<AccountResource>>
    {
        public AccountCreateCommandHandler()
        {

        }

        public Task<CommandResult<AccountResource>> Handle(AccountCreateCommand request, CancellationToken cancellationToken)
        {



            throw new NotImplementedException();
        }
    }
}
