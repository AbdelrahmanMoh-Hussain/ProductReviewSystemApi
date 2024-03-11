namespace ReviewSystem.Models
{
	public class ProductSeller
	{
		public int ProductId { get; set; }
		public int SellerId { get; set; }
		public Product Product { get; set; }
		public Seller Seller { get; set; }
	}
}
