using System;

namespace BankJoakim.MediatR.Commands
{
    public class CommandResult<T>
    {
        public T Result { get; set; }
        public bool HasSucceeded { get; set; }
        public bool HasConflicts { get; set; }
        public Guid? Id { get; set; }

    }
}
