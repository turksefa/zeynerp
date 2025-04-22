using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using zeynerp.Core.Entities;
using zeynerp.Infrastructure.Identity.Models;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Plan>().HasData(
                new Plan { Id = Guid.NewGuid(), Name = "Finans ve Muhasebe Yönetimi", Price = 6000 },
                new Plan { Id = Guid.NewGuid(), Name = "Personel Yönetimi", Price = 6000 },
                new Plan { Id = Guid.NewGuid(), Name = "Kalite Yönetimi", Price = 6000 },
                new Plan { Id = Guid.NewGuid(), Name = "Üretim Yönetimi", Price = 6000 },
                new Plan { Id = Guid.NewGuid(), Name = "Proje Yönetimi", Price = 6000 },
                new Plan { Id = Guid.NewGuid(), Name = "Stok Yönetimi", Price = 1299 },
                new Plan { Id = Guid.NewGuid(), Name = "Satın Alma Yönetimi", Price = 0 }
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