namespace BankJoakim.Models.Accounts
{
    public class AccountsRepository : RepositoryBase<Account>, IAccountsRepository
    {
        public AccountsRepository(BankContext context) : base(context)
        {

        }
    }
}
