using BankJoakim.Resources.Transactions;
using MediatR;

namespace BankJoakim.MediatR.Commands
{
    public class TransactionCreateCommand : IRequest<CommandResult<TransactionResource>>
    {
        public TransactionCreateResource TransactionCreateResource;
        public TransactionCreateCommand(TransactionCreateResource transactionCreateResource)
        {
            TransactionCreateResource = transactionCreateResource;
        }
    }
}
