using Microsoft.EntityFrameworkCore;
using zeynerp.Core.Entities.Tanimlamalar;

namespace zeynerp.Infrastructure.Data.Contexts
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options)
        {
            
        }

        public DbSet<StokGrup> StokGrups { get; set; }
    }
}