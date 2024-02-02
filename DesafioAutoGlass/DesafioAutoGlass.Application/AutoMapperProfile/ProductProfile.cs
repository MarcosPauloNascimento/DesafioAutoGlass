using AutoMapper;
using DesafioAutoGlass.Application.Dtos;
using DesafioAutoGlass.Domain.Entities;

namespace DesafioAutoGlass.Application.AutoMapperProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>();

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.Description));

        }
    }
}
