using ReviewSystem.Data.Repositroy.IRepository;
using ReviewSystem.Models;

namespace ReviewSystem.Data.Repositroy
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private readonly AppDbContext _context;
		public CategoryRepository(AppDbContext context) 
			: base(context)
		{
			_context = context;
		}

		
		public ICollection<Product> GetPokemonByCategory(int categoryId)
		{
			return _context.ProductCategories
				.Where(x => x.CategoryId == categoryId)
				.Select(x => x.Product)
				.ToList();
		}
	}
}
