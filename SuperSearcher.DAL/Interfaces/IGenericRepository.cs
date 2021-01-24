using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SuperSearcher.DAL.Interfaces
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{

		TEntity Create(TEntity item);
		void CreateRange(IEnumerable<TEntity> items);
		TEntity FindById(int id);
		TEntity FindById(long id);
		IEnumerable<TEntity> Get();
		IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
		void Remove(TEntity item);
		void Remove(int id);
		void Remove(long id);
		void RemoveRange(IEnumerable<TEntity> items);
		void Update(TEntity item);
		IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);
		IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
			params Expression<Func<TEntity, object>>[] includeProperties);
	}
}
