using ReviewSystem.Models;

namespace ReviewSystem.Data.Repositroy.IRepository
{
	public interface IReviewRepository : IRepository<Review>
	{
		ICollection<Review> GetProductReviews(int pokemonId);
	}
}
