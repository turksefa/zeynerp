namespace zeynerp.Core.Entities
{
    public class TenantPlan
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Guid PlanId { get; set; }
        public DateTime? ExpiryDate  { get; set; }
        public bool IsActive { get; set; }

        public Tenant Tenant { get; set; } = new Tenant();
        public Plan Plan { get; set; } = new Plan();
    }
}