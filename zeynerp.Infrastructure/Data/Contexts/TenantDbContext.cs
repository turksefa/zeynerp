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
        public DbSet<KDV> KDVler { get; set; }
        public DbSet<OdemeVade> OdemeVadeler { get; set; }
        public DbSet<ParaBirim> ParaBirimler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Birim>().HasData(
                new Birim { Id = 1, Order = 1, Name = "Yok", Unit = "Yok", Status = Status.Aktif },
                new Birim { Id = 2, Order = 2, Name = "Adet", Unit = "Adet", Status = Status.Aktif },
                new Birim { Id = 3, Order = 3, Name = "Kilogram", Unit = "KG", Status = Status.Aktif },
                new Birim { Id = 4, Order = 4, Name = "Metrekare", Unit = "M2", Status = Status.Aktif },
                new Birim { Id = 5, Order = 5, Name = "Milimetre", Unit = "MM", Status = Status.Aktif },
                new Birim { Id = 6, Order = 6, Name = "Metre", Unit = "M", Status = Status.Aktif }
            );

            modelBuilder.Entity<StokOzellik>().HasData(
                new StokOzellik { Id = 1, Order = 1, Name = "Yok", OzgulAgirlik = 1, Status = Status.Aktif }
            );

            modelBuilder.Entity<StokGrup>().HasData(
                new StokGrup { Id = 1, Order = 1, Name = "Yok", Status = Status.Aktif }
            );

            modelBuilder.Entity<KDV>().HasData(
                new KDV { Id = 1, Order = 1, Name = "0", Status = Status.Aktif },
                new KDV { Id = 2, Order = 2, Name = "1", Status = Status.Aktif },
                new KDV { Id = 3, Order = 3, Name = "10", Status = Status.Aktif },
                new KDV { Id = 4, Order = 4, Name = "20", Status = Status.Aktif }
            );

            modelBuilder.Entity<ParaBirim>().HasData(
                new ParaBirim { Id = 1, Order = 1, Name = "TRY", Birim = "₺", Status = Status.Aktif },
                new ParaBirim { Id = 2, Order = 2, Name = "USD", Birim = "$", Status = Status.Aktif },
                new ParaBirim { Id = 3, Order = 3, Name = "EUR", Birim = "€", Status = Status.Aktif }
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