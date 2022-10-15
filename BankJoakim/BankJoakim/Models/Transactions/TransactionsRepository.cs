namespace BankJoakim.Models.Transactions
{
    public class TransactionsRepository : RepositoryBase<Transaction>, ITransactionsRepository
    {
        public TransactionsRepository(BankContext context) : base(context)
        {

        }
    }
}
