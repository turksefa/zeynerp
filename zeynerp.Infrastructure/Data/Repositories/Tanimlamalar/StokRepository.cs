using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using zeynerp.Core.Entities.Tanimlamalar;
using zeynerp.Core.Repositories.Tanimlamalar;
using zeynerp.Infrastructure.Data.Contexts;

namespace zeynerp.Infrastructure.Data.Repositories.Tanimlamalar
{
    public class StokRepository : TenantRepository<Stok>, IStokRepository
    {
        private readonly TenantDbContextFactory _tenantDbContextFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StokRepository(TenantDbContextFactory tenantDbContextFactory, IHttpContextAccessor httpContextAccessor) : base(tenantDbContextFactory, httpContextAccessor)
        {
            _tenantDbContextFactory = tenantDbContextFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IReadOnlyList<Stok>> GetStoklarAsync()
        {
            var userId = _httpContextAccessor.HttpContext.Items["UserId"]?.ToString();
            using var context = await _tenantDbContextFactory.CreateDbContextAsync(userId);
            return await context.Set<Stok>().Include(s => s.StokGrup).ToListAsync();
        }
    }
}