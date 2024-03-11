using ReviewSystem.Models;

namespace ReviewSystem.Data
{
	public class Seed
	{
		private readonly AppDbContext _context;
		public Seed(AppDbContext context)
		{
			this._context = context;
		}
		public void SeedDataContext()
		{
			if (!_context.ProductSellers.Any())
			{
				var pokemonOwners = new List<ProductSeller>()
				{
					new ProductSeller()
					{
						Product = new Product()
						{
							Title = "Table",
							ProductionDate = new DateTime(1903,1,1),
							Categories = new List<Category>()
							{
								new Category { Name = "Home"}
							},
							Reviews = new List<Review>()
							{
								new Review { Title="Table",Text = "it is the best pokemon, because it is electric", Rating = 5,
								Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
								new Review { Title="Table", Text = "killing rocks", Rating = 5,
								Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
								new Review { Title="Table",Text = "Coooool", Rating = 1,
								Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
							},
							Price = 5m,
						},
						Seller = new Seller()
						{
							FirstName = "Jack",
							LastName = "London",
						}
					},
					new ProductSeller()
					{
						Product = new Product()
						{
							Title = "Shoes",
							ProductionDate = new DateTime(1903,1,1),
							Categories = new List<Category>()
							{
								new Category { Name = "Clothes"}
							},
							Reviews = new List<Review>()
							{
                                new Review { Title="Shoes",Text = "it is the best pokemon, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title="Shoes", Text = "killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title="Shoes",Text = "Coooool", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            },
							Price = 10m
							
						},
						Seller = new Seller()
						{
							FirstName = "Harry",
							LastName = "Potter",
						}
					},
									new ProductSeller()
					{
						Product = new Product()
						{
							Title = "Car",
							ProductionDate = new DateTime(1903,1,1),
							Categories = new List<Category>()
							{
								new Category { Name = "Machine"}
							},
							Reviews = new List<Review>()
							{
                                new Review { Title="Car",Text = "it is the best Car, because it is electric", Rating = 5,
									Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
								new Review { Title="Car", Text = "killing rocks", Rating = 5,
									Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
								new Review { Title="Car",Text = "Coooool", Rating = 1,
									Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
							 },
							Price = 55m
						},
						Seller = new Seller()
						{
							FirstName = "Ash",
							LastName = "Ketchum",
						}
					}
				};
				_context.ProductSellers.AddRange(pokemonOwners);
				_context.SaveChanges();
			}
		}
	}
}