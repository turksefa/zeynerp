using AutoMapper;
using zeynerp.Application.DTOs;
using zeynerp.Application.DTOs.SatinalmaYonetimi;
using zeynerp.Application.DTOs.Tanimlamalar;
using zeynerp.Core.Entities;
using zeynerp.Core.Entities.SatinalmaYonetimi;
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
            CreateMap<MalzemeTalep, MalzemeTalepDto>().ReverseMap();
            CreateMap<MalzemeTalepleri, MalzemeTalepleriDto>().ReverseMap();
            CreateMap<CariTur, CariTurDto>().ReverseMap();
            CreateMap<TeslimatAdres, TeslimatAdresDto>().ReverseMap();
            CreateMap<CariYetkili, CariYetkiliDto>().ReverseMap();
            CreateMap<Cari, CariDto>()
                .ForMember(dest => dest.CariTurDtos,
                    opt => opt.MapFrom(src => src.CariTurler))
                .ForMember(dest => dest.CariYetkiliDtos,
                    opt => opt.MapFrom(src => src.CariYetkililer))
                .ForMember(dest => dest.TeslimatAdresDtos,
                    opt => opt.MapFrom(src => src.TeslimatAdresler));
            CreateMap<CariDto, Cari>()
                .ForMember(dest => dest.CariTurler,
                    opt => opt.MapFrom(src => src.CariTurDtos))
                .ForMember(dest => dest.CariYetkililer,
                    opt => opt.MapFrom(src => src.CariYetkiliDtos))
                .ForMember(dest => dest.TeslimatAdresler,
                    opt => opt.MapFrom(src => src.TeslimatAdresDtos));
            CreateMap<KDV, KDVDto>().ReverseMap();
            CreateMap<OdemeVade, OdemeVadeDto>().ReverseMap();
            CreateMap<ParaBirim, ParaBirimDto>().ReverseMap();
        }
    }
}