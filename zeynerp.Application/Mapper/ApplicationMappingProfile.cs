using AutoMapper;
using zeynerp.Application.DTOs;
using zeynerp.Application.DTOs.Tanimlamalar;
using zeynerp.Core.Entities;
using zeynerp.Core.Entities.Tanimlamalar;

namespace zeynerp.Application.Mapper
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Plan, PlanDto>();
            CreateMap<TenantPlan, TenantPlanDto>();
            CreateMap<Invitation, InvitationDto>().ReverseMap();
            CreateMap<StokGrup, StokGrupDto>().ReverseMap();
            CreateMap<StokOzellik, StokOzellikDto>().ReverseMap();
            CreateMap<Birim, BirimDto>().ReverseMap();
            CreateMap<Stok, StokDto>().ReverseMap();
        }
    }
}