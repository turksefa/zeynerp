namespace zeynerp.Core.Entities
{
    public class Plan
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public ICollection<TenantPlan>? TenantPlans { get; set; }
    }
}