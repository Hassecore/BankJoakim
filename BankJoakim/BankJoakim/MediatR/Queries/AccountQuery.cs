using BankJoakim.Resources.Accounts;
using MediatR;
using System;

namespace BankJoakim.MediatR.Queries
{
    public class AccountQuery : IRequest<AccountResource>
    {
        public Guid Id { get; }
        public AccountQuery(Guid id)
        {
            Id = id;
        }
    }
}
