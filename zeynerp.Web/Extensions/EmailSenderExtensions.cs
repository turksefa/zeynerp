using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace zeynerp.Web.Extensions
{
    public static class EmailSenderExtensions
    {
        public static Task SendInvitationAsync(this IEmailSender emailSender, string email, string link)
        {
            var subject = "Invitation to join Zeynerp";
            var message = $"You have been invited to join Zeynerp. Click the link below to accept the invitation:\n\n{HtmlEncoder.Default.Encode(link)}";
            return emailSender.SendEmailAsync(email, subject, message);
        }

        public static Task SendPasswordResetAsync(this IEmailSender emailSender, string email, string link)
        {
            var subject = "Password Reset Request";
            var message = $"You have requested to reset your password. Click the link below to reset your password:\n\n{HtmlEncoder.Default.Encode(link)}";
            return emailSender.SendEmailAsync(email, subject, message);
        }
    }
}