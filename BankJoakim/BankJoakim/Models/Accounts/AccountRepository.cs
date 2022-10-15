namespace BankJoakim.Models.Accounts
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(BankContext context) : base(context)
        {

        }
    }
}
