using ReviewSystem.Models;

namespace ReviewSystem.Data.Repositroy.IRepository
{
	public interface IProductRepository: IRepository<Product>
	{
		Product GetProduct(string name);
		decimal GetProductRating(int productId);
	}
}
