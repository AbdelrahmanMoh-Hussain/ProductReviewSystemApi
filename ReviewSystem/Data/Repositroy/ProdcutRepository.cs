using Microsoft.EntityFrameworkCore;
using ReviewSystem.Data.Repositroy.IRepository;
using ReviewSystem.Models;

namespace ReviewSystem.Data.Repositroy
{
	public class ProdcutRepository : Repository<Product>, IProductRepository
	{
		private readonly AppDbContext _context;
		public ProdcutRepository(AppDbContext context)
			: base(context)
		{
			_context = context;
		}

		public Product GetProduct(string name)
		{
			return _context.Products.FirstOrDefault(x => x.Title == name);
		}

		public decimal GetProductRating(int productId)
		{
			var reviews = _context.Reviews.Where(x => x.ProdcutId == productId);

			if (reviews.Count() <= 0)
				return 0;

			return ((decimal)reviews.Sum(x => x.Rating) / reviews.Count());
		}

		
	}
}
