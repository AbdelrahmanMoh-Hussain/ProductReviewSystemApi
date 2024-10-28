using System.ComponentModel.DataAnnotations;

namespace ReviewSystem.Dto.Get
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ProductionDate { get; set; }
        public decimal Price { get; set; }
    }
}
