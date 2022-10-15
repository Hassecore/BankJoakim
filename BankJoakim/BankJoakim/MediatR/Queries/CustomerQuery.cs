using BankJoakim.Resources.Customers;
using MediatR;
using System;

namespace BankJoakim.MediatR.Queries
{
    public class CustomerQuery : IRequest<CustomerResource>
    {
        public Guid Id { get; set; }
        public bool IncludeAccounts { get; set; }
        public CustomerQuery(Guid id, bool includeAccounts)
        {
            Id = id;
            IncludeAccounts = includeAccounts;
        }
    }
}
