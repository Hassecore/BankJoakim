using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BankJoakim.Models.Accounts
{
    public class AccountsRepository : RepositoryBase<Account>, IAccountsRepository
    {
        public AccountsRepository(BankContext context) : base(context)
        {

        }

        public Account GetIncludingTransactions(Guid accountId)
        {
            return _context.Accounts.Where(a => a.Id == accountId)
                                    .Include(a => a.Transactions)
                                    .FirstOrDefault();
        }
    }
}
