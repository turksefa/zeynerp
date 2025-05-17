using Microsoft.AspNetCore.Http;
using zeynerp.Core.Entities.Tanimlamalar;
using zeynerp.Core.Repositories.Tanimlamalar;
using zeynerp.Infrastructure.Data.Contexts;

namespace zeynerp.Infrastructure.Data.Repositories.Tanimlamalar
{
    public class StokOzellikRepository : TenantRepository<StokOzellik>, IStokOzellikRepository
    {
        public StokOzellikRepository(TenantDbContextFactory tenantDbContextFactory, IHttpContextAccessor httpContextAccessor) : base(tenantDbContextFactory, httpContextAccessor)
        {
        }
    }
}