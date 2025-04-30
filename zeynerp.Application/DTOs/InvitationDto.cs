namespace zeynerp.Application.DTOs
{
    public class InvitationDto
    {
        public string Email { get; set; } = string.Empty;
        public Guid TenantId { get; set; }
    }
}