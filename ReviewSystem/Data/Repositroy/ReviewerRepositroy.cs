using Microsoft.EntityFrameworkCore;
using ReviewSystem.Data.Repositroy.IRepository;
using ReviewSystem.Models;

namespace ReviewSystem.Data.Repositroy
{
	public class ReviewerRepositroy : Repository<Reviewer>, IReviewerRepository
	{
		private readonly AppDbContext _context;

		public ReviewerRepositroy(AppDbContext context) : base(context)
		{
			_context = context;
		}

		public ICollection<Review> GetReviewerReviews(int reviewerId)
		{
			return _context.Reviews
				.Where(x => x.ReviewerId == reviewerId)
				.Include(x => x.Product)
				.ToList();
		}
	}
}
