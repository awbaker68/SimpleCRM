using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Core.Infrastructure
{
    /// <summary>
    /// Base Interface to be implemented by Repository classes
    /// </summary>
    public interface IRepository<TEntity> where TEntity : class
    {
		#region Add
		void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
		#endregion

		#region Update
		void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
		#endregion

		#region Remove
		void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
		#endregion

		#region Count
		int Count();
		#endregion

		#region Get
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
		#endregion

		#region Async methods
		Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
		#endregion
	}
}
