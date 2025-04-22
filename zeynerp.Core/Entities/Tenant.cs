namespace zeynerp.Core.Entities
{
    public class Tenant
    {
        public Guid Id { get; set; }
        public string ConnectionString { get; set; } = string.Empty;

        public ICollection<TenantPlan>? TenantPlans { get; set; }
    }
}