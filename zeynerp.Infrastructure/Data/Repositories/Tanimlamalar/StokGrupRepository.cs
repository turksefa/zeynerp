using Microsoft.AspNetCore.Http;
using zeynerp.Core.Entities.Tanimlamalar;
using zeynerp.Core.Repositories.Tanimlamalar;
using zeynerp.Infrastructure.Data.Contexts;

namespace zeynerp.Infrastructure.Data.Repositories.Tanimlamalar
{
    public class StokGrupRepository : TenantRepository<StokGrup>, IStokGrupRepository
    {
        public StokGrupRepository(TenantDbContextFactory tenantDbContextFactory, IHttpContextAccessor httpContextAccessor) : base(tenantDbContextFactory, httpContextAccessor)
        {
        }
    }
}