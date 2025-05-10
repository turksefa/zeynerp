namespace zeynerp.Application.DTOs
{
    public class InvitationAcceptDto
    {
        public Guid InvitationId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}