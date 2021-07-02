using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Integral.Options;

namespace Integral.Senders
{
    public sealed class SmtpEmailSender : EmailSender
    {
        private readonly SmtpClient smtpClient;

        public SmtpEmailSender(SmtpClient smtpClient) => this.smtpClient = smtpClient;

        public SmtpEmailSender(EmailSenderOptions emailSenderOptions)
        {
            this.smtpClient = new SmtpClient(emailSenderOptions.Host, emailSenderOptions.Port);
            this.smtpClient.Credentials = new NetworkCredential(emailSenderOptions.Username, emailSenderOptions.Password);
            this.smtpClient.EnableSsl = emailSenderOptions.EnableSsl;
            this.smtpClient.Timeout = emailSenderOptions.Timeout;
        }

        public async Task Send(MailMessage mailMessage) => await this.smtpClient.SendMailAsync(mailMessage);

        public async Task Send(MailAddress from, MailAddress to, string subject, string body, bool isBodyHtml = false)
        {
            MailMessage mailMessage = new MailMessage(from, to);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = isBodyHtml;
            await this.Send(mailMessage);
        }

        public async Task Send(string from, string to, string subject, string body, string? display, bool isBodyHtml = false)
        {
            await this.Send(new MailAddress(from, display), new MailAddress(to), subject, body, isBodyHtml);
        }
    }
}