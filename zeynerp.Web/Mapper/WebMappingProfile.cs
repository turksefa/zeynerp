using AutoMapper;
using zeynerp.Application.DTOs;
using zeynerp.Application.DTOs.Authentication;
using zeynerp.Application.DTOs.Tanimlamalar;
using zeynerp.Web.Models;
using zeynerp.Web.Models.Authentication;
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
            CreateMap<StokGrupDto, StokGrupViewModel>();
        }
    }
}