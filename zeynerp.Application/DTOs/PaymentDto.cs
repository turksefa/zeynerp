namespace zeynerp.Application.DTOs
{
    public class PaymentDto
    {
        public decimal Price { get; set; }
        public string HolderName { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string ExpireMonth { get; set; } = string.Empty;
        public string ExpireYear { get; set; } = string.Empty;
        public string CVC { get; set; } = string.Empty;
        public Guid TenantId { get; set; }
        public Guid PlanId { get; set; }
    }
}