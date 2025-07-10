using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using zeynerp.Core.Entities.SatinalmaYonetimi;
using zeynerp.Core.Repositories.SatinalmaYonetimi;
using zeynerp.Infrastructure.Data.Contexts;

namespace zeynerp.Infrastructure.Data.Repositories.SatinalmaYonetimi
{
    public class MalzemeTalepleriRepository : TenantRepository<MalzemeTalepleri>, IMalzemeTalepleriRepository
    {
        private readonly TenantDbContextFactory _tenantDbContextFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MalzemeTalepleriRepository(TenantDbContextFactory tenantDbContextFactory, IHttpContextAccessor httpContextAccessor) : base(tenantDbContextFactory, httpContextAccessor)
        {
            _tenantDbContextFactory = tenantDbContextFactory;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IReadOnlyList<MalzemeTalepleri>> GetMalzemeTalepleriAsync()
        {
            var userId = _httpContextAccessor.HttpContext.Items["UserId"]?.ToString();
            using var context = await _tenantDbContextFactory.CreateDbContextAsync(userId);
            return await context.Set<MalzemeTalepleri>().Include(mt => mt.Cari).Include(mt => mt.CariYetkili).Include(mt => mt.MalzemeTalep).ToListAsync();
        }
        
        public async Task<MalzemeTalepleri> GetMalzemeTalepleriByIdAsync(int id)
        {
            var userId = _httpContextAccessor.HttpContext.Items["UserId"]?.ToString();
            using var context = await _tenantDbContextFactory.CreateDbContextAsync(userId);
            return await context.Set<MalzemeTalepleri>().FindAsync(id);
        }

        public async Task<IReadOnlyList<MalzemeTalepleri>> GetMalzemeTalepleriByCariYetkiliIdAsync(int id)
        {
            var userId = _httpContextAccessor.HttpContext.Items["UserId"]?.ToString();
            using var context = await _tenantDbContextFactory.CreateDbContextAsync(userId);
            return await context.Set<MalzemeTalepleri>()
                .Include(mt => mt.Cari)
                .ThenInclude(c => c.TeslimatAdresler)
                .Include(mt => mt.CariYetkili)
                .Include(mt => mt.MalzemeTalep)
                .ThenInclude(mt => mt.Stok)
                .Include(mt => mt.MalzemeTalep)
                .ThenInclude(mt => mt.StokGrup)
                .Include(mt => mt.MalzemeTalep)
                .ThenInclude(mt => mt.StokOzellik)
                .Where(mt => mt.CariYetkiliId == id).ToListAsync();
        }    
    }
}