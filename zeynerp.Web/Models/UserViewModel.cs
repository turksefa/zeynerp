using zeynerp.Application.DTOs;

namespace zeynerp.Web.Models
{
    public class UserViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; } = new List<UserDto>();
        public IReadOnlyList<InvitationDto> InvitationDtos { get; set; } = new List<InvitationDto>();
        public InvitationViewModel? InvitationViewModel { get; set; }
    }
}