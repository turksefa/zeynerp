using Microsoft.EntityFrameworkCore;
using zeynerp.Core.Entities.SatinalmaYonetimi;
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
        public DbSet<MalzemeTalep> MalzemeTalepler { get; set; }
        public DbSet<MalzemeTalepleri> MalzemeTalepleri { get; set; }
        public DbSet<CariTur> CariTurler { get; set; }
        public DbSet<Cari> Cariler { get; set; }
        public DbSet<CariYetkili> CariYetkililer { get; set; }
        public DbSet<TeslimatAdres> TeslimatAdresleri { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Birim>().HasData(
                new Birim { Id = 1, Name = "Yok", Unit = "Yok", Order = 1, Status = Status.Aktif }
            );

            modelBuilder.Entity<MalzemeTalep>()
                .HasOne(mt => mt.Stok)
                .WithMany()
                .HasForeignKey(mt => mt.StokId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MalzemeTalep>()
                .HasOne(mt => mt.StokGrup)
                .WithMany()
                .HasForeignKey(mt => mt.StokGrupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MalzemeTalep>()
                .HasOne(mt => mt.StokOzellik)
                .WithMany()
                .HasForeignKey(mt => mt.StokOzellikId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MalzemeTalepleri>()
               .HasOne(mt => mt.Cari)
               .WithMany()
               .HasForeignKey(mt => mt.CariId)
               .OnDelete(DeleteBehavior.Restrict);
                
            modelBuilder.Entity<MalzemeTalepleri>()
                .HasOne(mt => mt.CariYetkili)
                .WithMany()
                .HasForeignKey(mt => mt.CariYetkiliId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}