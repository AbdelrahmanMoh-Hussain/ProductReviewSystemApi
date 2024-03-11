using ReviewSystem.Data.Repositroy.IRepository;
using ReviewSystem.Models;

namespace ReviewSystem.Data.Repositroy
{
    public class SellerRepository : Repository<Seller>, ISellerRepository
	{
		private readonly AppDbContext _context;

		public SellerRepository(AppDbContext context) 
			: base(context)
		{
			_context = context;
		}

		public ICollection<Product> GetProductBySeller(int sellerId)
		{
			return _context.ProductSellers
				.Where(x => x.SellerId == sellerId)
				.Select(x => x.Product)
				.ToList();
		}

		public ICollection<Seller> GetProductSeller(int productId)
		{
			return _context.ProductSellers
				.Where(x => x.ProductId == productId)
				.Select (x => x.Seller)
				.ToList();
		}
	}
}
