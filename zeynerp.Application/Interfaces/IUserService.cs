using zeynerp.Application.DTOs;

namespace zeynerp.Application.Interfaces
{
    public interface IUserService
    {
        Task<IReadOnlyList<UserDto>> GetUsersAsync(Guid tenantId);
    }
}