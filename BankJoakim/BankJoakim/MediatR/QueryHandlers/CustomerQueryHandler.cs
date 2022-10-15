using BankJoakim.MediatR.Queries;
using BankJoakim.Models.Customers;
using BankJoakim.Resources.Accounts;
using BankJoakim.Resources.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BankJoakim.MediatR.QueryHandlers
{
    public class CustomerQueryHandler : IRequestHandler<CustomerQuery, CustomerResource>
    {
        readonly ICustomersRepository _customersRepository;

        public CustomerQueryHandler(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }
        public Task<CustomerResource> Handle(CustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = GetCustomer(request);

            if (customer == null)
            {
                return Task.FromResult(new CustomerResource());
            }

            var customerResource = new CustomerResource
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                CreatedOn = customer.CreatedOn,
                Accounts = customer.Accounts?
                                   .OrderBy(a => a.CreatedOn)
                                   .Select(a => new AccountResource
                                                {
                                                Id = a.Id,
                                                AccountName = a.AccountName,
                                                Iban = a.Iban,
                                                Balance = a.Balance,
                                                CreatedOn = a.CreatedOn
                                                }) ?? new List<AccountResource>()
            };

            return Task.FromResult(customerResource);
        }

        private Customer GetCustomer(CustomerQuery request)
        {
            if (request.IncludeAccounts)
            {
                return _customersRepository.GetIncludingAccounts(request.Id);
            }
            else
            {
                return _customersRepository.GetById(request.Id);
            }
        }
    }
}
