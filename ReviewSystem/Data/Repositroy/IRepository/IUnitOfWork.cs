namespace ReviewSystem.Data.Repositroy.IRepository
{
	public interface IUnitOfWork
	{
		IProductRepository Product { get; set; }
		ICategoryRepository Category { get; set; }
		ISellerRepository Seller { get; set; }
		IReviewRepository Review { get; set; }
		IReviewerRepository Reviewer { get; set; }

		void Save();
	}
}
