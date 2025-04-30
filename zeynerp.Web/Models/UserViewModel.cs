using zeynerp.Application.DTOs;

namespace zeynerp.Web.Models
{
    public class UserViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; } = new List<UserDto>();
        public InvitationDto? InvitationDto { get; set; }
    }
}