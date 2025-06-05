using Microsoft.AspNetCore.Http;
using zeynerp.Core.Entities.Tanimlamalar;
using zeynerp.Core.Repositories.Tanimlamalar;
using zeynerp.Infrastructure.Data.Contexts;

namespace zeynerp.Infrastructure.Data.Repositories.Tanimlamalar
{
    public class CariRepository : TenantRepository<Cari>, ICariRepository
    {
        public CariRepository(TenantDbContextFactory tenantDbContextFactory, IHttpContextAccessor httpContextAccessor) : base(tenantDbContextFactory, httpContextAccessor)
        {
        }
    }
}