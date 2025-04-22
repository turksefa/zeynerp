using AutoMapper;
using zeynerp.Core.DTOs;
using zeynerp.Core.Entities;

namespace zeynerp.Application.Mapper
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Plan, PlanDto>();
        }
    }
}