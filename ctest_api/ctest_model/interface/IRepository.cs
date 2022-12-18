using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ctest_model.Interface
{
	public interface IRepository<T> : IDisposable where T : class
	{
		T Create_ReturnId(T instance);

		void Create(T instance);

		void Update(T instance);

		void RemoveRange(IEnumerable<T> instance);

		void AddRange(IEnumerable<T> instance);
		void Delete(T instance);

		T Get(Expression<Func<T, bool>> predicate);

		IQueryable<T> GetAll();

		void SaveChanges();
    }
}
