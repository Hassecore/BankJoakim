using BankJoakim.MediatR.Queries;
using BankJoakim.Models.Customers;
using BankJoakim.Resources.Customers;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BankJoakim.MediatR.QueryHandlers
{
    public class CustomersQueryHandler : IRequestHandler<CustomersQuery, CustomersResource>
    {
        readonly ICustomersRepository _customersRepository;

        public CustomersQueryHandler(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public Task<CustomersResource> Handle(CustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = _customersRepository.Get(c => true)
                                                .OrderBy(c => c.CreatedOn)
                                                .Skip(request.Skip)
                                                .Take(request.Take)
                                                .ToList()
                                                .Select(c => new CustomerResource 
                                                {
                                                    Id = c.Id,
                                                    FirstName = c.FirstName,
                                                    LastName = c.LastName,
                                                    CreatedOn = c.CreatedOn
                                                });

            var totalCount = _customersRepository.Count();

            return Task.FromResult(new CustomersResource
            {
                TotalCount = totalCount,
                Customers = customers
            }); ;
        }
    }
}
