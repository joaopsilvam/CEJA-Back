using Enceja.Domain.Entities;

namespace Enceja.Domain.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(string to, string subject, string htmlBody);
    }

}
