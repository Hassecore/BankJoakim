namespace BankJoakim.Models.Deposits
{
    public class DepositsRepository : RepositoryBase<Deposit>, IDepositsRepository
    {
        public DepositsRepository(BankContext context) : base(context)
        {

        }
    }
}
