using AutoMapper;
using zeynerp.Application.DTOs;
using zeynerp.Application.DTOs.Identity;
using zeynerp.Core.Entities;

namespace zeynerp.Web.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RegisterDto, ApplicationUser>();
            CreateMap<ProductDto, Product>();
        }
    }
}