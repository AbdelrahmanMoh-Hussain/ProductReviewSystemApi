using ReviewSystem.Data.Repositroy.IRepository;

namespace ReviewSystem.Data.Repositroy
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _context;
		public UnitOfWork(AppDbContext context)
		{
			_context = context;
			Product = new ProdcutRepository(_context);
			Category = new CategoryRepository(_context);
			Seller = new SellerRepository(_context);
			Review = new ReviewRepositroy(_context);
			Reviewer = new ReviewerRepositroy(_context);
		}

		public IProductRepository Product { get; set; }
		public ICategoryRepository Category { get; set; }
		public ISellerRepository Seller { get; set; }
		public IReviewRepository Review {  get; set; }
		public IReviewerRepository Reviewer {  get; set; }

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
