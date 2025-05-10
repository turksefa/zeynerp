namespace zeynerp.Application.DTOs
{
    public class InvitationDto
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}