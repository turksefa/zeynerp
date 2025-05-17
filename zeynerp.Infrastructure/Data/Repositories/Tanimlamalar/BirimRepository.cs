using Microsoft.AspNetCore.Http;
using zeynerp.Core.Entities.Tanimlamalar;
using zeynerp.Core.Repositories.Tanimlamalar;
using zeynerp.Infrastructure.Data.Contexts;

namespace zeynerp.Infrastructure.Data.Repositories.Tanimlamalar
{
    public class BirimRepository : TenantRepository<Birim>, IBirimRepository
    {
        public BirimRepository(TenantDbContextFactory tenantDbContextFactory, IHttpContextAccessor httpContextAccessor) : base(tenantDbContextFactory, httpContextAccessor)
        {
        }
    }
}