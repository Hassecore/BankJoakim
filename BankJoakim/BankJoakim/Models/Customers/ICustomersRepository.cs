using System;

namespace BankJoakim.Models.Customers
{
    public interface ICustomersRepository : IRepositoryBase<Customer>
    {
        Customer GetIncludingAccounts(Guid customerId);
    }
}
