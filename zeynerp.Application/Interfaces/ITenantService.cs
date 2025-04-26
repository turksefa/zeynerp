using zeynerp.Core.Entities;

namespace zeynerp.Application.Services
{
    public interface ITenantService
    {
        Task<Tenant> GetTenantAsync(string userId);
        Task<Tenant> CreateTenantAsync(string userId);
        Task<string> GetConnectionStringAsync(string userId);
    }
}