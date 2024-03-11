using ReviewSystem.Models;

namespace ReviewSystem.Data.Repositroy.IRepository
{
	public interface ICategoryRepository: IRepository<Category>
	{
		ICollection<Product> GetPokemonByCategory(int categoryId);
	}
}
