using Microsoft.AspNetCore.Http;
using zeynerp.Core.Interfaces;
using zeynerp.Core.Repositories.Tanimlamalar;
using zeynerp.Infrastructure.Data.Contexts;

namespace zeynerp.Infrastructure.Data
{
    public class TenantUnitOfWork : ITenantUnitOfWork
    {
        private readonly IStokGrupRepository _stokGrupRepository;
        private readonly TenantDbContext _context;

        public TenantUnitOfWork(IStokGrupRepository stokGrupRepository, TenantDbContextFactory tenantDbContextFactory, IHttpContextAccessor httpContextAccessor)
        {
            _stokGrupRepository = stokGrupRepository;
            _context = tenantDbContextFactory.CreateDbContextAsync(httpContextAccessor.HttpContext.Items["UserId"].ToString()).Result;
        }

        public IStokGrupRepository StokGrupRepository => _stokGrupRepository;

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}