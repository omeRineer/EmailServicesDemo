using MailKit.Net.Smtp;
using MailKitDemo.Models;
using MimeKit;
using MimeKit.Text;

public class EmailService : IEmailService
{
    readonly EmailConfiguration EmailConfiguration;
    public EmailService()
    {
        EmailConfiguration = new EmailConfiguration();
    }

    public void Send(MailMessage mailMessage)
    {
        var mimeMessage = CreateMessage(mailMessage);
        using (var smtpClient = new SmtpClient())
        {
            try
            {
                smtpClient.Connect(EmailConfiguration.Host, EmailConfiguration.Port, EmailConfiguration.UseSSL);
                smtpClient.Authenticate(EmailConfiguration.UserName, EmailConfiguration.Password);

                smtpClient.Send(mimeMessage);
            }
            catch
            {
                smtpClient.Disconnect(true);
                smtpClient.Dispose();
            }
        }
    }

    private MimeMessage CreateMessage(MailMessage message)
    {
        var mimeMessage = new MimeMessage();

        mimeMessage.From.AddRange(message.From);
        mimeMessage.To.AddRange(message.To);

        mimeMessage.Subject = message.Subject;
        mimeMessage.Body = new TextPart(TextFormat.Text)
        {
            Text = message.Body
        };

        return mimeMessage;
    }
}