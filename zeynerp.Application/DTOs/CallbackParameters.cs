namespace zeynerp.Application.DTOs
{
    public class CallbackParameters
    {
        public string Status { get; set; } = string.Empty;
        public Guid TenantId { get; set; }
        public Guid PlanId { get; set; }
    }
}