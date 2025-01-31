using AutoMapper;
using zeynerp.Application.DTOs;
using zeynerp.Core.Entities;

namespace zeynerp.Web.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductDto, Product>();
        }
    }
}