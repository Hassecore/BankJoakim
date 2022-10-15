using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BankJoakim.Models
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntityBase
    {
        protected BankContext _context;
        public RepositoryBase(BankContext context)
        {
            _context = context;
        }

        public virtual int Count() => _context.Set<T>().Count();

        public virtual T GetById(Guid id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            var entities = _context.Set<T>().Where(predicate);
            return entities;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public virtual void Commit()
        {
            _context.SaveChanges();
        }
    }
}
