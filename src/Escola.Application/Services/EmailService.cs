using Enceja.Domain.Entities;
using Enceja.Domain.Interfaces;
using Enceja.Domain.Interfaces;
using System.Net.Mail;
using System.Net;

namespace Enceja.Domain.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendAsync(string to, string subject, string htmlBody)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("joaopsilvam90@gmail.com", "hkbr mlnd pcdg afch"),
                EnableSsl = true
            };

            var mailMessage = new MailMessage("joaopsilvam90@gmail.com", to, subject, htmlBody)
            {
                IsBodyHtml = true
            };

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
