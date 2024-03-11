using ReviewSystem.Models;

namespace ReviewSystem.Data.Repositroy.IRepository
{
	public interface ISellerRepository : IRepository<Seller>
	{
		ICollection<Seller> GetProductSeller(int productId);
		ICollection<Product> GetProductBySeller(int sellerId);
	}
}
