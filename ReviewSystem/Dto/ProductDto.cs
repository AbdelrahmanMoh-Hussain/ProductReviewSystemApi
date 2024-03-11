using System.ComponentModel.DataAnnotations;

namespace ReviewSystem.Dto
{
	public class ProductDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
        public DateTime ProductionDate { get; set; }
        public decimal Price { get; set; }
    }
}
