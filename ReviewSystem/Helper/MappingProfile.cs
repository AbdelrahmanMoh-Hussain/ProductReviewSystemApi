using AutoMapper;
using ReviewSystem.Dto;
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
        }
    }
}
