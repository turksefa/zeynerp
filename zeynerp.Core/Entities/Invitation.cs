namespace zeynerp.Core.Entities
{
    public class Invitation
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string Email { get; set; } = string.Empty;
        public InvitationStatus InvitationStatus { get; set; }
    }

    public enum InvitationStatus
    {
        Pending,
        Accepted,
        Rejected
    }
}