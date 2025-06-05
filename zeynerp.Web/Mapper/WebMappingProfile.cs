using System.Globalization;
using AutoMapper;
using zeynerp.Application.DTOs;
using zeynerp.Application.DTOs.Authentication;
using zeynerp.Application.DTOs.SatinalmaYonetimi;
using zeynerp.Application.DTOs.Tanimlamalar;
using zeynerp.Web.Models;
using zeynerp.Web.Models.Authentication;
using zeynerp.Web.Models.SatinalmaYonetimi;
using zeynerp.Web.Models.Tanimlamalar;

namespace zeynerp.Web.Mapper
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<RegisterViewModel, RegisterDto>();
            CreateMap<LoginViewModel, LoginDto>();
            CreateMap<PlanDto, PlanViewModel>();
            CreateMap<ForgotPasswordViewModel, ForgotPasswordDto>();
            CreateMap<PaymentViewModel, PaymentDto>();
            CreateMap<UserDto, UserViewModel>();
            CreateMap<InvitationViewModel, InvitationDto>();
            CreateMap<AcceptInvitationViewModel, InvitationAcceptDto>();
            CreateMap<StokGrupDto, StokGrupViewModel>().ReverseMap();
            CreateMap<StokOzellikDto, StokOzellikViewModel>()
                .ForMember(dest => dest.OzgulAgirlik,
                    opt => opt.MapFrom(src => src.OzgulAgirlik.ToString()));
            CreateMap<StokOzellikViewModel, StokOzellikDto>()
                .ForMember(dest => dest.OzgulAgirlik,
                    opt => opt.MapFrom(src => double.Parse(src.OzgulAgirlik, CultureInfo.InvariantCulture)));
            CreateMap<BirimDto, BirimViewModel>().ReverseMap();
            CreateMap<StokDto, StokViewModel>().ReverseMap();
            CreateMap<MalzemeTalepDto, MalzemeTalepViewModel>()
                .ForMember(dest => dest.Boyut1,
                    opt => opt.MapFrom(src => src.Boyut1.ToString()))
                .ForMember(dest => dest.Boyut2,
                    opt => opt.MapFrom(src => src.Boyut2.ToString()))
                .ForMember(dest => dest.Boyut3,
                    opt => opt.MapFrom(src => src.Boyut3.ToString()))
                .ForMember(dest => dest.Boyut4,
                    opt => opt.MapFrom(src => src.Boyut4.ToString()))
                .ForMember(dest => dest.Kg,
                    opt => opt.MapFrom(src => src.Kg.ToString()))
                .ForMember(dest => dest.M2,
                    opt => opt.MapFrom(src => src.M2.ToString()))
                .ForMember(dest => dest.Mm,
                    opt => opt.MapFrom(src => src.Mm.ToString()))
                .ForMember(dest => dest.M,
                    opt => opt.MapFrom(src => src.M.ToString()));
            CreateMap<MalzemeTalepViewModel, MalzemeTalepDto>()
                .ForMember(dest => dest.Boyut1,
                    opt => opt.MapFrom(src =>
                        string.IsNullOrWhiteSpace(src.Boyut1)
                            ? 0
                            : double.Parse(src.Boyut1, CultureInfo.InvariantCulture)
                    ))
                .ForMember(dest => dest.Boyut2,
                    opt => opt.MapFrom(src =>
                        string.IsNullOrWhiteSpace(src.Boyut2)
                            ? 0
                            : double.Parse(src.Boyut2, CultureInfo.InvariantCulture)
                    ))
                .ForMember(dest => dest.Boyut3,
                    opt => opt.MapFrom(src =>
                        string.IsNullOrWhiteSpace(src.Boyut3)
                            ? 0
                            : double.Parse(src.Boyut3, CultureInfo.InvariantCulture)
                    ))
                .ForMember(dest => dest.Boyut4,
                    opt => opt.MapFrom(src =>
                        string.IsNullOrWhiteSpace(src.Boyut4)
                            ? 0
                            : double.Parse(src.Boyut4, CultureInfo.InvariantCulture)
                    ))
                .ForMember(dest => dest.Kg,
                    opt => opt.MapFrom(src =>
                        string.IsNullOrWhiteSpace(src.Kg)
                            ? 0
                            : double.Parse(src.Kg, CultureInfo.InvariantCulture)
                    ))
                .ForMember(dest => dest.M2,
                    opt => opt.MapFrom(src =>
                        string.IsNullOrWhiteSpace(src.M2)
                            ? 0
                            : double.Parse(src.M2, CultureInfo.InvariantCulture)
                    ))
                .ForMember(dest => dest.Mm,
                    opt => opt.MapFrom(src =>
                        string.IsNullOrWhiteSpace(src.Mm)
                            ? 0
                            : double.Parse(src.Mm, CultureInfo.InvariantCulture)
                    ))
                .ForMember(dest => dest.M,
                    opt => opt.MapFrom(src =>
                        string.IsNullOrWhiteSpace(src.M)
                            ? 0
                            : double.Parse(src.M, CultureInfo.InvariantCulture)
                    ));
            CreateMap<CariTurDto, CariTurViewModel>().ReverseMap();
            CreateMap<CariDto, CariViewModel>().ReverseMap();
        }
    }
}