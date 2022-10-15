using System.Collections.Generic;

namespace BankJoakim.Resources.Customers
{
    public class CustomersResource
    {
        public int TotalCount { get; set; }
        public IEnumerable<CustomerResource> Customers { get; set; }
    }
}
