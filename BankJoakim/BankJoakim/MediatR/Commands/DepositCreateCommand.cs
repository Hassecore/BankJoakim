using BankJoakim.Resources.Deposits;
using MediatR;

namespace BankJoakim.MediatR.Commands
{
    public class DepositCreateCommand : IRequest<CommandResult<DepositResource>>
    {
        public DepositCreateResource DepositCreateResource;
        public DepositCreateCommand(DepositCreateResource depositCreateResource)
        {
            DepositCreateResource = depositCreateResource;
        }
    }
}
