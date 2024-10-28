using AutoMapper;
using ReviewSystem.Dto.Get;
using ReviewSystem.Dto.Post;
using ReviewSystem.Models;

namespace ReviewSystem.Helper
{
    public class MappingProfile: Profile
	{
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Seller, SellerDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Reviewer, ReviewerDto>();

            CreateMap<CreateCategoryDto, Category>();
            CreateMap<CreateProductDto, Product>();
        }
    }
}
