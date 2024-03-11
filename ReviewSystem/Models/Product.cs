using System.ComponentModel.DataAnnotations;

namespace ReviewSystem.Models
{
	public class Product
	{
        public int Id { get; set; }
		[Required, MaxLength(100)]
		public string Title { get; set; }
		[DataType(DataType.Date)]
		public DateTime ProductionDate { get; set; }
		public decimal Price { get; set; }

		public ICollection<Seller> Sellers { get; set; }	
		public ICollection<Category> Categories { get; set; }	
		public ICollection<Review> Reviews { get; set; }
    }
}
