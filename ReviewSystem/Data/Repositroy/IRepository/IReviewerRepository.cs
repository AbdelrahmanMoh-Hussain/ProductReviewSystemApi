using ReviewSystem.Models;

namespace ReviewSystem.Data.Repositroy.IRepository
{
	public interface IReviewerRepository : IRepository<Reviewer>
	{
		ICollection<Review> GetReviewerReviews(int reviewerId);
	}
}
