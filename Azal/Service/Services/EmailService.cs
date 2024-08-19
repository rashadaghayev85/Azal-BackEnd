
using MailKit.Net.Smtp;
using MimeKit;

namespace Service.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("rashadra@code.edu.az"));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;

            var builder = new BodyBuilder { HtmlBody = message };
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync("rashadra@code.edu.az", "wugf kjzi zhge tzmb");
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
