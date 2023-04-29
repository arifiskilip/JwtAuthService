using AutoMapper;
using Core.Dtos;
using Core.Entities;

namespace Service.Mappings
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<AppUserDto, AppUser>().ReverseMap();
        }
    }
}
