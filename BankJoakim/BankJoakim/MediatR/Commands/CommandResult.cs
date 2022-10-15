using System;

namespace BankJoakim.MediatR.Commands
{
    public class CommandResult<T>
    {
        public T Resource { get; set; }
        public bool HasSucceeded { get; set; }
        public string ErrorMessage { get; set; }
    }
}
