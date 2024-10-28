using Microsoft.EntityFrameworkCore;
using ReviewSystem.Data.Repositroy.IRepository;
using ReviewSystem.Models;

namespace ReviewSystem.Data.Repositroy
{
	public class ReviewRepositroy : Repository<Review>, IReviewRepository
	{
		private readonly AppDbContext _context;

		public ReviewRepositroy(AppDbContext context) : base(context)
		{
			_context = context;
		}

		public ICollection<Review> GetProductReviews(int productId)
		{
			return _context.Reviews
				.Where(x => x.ProdcutId ==  productId)
				.Include(x => x.Product)
				.ToList();
		}
	}
}
