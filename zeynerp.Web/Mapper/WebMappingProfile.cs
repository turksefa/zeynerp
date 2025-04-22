using AutoMapper;
using zeynerp.Core.DTOs;
using zeynerp.Core.DTOs.Authentication;
using zeynerp.Web.Models;
using zeynerp.Web.Models.Authentication;

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
        }
    }
}