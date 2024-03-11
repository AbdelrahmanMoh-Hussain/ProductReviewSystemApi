using Microsoft.EntityFrameworkCore;
using ReviewSystem.Data.Repositroy.IRepository;
using ReviewSystem.Models;
using System.Linq.Expressions;

namespace ReviewSystem.Data.Repositroy
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

		public void Add(T entity)
		{
			_context.Set<T>().Add(entity);
		}

		public T Get(Expression<Func<T, bool>> filter, string includeProperties = null)
		{
			IQueryable<T> quary = _context.Set<T>();
			if (!string.IsNullOrEmpty(includeProperties))
			{
				var properties = includeProperties.Split(',');
				foreach (var property in properties)
				{
					quary = quary.Include(property);
				}
			}
			return quary.FirstOrDefault(filter);
		}

		public ICollection<T> GetAll(string includeProperties = null)
		{
			IQueryable<T> quary = _context.Set<T>();
			if(! string.IsNullOrEmpty(includeProperties) )
			{
				var properties = includeProperties.Split(',');
				foreach( var property in properties)
				{
					quary = quary.Include(property);
				}
			}
			return quary.ToList();
		}

		public bool IsExist(int id)
		{
			var entity = _context.Set<T>().Find(id);
			return entity != null;
		}

		public void Remove(T entity)
		{
			_context.Set<T>().Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			_context.Set<T>().RemoveRange(entities);
		}
	}
}
