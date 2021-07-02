using System.Net.Mail;
using System.Threading.Tasks;

namespace Integral.Senders
{
    public interface EmailSender
    {
        Task Send(MailMessage mailMessage);

        Task Send(MailAddress from, MailAddress to, string subject, string body, bool isBodyHtml = false);

        Task Send(string from, string to, string subject, string body, string? display, bool isBodyHtml = false);
    }
}