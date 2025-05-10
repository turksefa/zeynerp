namespace zeynerp.Web.Models
{
    public class InvitationViewModel
    {
        public Guid TenantId { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}