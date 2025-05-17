using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using zeynerp.Core.Entities;

namespace zeynerp.Infrastructure.Data.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<TenantPlan> TenantPlans { get; set; }
        public DbSet<Invitation> Invitations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Plan>().HasData(
                new Plan { Id = Guid.NewGuid(), Name = "Satın Alma Yönetimi", Price = 0 },
                new Plan { Id = Guid.NewGuid(), Name = "Finans ve Muhasebe Yönetimi", Price = 2000 },
                new Plan { Id = Guid.NewGuid(), Name = "Personel Yönetimi", Price = 2000 },
                new Plan { Id = Guid.NewGuid(), Name = "Kalite Yönetimi", Price = 2000 },
                new Plan { Id = Guid.NewGuid(), Name = "Üretim Yönetimi", Price = 2000 },
                new Plan { Id = Guid.NewGuid(), Name = "Proje Yönetimi", Price = 2000 },
                new Plan { Id = Guid.NewGuid(), Name = "Stok Yönetimi", Price = 2000 }
            );

            modelBuilder.Entity<TenantPlan>()
                .HasKey(tp => tp.Id);

            modelBuilder.Entity<TenantPlan>()
                .HasOne(tp => tp.Tenant)
                .WithMany(t => t.TenantPlans)
                .HasForeignKey(tp => tp.TenantId);

            modelBuilder.Entity<TenantPlan>()
                .HasOne(tp => tp.Plan)
                .WithMany(p => p.TenantPlans)
                .HasForeignKey(tp => tp.PlanId);
        }
    }
}