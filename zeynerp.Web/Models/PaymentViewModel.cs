namespace zeynerp.Web.Models
{
    public class PaymentViewModel
    {
        public PlanViewModel PlanViewModel { get; set; } = new PlanViewModel();
        public int NumberOfUsers { get; set; }
        public string HolderName { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string ExpireMonth { get; set; } = string.Empty;
        public string ExpireYear { get; set; } = string.Empty;
        public string Cvc { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid PlanId { get; set; }
    }
}