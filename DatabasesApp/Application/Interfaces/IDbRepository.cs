using System.Collections.Generic;

namespace DatabasesApp.Application.Interfaces
{
	public interface IDbRepository<T>
	{
		public IEnumerable<T> GetAll();
		public T GetById(int id);
		public void Add(T entity);
		public void Update(T entity);
		public void Delete(T entity);
	}
}
