using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewSystem.Models
{
	public class Seller
	{
		public int Id { get; set; }
		[Required, MaxLength(100)]
		public string FirstName { get; set; }
		[Required, MaxLength(100)]
		public string LastName { get; set; }
		public ICollection<Product> Products { get; set; }

	}
}
