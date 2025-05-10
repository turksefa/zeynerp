namespace zeynerp.Web.Models
{
    public class AcceptInvitationViewModel
    {
        public Guid InvitationId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}