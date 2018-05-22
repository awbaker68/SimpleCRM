using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleCRM.Core.Infrastructure;

namespace SimpleCRM.Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _entities;

        public Repository(DbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }


        public virtual void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }


        public virtual int Count()
        {
            return _entities.Count();
        }


        // E.g. Expression<Func<Customer, bool>> filter = a => a.Name == "John Smith";
        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }
        public virtual Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.Run(() =>
            {
                return Find(predicate);
            });
        }

        public virtual TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }
        public virtual Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.Run(() =>
            {
                return GetSingleOrDefault(predicate);
            });
        }

        public virtual TEntity Get(int id)
        {
            return _entities.Find(id);
        }
        public virtual Task<TEntity> GetAsync(int id)
        {
            return Task.Run(() =>
            {
                return Get(id);
            });
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }
        public virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Task.Run(() =>
            {
                return GetAll();
            });
        }
    }
}
