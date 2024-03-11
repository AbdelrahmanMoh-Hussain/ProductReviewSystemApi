using System.Linq.Expressions;

namespace ReviewSystem.Data.Repositroy.IRepository
{
	public interface IRepository<T> where T : class
	{
		ICollection<T> GetAll(string? includeProperties = null);
		T Get(Expression<Func<T,bool>> filter, string? includeProperties = null);
		void Add(T entity);
		void Remove(T entity);

		void RemoveRange(IEnumerable<T> entities);

		bool IsExist(int id);
	}
}
