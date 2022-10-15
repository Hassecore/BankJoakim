using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BankJoakim.Models.Customers
{
    public class CustomersRepository : RepositoryBase<Customer>, ICustomersRepository
    {
        public CustomersRepository(BankContext context) : base(context)
        {

        }

        public Customer GetCustomerIncludingAccounts(Guid customerId)
        {
            return _context.Customers.Where(c => c.Id == customerId)
                                     .Include(c => c.Accounts)
                                     .FirstOrDefault();
        }
    }
}
