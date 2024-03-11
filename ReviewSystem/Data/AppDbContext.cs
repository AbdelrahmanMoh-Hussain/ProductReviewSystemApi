using Microsoft.EntityFrameworkCore;
using ReviewSystem.Models;

namespace ReviewSystem.Data
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options) 
        {
            
        }

		public DbSet<Product> Products { get; set; }
		public DbSet<Seller> Sellers { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<Reviewer> Reviewers { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<ProductSeller> ProductSellers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ProductCategory>()
				.HasKey(x => new { x.ProductId, x.CategoryId });

			modelBuilder.Entity<ProductSeller>()
				.HasKey(x => new { x.ProductId, x.SellerId });

			//Realations
			modelBuilder.Entity<Product>().HasMany(x => x.Sellers)
				.WithMany(x => x.Products)
				.UsingEntity<ProductSeller>();

			modelBuilder.Entity<Product>().HasMany(x => x.Categories)
				.WithMany(x => x.Products)
				.UsingEntity<ProductCategory>();

			modelBuilder.Entity<Product>().HasMany(x => x.Reviews)
				.WithOne(x => x.Product)
				.HasForeignKey(x => x.ProdcutId);

			modelBuilder.Entity<Reviewer>().HasMany(x => x.Reviews)
				.WithOne(x => x.Reviewer)
				.HasForeignKey(x => x.ReviewerId);

		}
	}
}
