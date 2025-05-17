using Microsoft.EntityFrameworkCore;
using zeynerp.Core.Entities.Tanimlamalar;

namespace zeynerp.Infrastructure.Data.Contexts
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options)
        {

        }

        public DbSet<StokGrup> StokGruplar { get; set; }
        public DbSet<StokOzellik> StokOzellikler { get; set; }
        public DbSet<Birim> Birimler { get; set; }
        public DbSet<Stok> Stoklar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Birim>().HasData(
                new Birim { Id = 1, Name = "Yok", Unit = "Yok", Order = 1, Status = Status.Aktif }
            );
        }
    }
}