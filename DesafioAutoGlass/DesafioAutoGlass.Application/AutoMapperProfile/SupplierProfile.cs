using AutoMapper;
using DesafioAutoGlass.Application.Dtos;
using DesafioAutoGlass.Domain.Entities;

namespace DesafioAutoGlass.Application.AutoMapperProfile
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<SupplierDto, Supplier>().ReverseMap();
        }
    }
}
