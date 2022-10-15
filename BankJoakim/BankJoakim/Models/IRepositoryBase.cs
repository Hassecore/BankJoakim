using System;
using System.Linq;
using System.Linq.Expressions;

namespace BankJoakim.Models
{
    public interface IRepositoryBase<T> where T: class, IEntityBase
    {
        int Count();
        T GetById(Guid id);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Commit();
    }
}
