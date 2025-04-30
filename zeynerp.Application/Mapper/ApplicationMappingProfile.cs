using AutoMapper;
using zeynerp.Application.DTOs;
using zeynerp.Core.Entities;

namespace zeynerp.Application.Mapper
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Plan, PlanDto>();
            CreateMap<TenantPlan, TenantPlanDto>();
        }
    }
}