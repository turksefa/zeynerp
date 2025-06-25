using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using zeynerp.Core.Entities.Tanimlamalar;
using zeynerp.Core.Repositories.Tanimlamalar;
using zeynerp.Infrastructure.Data.Contexts;

namespace zeynerp.Infrastructure.Data.Repositories.Tanimlamalar
{
    public class CariRepository : TenantRepository<Cari>, ICariRepository
    {
        private readonly TenantDbContextFactory _tenantDbContextFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CariRepository(TenantDbContextFactory tenantDbContextFactory, IHttpContextAccessor httpContextAccessor) : base(tenantDbContextFactory, httpContextAccessor)
        {
            _tenantDbContextFactory = tenantDbContextFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IReadOnlyList<Cari>> GetCarilerAsync()
        {
            var userId = _httpContextAccessor.HttpContext.Items["UserId"]?.ToString();
            using var context = await _tenantDbContextFactory.CreateDbContextAsync(userId);
            return await context.Set<Cari>().Include(c => c.CariTurler).Include(c => c.CariYetkililer).Include(c => c.TeslimatAdresler).ToListAsync();
        }

        public async Task<Cari> GetCariByIdAsync(int id)
        {
            var userId = _httpContextAccessor.HttpContext.Items["UserId"]?.ToString();
            using var context = await _tenantDbContextFactory.CreateDbContextAsync(userId);
            return await context.Set<Cari>().Include(c => c.CariTurler).Include(c => c.CariYetkililer).Include(c => c.TeslimatAdresler).AsTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
        
        public async Task DeleteCariTurlerByCariIdAsync(int id)
        {
            var userId = _httpContextAccessor.HttpContext.Items["UserId"]?.ToString();
            using var context = await _tenantDbContextFactory.CreateDbContextAsync(userId);

            var existingCari = await context.Set<Cari>().Include(c => c.CariTurler).FirstOrDefaultAsync(c => c.Id == id);
            if (existingCari != null && existingCari.CariTurler.Count > 0)
            {
                existingCari.CariTurler.Clear();
            }
            await context.SaveChangesAsync();
        }
    }
}