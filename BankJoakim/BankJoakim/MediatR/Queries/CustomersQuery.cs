using BankJoakim.Resources.Customers;
using MediatR;

namespace BankJoakim.MediatR.Queries
{
    public class CustomersQuery : IRequest<CustomersResource>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public CustomersQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }
    }
}
