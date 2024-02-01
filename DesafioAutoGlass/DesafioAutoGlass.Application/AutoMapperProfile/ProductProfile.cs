using AutoMapper;
using DesafioAutoGlass.Application.Dtos;
using DesafioAutoGlass.Domain.Entities;
using DesafioAutoGlass.Domain.Enum;
using System;

namespace DesafioAutoGlass.Application.AutoMapperProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => GetHashCode(src.StatusProduct)));

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.StatusProduct, opt => opt.MapFrom(src => (StatusEnum)src.Status))
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.Description));

        }

        private int GetHashCode(string status)
        {
            return Enum.Parse<StatusEnum>(status).GetHashCode();
        }
    }
}
