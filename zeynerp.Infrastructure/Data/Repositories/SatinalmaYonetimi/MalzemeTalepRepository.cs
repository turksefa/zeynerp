using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using zeynerp.Core.Entities.SatinalmaYonetimi;
using zeynerp.Core.Repositories.SatinalmaYonetimi;
using zeynerp.Infrastructure.Data.Contexts;

namespace zeynerp.Infrastructure.Data.Repositories.SatinalmaYonetimi
{
    public class MalzemeTalepRepository : TenantRepository<MalzemeTalep>, IMalzemeTalepRepository
    {
        private readonly TenantDbContextFactory _tenantDbContextFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MalzemeTalepRepository(TenantDbContextFactory tenantDbContextFactory, IHttpContextAccessor httpContextAccessor) : base(tenantDbContextFactory, httpContextAccessor)
        {
            _tenantDbContextFactory = tenantDbContextFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IReadOnlyList<MalzemeTalep>> GetMalzemeTaleplerAsync()
        {
            var userId = _httpContextAccessor.HttpContext.Items["UserId"]?.ToString();
            using var context = await _tenantDbContextFactory.CreateDbContextAsync(userId);
            return await context.Set<MalzemeTalep>().Include(sg => sg.StokGrup).Include(s => s.Stok).Include(so => so.StokOzellik).ToListAsync();
        }
    }
}